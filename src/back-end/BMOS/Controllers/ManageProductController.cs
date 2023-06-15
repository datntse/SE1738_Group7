using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BMOS.Models.Entities;
using Firebase.Auth;
using System.Text;
using Firebase.Storage;
using System.Net;
using Microsoft.VisualBasic;
using System.IO;
using BMOS.Models;

namespace BMOS.Controllers
{
    public class ManageProductController : Controller
    {
        private readonly BmosContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ManageProductController(BmosContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: ManageProduct
        public async Task<IActionResult> Index()
        {
            return _context.TblProducts != null ?
                        View(await _context.TblProducts.ToListAsync()) :
                        Problem("Entity set 'BmosContext.TblProducts'  is null.");
        }

        // GET: ManageProduct/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // GET: ManageProduct/Create
        public IActionResult Create()
        {
            return View();
        }


        private static string ApiKey = "AIzaSyBLDYkXtfdYnKseDJbz6J72lousbPIrniE";
        private static string Bucket = "bmosfile.appspot.com";
        private static string AuthEmail = "staff01@gmail.com";
        private static string AuthPassword = "123456";

        // POST: ManageProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name, Quantity, Price, Description,Weight,IsAvailable,IsLoved,Status")] TblProduct tblProduct, List<IFormFile> files)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));

            // get authentication token
            var authResultTask = auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
            var authResult = await authResultTask;
            var token = authResult.FirebaseToken;


            FirebaseImageModel firebaseImageModel = new FirebaseImageModel();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    firebaseImageModel.ImageFile = file;
                }
            }
            var stream = firebaseImageModel.ImageFile.OpenReadStream();
            //you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var result = await new FirebaseStorage(Bucket,
                 new FirebaseStorageOptions
                 {
                     AuthTokenAsyncFactory = () => Task.FromResult(token)
                 })
               .Child("products")
               .Child(firebaseImageModel.ImageFile.FileName)
               .PutAsync(stream, cancellation.Token);

            if (ModelState.IsValid)
            {
                _context.Add(tblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(tblProduct);
        }

        public async Task<IActionResult> Creates([Bind("ProductId,Name,Quantity,Description,Weight,IsAvailable,IsLoved,Status")] TblProduct tblProduct, List<IFormFile> files)
        {
            string root = _webHostEnvironment.ContentRootPath;
            var filePaths = new List<String>();
            FileStream stream = null;
            string filefolder = "firebaseFiles";
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    //upload the file to the firebase 
                    string path = Path.Combine(root, $"images/{filefolder}");
                    if (Directory.Exists(path))
                    {
                        using (stream = new FileStream(Path.Combine(path), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        stream = new FileStream(Path.Combine(path, file.FileName), FileMode.Open);
                    }
                    else
                    {
                        Directory.CreateDirectory(path);
                    }
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                    var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

                    //you can use CancellationTokenSource to cancel the upload midway
                    var cancellation = new CancellationTokenSource();

                    var task = new FirebaseStorage(
                        Bucket,
                        new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                            ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                        })
                        .Child("products")
                        .Child($"{file.FileName}.{Path.GetExtension(file.FileName).Substring(1)}")
                        .PutAsync(stream, cancellation.Token);

                    //cancel the uploadl
                    cancellation.Cancel();
                    try
                    {
                        //error during upload will be thrown when you await the task
                        Console.WriteLine("Download link:\n" + await task);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception was thrown: {0}", ex);
                    }
                }

                if (ModelState.IsValid)
                {
                    _context.Add(tblProduct);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(tblProduct);
        }

        private static async Task Upload(FileStream stream, String fileName)
        {

            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            //you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                })
                .Child("products")
                .Child($"{fileName}")
                .PutAsync(stream, cancellation.Token);


            //cancel the uploadl
            cancellation.Cancel();
            try
            {
                //error during upload will be thrown when you await the task
                Console.WriteLine("Download link:\n" + await task);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown: {0}", ex);
            }
        }

        // GET: ManageProduct/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            return View(tblProduct);
        }

        // POST: ManageProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProductId,Name,Quantity,Description,Weight,IsAvailable,IsLoved,Status")] TblProduct tblProduct)
        {
            if (id != tblProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductExists(tblProduct.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblProduct);
        }

        // GET: ManageProduct/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TblProducts == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: ManageProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TblProducts == null)
            {
                return Problem("Entity set 'BmosContext.TblProducts'  is null.");
            }
            var tblProduct = await _context.TblProducts.FindAsync(id);
            if (tblProduct != null)
            {
                _context.TblProducts.Remove(tblProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductExists(string id)
        {
            return (_context.TblProducts?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
