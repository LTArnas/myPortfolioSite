/// <reference path="~/Scripts/jquery-2.1.4.intellisense.js />
var mobileWidthBreakpoint = 768;

$(function () {
    if ($().width() <= mobileWidthBreakpoint) {
        $('.navbar-dropdown-toggle').toggleClass('disabled');

        $('.dropdown').hover(function () {
            $(this).toggleClass("open");

            $('.navbar-dropdown-toggle').attr("aria-expanded",
                function (i, attr) {
                    return attr == 'false' ? 'true' : 'false';
                })
            //$('.navbar-dropdown-toggle').dropdown('toggle');
        }) // endHover
    } // endIf
})