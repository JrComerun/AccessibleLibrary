if ($(window).width() < 1200) {
  // ***************************************************
  //                 Mobile Card Version
  //****************************************************
  $(".mob-book").addClass("book-desk")
  $(".mob-book").removeClass("book-mob")

  $(document).ready(function () {
    // ***************************************************
    //          Mobile Main Navigation on Button
    //****************************************************
    let openNav = $("#Nav-open-btn")
    let closeNav = $("#Nav-close-btn")

    openNav.click(function (e) {
      $("#nav-mobile-1").addClass("show")
      if ($("#cat-mobile").hasClass("show")) {
        $("#cat-mobile").removeClass("show")
      }
      e.stopPropagation();
    })
    closeNav.click(function () {
      $("#nav-mobile-1").removeClass("show")
    })
    //*********      close btn on html click   ***********
    $('html').click(function () {
      if ($("#nav-mobile-1").hasClass("show")) {
        $("#nav-mobile-1").removeClass("show")
      }
    });

    // ***************************************************
    //            Add Book Navigation on Scrool
    //****************************************************
    let nav = document.querySelector("#nav-mobile-2");
    $(window).scroll(function () {
      if ($(window).scrollTop() > 120) {
        nav.classList.add("nav-scroll2");
      }
      else {
        nav.classList.remove("nav-scroll2");
      }
    });


    // ***************************************************
    //            Categories Mobile  on Button
    //****************************************************
    let openCat = $(".filter")
    let closeCat = $("#Cat-close-btn")

    openCat.click(function (e) {
      $("#cat-mobile").addClass("show")
      if ($("#nav-mobile-1").hasClass("show")) {
        $("#nav-mobile-1").removeClass("show")
      }
      e.stopPropagation();
    })
    closeCat.click(function () {
      $("#cat-mobile").removeClass("show")
    })
    //*********      close btn on html click   ***********
    $('html').click(function () {
      if ($("#cat-mobile").hasClass("show")) {
        $("#cat-mobile").removeClass("show")
      }
    });
  })
}
