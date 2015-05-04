//==========page load==========
$(function () {
    $("#clear").click(function () {
        $("#Name").val("");
        $("#Password").val("");
    })
    $("#register").click(function () {
        //rediect to register page 
        location.href = "Home/Register";
    })

    //==========data warning==========
    $("#Name").blur(function () {
        nameValidate();
    })
    $("#Password").blur(function () {
        passwordValidate();
    })

    //==========submit validate==========
    $("#submitFade").click(function () {
        var flag = true;
        if (!(nameValidate() && passwordValidate()))
            flag = false;
        if (flag == true) {
            $("#submit").click();
        }
    })
})

//==========validate function==========
function nameValidate() {
    var flag = false;
    var name = $("#Name").val().trim();
    if (name != "") {
        $("#NameValidate").text("*");
        flag = true;
    }
    else {
        $("#NameValidate").text("请输入管理员名称！");
    }
    return flag;
}
function passwordValidate() {
    var flag = false;
    var password = $("#Password").val().trim();
    if (password != "") {
        $("#PasswordValidate").text("*");
        flag = true;
    }
    else {
        $("#PasswordValidate").text("请输入管理员密码！");
    }
    return flag;
}