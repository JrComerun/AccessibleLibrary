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
    //                Selected On Scrool
    //****************************************************
    $(window).scroll(function () {
        if ($(window).scrollTop() > 200) {
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


    // ***************************************************
    //               Child Category Show
    //****************************************************
    let Categories = document.querySelectorAll(".main-category")
    let childCategories = document.querySelectorAll(".childCategories")
    Categories.forEach((e) => {
        e.addEventListener("click", function () {
            this.nextElementSibling.classList.add("show")
        })
    })
    childCategories.forEach((a) => {
        document.body.addEventListener("click", function () {
            if (a.classList.contains("show")) {
                a.classList.remove("show")
            }
        }, true)
    })
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
//                Book Detail switch Image
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
