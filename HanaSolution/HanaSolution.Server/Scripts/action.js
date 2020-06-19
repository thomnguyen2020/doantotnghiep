
function LoginModel(username, password, remember) {
    var t = this;
    t.Username = username;
    t.Password = password;
    t.IsRemember = remember;
}
function Login() {
    var user = $("#inp_Username").val();
    var pass = $("#inp_Password").val();
    var remember = false;

    if ($("#inp_Remember").val() === "forever")
        remember = true;
    else
        remember = false;

    var data = JSON.stringify(new LoginModel(user, pass, remember));
    $.ajax({
        method: 'POST',
        url: '/System/Login',
        data: data,
        datatype: "application/json",
        contentType: "application/json",
        success: function (result) {
            //alert(JSON.stringify(result));
            if (result.Status !== undefined && result.Status === '-1') {
                showErrorMessage(result.Message);
            }
            else {
                showSuccess('Chúc mừng, bạn đã đăng nhập thành công');
                //setCookie('VendorInfo', result, 360);
                location.href = window.location.href.replace(window.location.pathname, '/');
            }
        },
        error: function (error) {
            showErrorMessage('Hệ thống đang bận, vui lòng thử lại sau');
        }
    });
}
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
function ReplyView(comment, feedbackid) {
    var t = this;
    t.Feedback = feedbackid;
    t.Comment = comment;
    t.Date = null;
}
function ReplyAdd(id) {
    var comment = $("#txtComment").val();
    var data = JSON.stringify(new ReplyView(comment, id));
    $.ajax({
        method: 'POST',
        url: '/Product/AddReply',
        data: data,
        datatype: "application/json",
        contentType: "application/json",
        success: function (result) {
            //alert(JSON.stringify(result));
            if (result.Status !== undefined && result.Status === '-1') {
                showErrorMessage(result.Message);
            }
            else {
                showSuccess('Gửi trả lời thành công');
                //setCookie('VendorInfo', result, 360);
                $("#txtComment").val('');
                location.reload();
            }
        },
        error: function (error) {
            showErrorMessage('Hệ thống đang bận, vui lòng thử lại sau');
        }
    });
}