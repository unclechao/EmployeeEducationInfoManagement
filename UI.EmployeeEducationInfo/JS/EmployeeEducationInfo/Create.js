//==========page load==========
$(function () {
    $("#createEducation").click(function () {
        $("#createEducationDiv").append("<ul><br/>开始时间<input id='sdate' name='sdate'/>&nbsp&nbsp&nbsp结束时间<input id='edate' name='edate'/>&nbsp&nbsp&nbsp学习经历<input id='eduexp' name='eduexp'/></ul>");
    })
    $("#removeEducation").click(function () {
        $("#createEducationDiv ul:last-child").remove();
    })
    $("#sdate,#edate,#eduexp").focus(function () {
        $("#EducationInfoValidate").text(" ");
    })

    //==========data warning==========
    $("#Name").blur(function () {
        nameValidate();
    })
    $("#Age").blur(function () {
        ageValidate();
        //ageSeniorityLogicValidate();
    })
    $("#Seniority").blur(function () {
        seniorityValidate();
        //ageSeniorityLogicValidate();
    })

    //==========submit validate==========
    $("#submitFade").click(function () {
        var flag = true;
        if ($("#sdate").length > 0 || $("#edate").length > 0 || $("#eduexp").length > 0) {
            var sdateArr = document.getElementsByName("sdate");
            var edateArr = document.getElementsByName("edate");
            var eduexpArr = document.getElementsByName("eduexp");
            for (var i = 0; i < sdateArr.length; i++) {
                var ds = new Date(sdateArr[i].value);
                var de = new Date(edateArr[i].value);
                if (sdateArr[i].value.trim() == "" || edateArr[i].value.trim() == "" || eduexpArr[i].value.trim() == "") {
                    flag = false;
                    $("#EducationInfoValidate").text("请将员工教育信息补充完整！");
                    break;
                }
                else if (ds > de) {
                    flag = false;
                    $("#EducationInfoValidate").text("开始时间不能晚于结束时间！");
                    break;
                }
                else {
                    $("#EducationInfoValidate").text(" ");
                }
            }
        }
        if (!(nameValidate() && ageValidate() && seniorityValidate()))
            flag = false;
        if (flag == true)
            $("#submit").click();
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
        $("#NameValidate").text("请输入员工名称！");
    }
    return flag;
}
function ageValidate() {
    var flag = false;
    var age = $("#Age").val();
    if (age.length <= 0) {
        $("#AgeValidate").text(" ");
        flag = true;
    }
    else {
        if (age > 0) {
            $("#AgeValidate").text("  ");
            flag = true;
        }
        else {
            $("#AgeValidate").text("请输入合理年龄！");
        }
    }
    return flag;
}
function seniorityValidate() {
    var flag = false;
    var seniority = $("#Seniority").val();
    if (seniority.length <= 0) {
        $("#SeniorityValidate").text(" ");
        flag = true;
    }
    else {
        if (seniority > 0) {
            $("#SeniorityValidate").text("  ");
            flag = true;
        }
        else {
            $("#SeniorityValidate").text("请输入合理工龄！");
        }
    }
    return flag;
}
function ageSeniorityLogicValidate() {
    $("#SeniorityValidate").text("  ");
    var flag = true;
    var age = $("#Age").val();
    var seniority = $("#Seniority").val();
    if (age.length > 0 && seniority.length > 0) {
        alert(age);
        alert(seniority);
        alert(age < seniority);
        if (age < seniority) {           
            $("#SeniorityValidate").text("请输入合理工龄！");
            flag = false;
        }
    }
    return flag;
}