//==========page load==========
$(function () {
    $("#createEducation").click(function () {
        $("#createEducationDiv").append("<ul><br/>开始时间<input id='sdate' name='sdate'/>&nbsp&nbsp&nbsp结束时间<input id='edate' name='edate'/>&nbsp&nbsp&nbsp学习经历<input id='eduexp' name='eduexp'/></ul>");
    })
    $("#removeEducation").click(function () {
        $("#createEducationDiv ul:last-child").remove();
    })

    //==========data warning==========
    $("#Name").blur(function () {
        nameValidate();
    })
    $("#Age").blur(function () {
        ageValidate();
    })
    $("#Seniority").blur(function () {
        seniorityValidate();
    })
    $("#EducationInfo_StartTime,#EducationInfo_EndTime,#EducationInfo_Education").focus(function () {
        $("#EducationInfoValidate").text(" ");
    })

    //==========submit validate==========
    $("#submitFade").click(function () {
        var flag = true;

        if ($("#EducationInfo_StartTime").length >= 0 || $("#EducationInfo_EndTime").length >= 0 || $("#EducationInfo_Education").length >= 0) {
            var sdateArr = document.getElementsByName("EducationInfo.StartTime");
            var edateArr = document.getElementsByName("EducationInfo.EndTime");
            var eduexpArr = document.getElementsByName("EducationInfo.Education");
            for (var i = 0; i < sdateArr.length; i++) {
                var ds = new Date(sdateArr[i].value);
                var de = new Date(edateArr[i].value);
                if (sdateArr[i].value.trim() == "" || edateArr[i].value.trim() == "" || eduexpArr[i].value.trim() == "") {
                    flag = false;
                    $("#EducationInfoValidate").text("请将员工教育信息补充完整！");
                }
                else if (ds > de) {
                    flag = false;
                    $("#EducationInfoValidate").text("开始时间不能晚于结束时间！");
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
        if (seniority >= 0) {
            $("#SeniorityValidate").text("  ");
            flag = true;
        }
        else {
            $("#SeniorityValidate").text("请输入合理工龄！");
        }
    }
    return flag;
}