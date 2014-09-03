//(function ($) {
//    $.fn.center = function () {
//        var top = ($(window).height() - this.height()) / 2;
//        var left = ($(window).width() - this.width()) / 2;
//        var scrollTop = $(document).scrollTop();
//        var scrollLeft = $(document).scrollLeft();
//        return this.css({ position: 'absolute', 'top': top + scrollTop, left: left + scrollLeft }).show();
//    }
//})(jQuery);
//function showBig(e) {
//    var big = $("#bigImg"), width = $(window).width(), height = $(window).height(), src = $(e.target).attr("src");
//    big.attr("src", src.replace('GetSmallImage', 'GetImage')).lightbox();
//    //.css({ "height": height, "width": width });
//    //$("#showBigImg").css({ "height": height, "width": width }).center().show();

//}

//function hiddenBig() {
//    $("#showBigImg").hide();
//}
$(document).ready(function () {
    $(window).scroll(function () {

        var totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
        if ($(document).height() <= totalheight) {
            $.post("/Info/GetInfoByPage?id=" + $("#pageNum").val(), function (data) {
                $("#tbodyInfo").append(data);
                $("#pageNum").val(parseInt($("#pageNum").val()) + 1)
            });
        }
    });
})


function beforeLoad() {
    $("#msg").fadeIn("slow");
    $("#tbodyInfo").html("");
}
function afterLoad(data) {
    //console.log(data.length);
    //var data
    if ($.trim(data)!=="") {
        $("#tbodyInfo").html(data);
    } else {
        $("#tbodyInfo").html("<tr><td colspan='11' style='color:red'>没有查找到符合条件的数据</td></tr>");
    }
    $(window).unbind("scroll");
    $("#msg").fadeOut();
}