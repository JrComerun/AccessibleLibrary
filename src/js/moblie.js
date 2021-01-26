let openNav = $("#Nav-open-btn")
let closeNav = $("#Nav-close-btn")
$(document).ready(function () {
    openNav.click(function () {
        $("#nav-mobile").css("transform","translateX(0%)")
        $("#nav-mobile").css("transition","ease 0.7s")
    })
    closeNav.click(function () {
        $("#nav-mobile").css("transform","translateX(100%)")
        $("#nav-mobile").css("transition","ease 0.7s")
    })
})