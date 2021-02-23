//*********************************************************
//                       Add Bookmark
//*********************************************************
let bookmark = document.querySelectorAll(".bookmark-a");
bookmark.forEach((b) => {
    b.addEventListener("click", function () {
        let bookmarId = b.nextElementSibling.value
        bookmark.forEach((b2) => {
            if (b.nextElementSibling.value == b2.nextElementSibling.value) {
                if (b2.children[0].classList.contains("far")) {
                    b2.children[0].classList.replace("far", "fas")
                }
                else {
                    b2.children[0].classList.replace("fas", "far")
                }
            }
        })
        $.ajax({
            url: `/Profile/BookMark/` + bookmarId,
            type: "Post",
        });
    })
})



//*********************************************************
//         Email Validate ready function 
//*********************************************************
function ValidateEmail(email) {
    var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;

    if (email.match(mailformat)) {
        return true;
    }
    else {
        return false;
    }
}


//*********************************************************
//                Send Message to Me  Start
//*********************************************************
$(document).on('click', `#buttonCon`, function () {
    $(`#buttonCon`).prop("disabled", true);
    $("#ConEmailError").empty();
    $("#ConSubjectError").empty();
    $("#ConMessageError").empty();
    $("#ConNameError").empty();
    $("#Form-contact").empty();
    let inputMessageCon = $("#Message-contact").val();
    let inputSubjectCon = $("#Subject-contact").val();
    if (inputMessageCon == 0) {
        let conNullMessage = "Bu xana boş ola bilməz !!!";
        $("#ConMessageError").append(conNullMessage);
        $(`#buttonCon`).prop("disabled", false);
    }
    if (inputSubjectCon == 0) {
        let conNullSubject = "Bu xana boş ola bilməz !!!";
        $("#ConSubjectError").append(conNullSubject);
        $(`#buttonCon`).prop("disabled", false);

    }
    if (userAuthorized) {

        $.ajax({
            url: `/Contact/ContactUs/`,
            data: {
                "Subject": inputSubjectCon,
                "Message": inputMessageCon,
            },
            type: "Post",
            success: function (res) {
                $("#Form-contact").append(res);
                $(`#buttonCon`).prop("disabled", false);
                $("#Message-contact").val("");
                $("#Subject-contact").val("");
            }
        });
    }
    else {

        let inputEmailCon = $("#Email-contact").val();
        let inputNameCon = $("#Name-contact").val();

        if (inputNameCon == 0) {
            let conNullName = "Bu xana boş ola bilməz !!!";
            $("#ConNameError").append(conNullName);
            $(`#buttonCon`).prop("disabled", false);

        }
        if (ValidateEmail(inputEmailCon) == true) {
            console.log("salam")
            $.ajax({
                url: `/Contact/ContactUs/`,
                data: {
                    "Name": inputNameCon,
                    "Email": inputEmailCon,
                    "Subject": inputSubjectCon,
                    "Message": inputMessageCon,
                },
                type: "Post",
                success: function (res) {
                    $("#Form-contact").append(res);
                    $("#Message-contact").val("");
                    $("#Email-contact").val("");
                    $("#Name-contact").val("");
                    $("#Subject-contact").val("");
                    $(`#buttonCon`).prop("disabled", false);


                }
            });

        } else {
            let conNullError = "Zəhmət olmasa Email daxil edin !!!";
            $("#ConEmailError").append(conNullError);
            $(`#buttonCon`).prop("disabled", false);

        }
        //if (inputEmailCon == 0) {
        //    let conNullEmail = "Email can't be empty !!!";
        //    $("#ConEmailError").append(conNullEmail);
        //    $(`#buttonCon`).removeProp("disabled")
        //}



    }
})