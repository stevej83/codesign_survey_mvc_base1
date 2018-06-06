$(function () {
    alert("test");
    fGetQRCode1();
})
function fGetQRCode1() {
    $.ajax({
        type: "post",
        //url: "/Home/GetQRCode1",
        url: "/Surveys/S1Page1",
        data: {
            time: new Date(),
            productId: 123456789
        },
        success: function (json) {
            if (json.result) {
                $('#QRCode1').qrcode(json.str); //生成二维码
            }
            else {
                $('#QRCode1').html("二维码生成失败");
            }
        }
    })
}