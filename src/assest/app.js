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
        // autoplay: true,
        // autoplaySpeed: 1000,
        infinite: true,
        arrows: true,
        prevArrow:"<button type='button' class='slick-prev pull-left'><i class='fa fa-angle-left' aria-hidden='true'></i></button>",
        nextArrow:"<button type='button' class='slick-next pull-right'><i class='fa fa-angle-right' aria-hidden='true'></i></button>"
      });
  });