
// ***************************************************
//             PreLoader By JrC
//****************************************************
window.addEventListener('load', (event) => {
  $(".overlay").fadeOut();
});

$(document).ready(function () {
  // ***************************************************
  //                Navigation On Scrool
  //****************************************************
  let nav = document.querySelector("nav");
  $(window).scroll(function () {
    if ($(window).scrollTop() > 60) {
      nav.classList.add("nav-scroll");
      $(".header-bar").css("padding-bottom", "40px")
    }
    else {
      nav.classList.remove("nav-scroll");
      $(".header-bar").css("padding-bottom", "0px")
    }
  });
  
  
})





  