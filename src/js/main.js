// ***************************************************
//             PreLoader By JrC
//****************************************************
window.addEventListener("load", (event) => {
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
      $(".header-bar").css("padding-bottom", "40px");
    } else {
      nav.classList.remove("nav-scroll");
      $(".header-bar").css("padding-bottom", "0px");
    }
  });
<<<<<<< HEAD
  // ***************************************************
  //                Modal login & register switch
  //****************************************************
});
function SwitchToReg() {
  $(".login-part-modal").css({ transform: "translateX(-1000px)", opacity: "0" });
  $(".register-part-modal").css({ transform: "translateX(-50%)", opacity: "1" });
}
function SwitchToLog() {
  $(".register-part-modal").css({ transform: "translateX(800px)", opacity: "0" });
  $(".login-part-modal").css({ transform: "translateX(-50%)", opacity: "1" });
}
=======
  
  
})





  
>>>>>>> 63960b774f163293856c74b0d5e307e0a0b244b7
