using BMOS.Models.Entities;
using BMOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bmostest.Controllers
{
    public class HomeController : Controller
    {
        private readonly BmosContext _context;

        public HomeController(BmosContext context)
        {
            _context = context;
        }

        // GET: TblProducts
        public async Task<IActionResult> Index()
        {
            return _context.TblProducts != null ?
                        View(await _context.TblProducts.ToListAsync()) :
                        Problem("Entity set 'BmosContext.TblProducts'  is null.");
        }
        public async Task<IActionResult> ChiTiet(string id)
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}