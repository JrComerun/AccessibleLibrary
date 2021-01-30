$(document).ready(function () {
    // ***************************************************
    //                Navigation On Scrool
    //****************************************************
    let nav = document.querySelector("nav");
    $(window).scroll(function () {
        if ($(window).scrollTop() > 60) {
            nav.classList.add("nav-scroll");
            $(".header-content").css("padding-top", "140px")
        }
        else {
            nav.classList.remove("nav-scroll");
            $(".header-content").css("padding-top", "100px")
        }
    });
})