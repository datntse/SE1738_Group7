$(document).ready(function(){
    $('.product-warpper').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        infinite: false,
        arrows: true,
        prevArrow:"<button type='button' class='slick-prev pull-left'><i class='fa fa-angle-left' aria-hidden='true'></i></button>",
        nextArrow:"<button type='button' class='slick-next pull-right'><i class='fa fa-angle-right' aria-hidden='true'></i></button>"
      });


      $('.banner-warpper').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        infinite: false,
        arrows: false,
        autoplay: true,
        autoplaySpeed: 1000,
        infinite: true,
      });

      $('.blog-warpper').slick({
        slidesToShow: 4,
        slidesToScroll: 1,
        infinite: false,
        arrows: false,
        autoplay: true,
        autoplaySpeed: 1000,
        infinite: true,
        arrows: false,
        dots: true,
        prevArrow:"<button type='button' class='slick-prev pull-left'><i class='fa fa-angle-left' aria-hidden='true'></i></button>",
        nextArrow:"<button type='button' class='slick-next pull-right'><i class='fa fa-angle-right' aria-hidden='true'></i></button>"
      });

      $('.meal-wrapper').slick({
        slidesToShow: 4,
        slidesToScroll: 4,
        arrows: false,
        autoplay: true,
        autoplaySpeed: 2000,
        infinite: false,
        arrows: true,
        prevArrow:"<button type='button' class='slick-prev pull-left'><i class='fa fa-angle-left' aria-hidden='true'></i></button>",
        nextArrow:"<button type='button' class='slick-next pull-right'><i class='fa fa-angle-right' aria-hidden='true'></i></button>"
      });
      $('.bloglist-wrapper').slick({
        slidesToShow: 4,
        slidesToScroll: 4,
        arrows: false,
        autoplay: false,
        autoplaySpeed: 2000,
        infinite: false,
        arrows: false,
        prevArrow:"<button type='button' class='slick-prev pull-left'><i class='fa fa-angle-left' aria-hidden='true'></i></button>",
        nextArrow:"<button type='button' class='slick-next pull-right'><i class='fa fa-angle-right' aria-hidden='true'></i></button>"
      });

  });

  function increaseValue() {
    var value = parseInt(document.getElementById('number').value, 10);
    value = isNaN(value) ? 0 : value;
    value++;
    document.getElementById('number').value = value;
  }
  
  function decreaseValue() {
    var value = parseInt(document.getElementById('number').value, 10);
    value = isNaN(value) ? 0 : value;
    value < 1 ? value = 1 : '';
    value--;
    document.getElementById('number').value = value;
  }