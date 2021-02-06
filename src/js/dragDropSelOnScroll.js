$(document).ready(function () {
  // ***************************************************
  //                Selected On Scrool
  //****************************************************

  $(window).scroll(function () {
    if ($(window).scrollTop() > 400) {
      $(".select-holder").css("transform", "translateX(0)");
      $(".select-holder").css("transition", "0.5s");
    } else {
      $(".select-holder").css("transform", "translateX(100px)");
      $(".select-holder").css("transition", "0.5s");
      $(".selected-box").removeClass("show");
      $(".selected-box i").css("fontSize", "0px");
      $(".selected-box a").css("width", "0px");
    }
  });

  // ***************************************************
  //                Selected On Scrool
  //****************************************************
  $(".selected").click(function () {
    if (!$(this).next().hasClass("show")) {
      $(this).next().addClass("show");
      $(this).next().find("a").css("width", "100%");
    } else {
      $(this).next().removeClass("show");
      $(this).next().find("a").css("width", "0px");
    }
  });
});
