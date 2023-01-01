$(document).ready(function () {
  if ($("#maslahat-detail-slider").length > 0) {
    $("#maslahat-detail-slider").owlCarousel({
      items: 1,
      loop: true,
      dots: false,
      margin: 15,
      nav: true,
      autoplay: true,
      autoplayHoverPause: false,
      autoplayTimeout: 5000,
      smartSpeed: 800,
      navText: [
        '<i class="bi bi-chevron-left"></i>',
        '<i class="bi bi-chevron-right"></i>',
      ],
    });
  }

  if ($(".home-mahsul-slider").length > 0) {
    $(".home-mahsul-slider").owlCarousel({
      items: 4,
      loop: false,
      dots: false,
      margin: 30,
      nav: true,
      autoplay: true,
      autoplayHoverPause: false,
      autoplayTimeout: 5000,
      smartSpeed: 800,
      navText: [
        '<i class="bi bi-chevron-left"></i>',
        '<i class="bi bi-chevron-right"></i>',
      ],
      responsive: {
        0: {
            items: 2,
            stagePadding: 50,
        },
        685: {
            items: 2,
            stagePadding: 50,
        },
        992: {
            items: 3,
        },
        1200: {
            items: 3,
        },
        1210: {
          items: 4,
         },
        1600: {
            items: 4,
        },
    },
    });
  }
  if ($(".home-slider").length > 0) {
    $(".home-slider").owlCarousel({
      items: 1,
      loop: true,
      dots: false,
      margin: 0,
      nav: true,
      autoplay: false,
      autoplayHoverPause: false,
      autoplayTimeout: 5000,
      smartSpeed: 800,
      navText: [
        '<i class="bi bi-chevron-left"></i>',
        '<i class="bi bi-chevron-right"></i>',
      ],
    });
  }
  

  $(".mahsullar > .dropdown-menu").hover(function () {
    $(".mahsullar > .nav-link").addClass("active");
  });

  $(".mahsullar > .dropdown-menu").mouseleave(function () {
    $(".mahsullar > .nav-link").removeClass("active");
  });

  $(".down-lang > .dropdown-menu").hover(function () {
    $(".down-lang > .nav-link").addClass("active");
  });

  $(".down-lang > .dropdown-menu").mouseleave(function () {
    $(".down-lang > .nav-link").removeClass("active");
  });

  /// Menü Açılımı
  $(".navicon").on("click", function () {
    $(this).toggleClass("navicon--active");
    $(".navbar-collapse").toggleClass("navbar-collapse--active");
    $("body").toggleClass("overflow");
    $(".overlay-body").toggle();
  });

  // sitedeki tüm dropdownları calıştırma  özelliği

  $(".js-down > li").click(function () {
    $(this).parent().prev().find("span").text($(this).text());
  });

  //dropdown ok toggle yönü
  $(".dropdown > .btn").on("show.bs.dropdown", function () {
    $(this).children(".bi-chevron-down").toggleClass("rotate-90");
  });

  $(".dropdown > .btn").on("hidden.bs.dropdown", function () {
    $(".bi-chevron-down").removeClass("rotate-90");
  });

  $(".secim-item").click( function () {
    let dataid = $(this).attr("data-id");
    $(".secim-item").removeClass("active");
    $(".mahsul-detay-img").addClass("active");
    $(this).addClass("active");
  });
});
