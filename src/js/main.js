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
  // ***************************************************
  //                Anouncement file select
  //****************************************************

  // Ajax

  // ***************************************************
  //                Anouncement file select
  //****************************************************
});

// ***************************************************
//                Modal login & register switch
//****************************************************
function SwitchToReg() {
  $(".login-part-modal").css({ transform: "translateX(-1000px)", opacity: "0" });
  $(".register-part-modal").css({ transform: "translateX(-50%)", opacity: "1" });
}
function SwitchToLog() {
  $(".register-part-modal").css({ transform: "translateX(800px)", opacity: "0" });
  $(".login-part-modal").css({ transform: "translateX(-50%)", opacity: "1" });
}

// ***************************************************
//                Modal login & register switch
//****************************************************

var imgs = document.getElementsByClassName("book-detail-img");
var main = document.getElementById("main");
var counter = 0;

for (let i = 0; i < imgs.length; i++) {
  let img = imgs[i];
  img.addEventListener("click", function () {
    main.src = this.src;
  });
}
