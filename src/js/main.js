
$(document).ready(function () {
  // ***************************************************
  //                Navigation On Scrool
  //****************************************************
  let nav = document.querySelector("nav");
  $(window).scroll(function(){
    if($(window).scrollTop()>60){
      nav.classList.add("nav-scrool");
      $(".header-content").css("padding-top","150px")
    }
    else{
      nav.classList.remove("nav-scrool");
      $(".header-content").css("padding-top","100px")
    }
  });


  // ***************************************************
  //                Selected On Scrool
  //****************************************************
  let selected= $(".selected")
  $(window).scroll(function(){
    if($(window).scrollTop()>400 ){
    $("#Selected").css("transform","translateX(0)")
    $("#Selected").css("transition","0.5s")
    }
    else{
    $("#Selected").css("transform","translateX(100px)")
    $("#Selected").css("transition","0.5s")
    $(".selected-box").removeClass("show")
    $(".selected-box i").css("fontSize","0px")
    $(".selected-box a").css("width","0px")
    }
  });

  
  // ***************************************************
  //                Selected On Scrool
  //****************************************************
  selected.click(function () {
  if(!$(".selected-box").hasClass("show"))
   {
    $(".selected-box").addClass("show")
    $(".selected-box i").css("fontSize","60px")
    $(".selected-box a").css("width","80px")
   }
   else
   {
    $(".selected-box").removeClass("show")
    $(".selected-box i").css("fontSize","0px")
    $(".selected-box a").css("width","0px")
   }
  })
   

  // ***************************************************
  //             Active Profile Carousel
  //****************************************************
 $('.owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
    responsive:{
        0:{
            items:1
        },
        400:{
            items:3
        },
        1000:{
            items:5
        }
    }
  })


})


  // ***************************************************
  //             PreLoader By JrC
  //****************************************************
window.addEventListener('load', (event) => {
  $(".overlay").fadeOut();
});




  