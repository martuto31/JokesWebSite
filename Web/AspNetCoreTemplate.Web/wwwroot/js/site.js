// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $(document).ready(function () {
        $("a.blueActive").removeClass("blueActive");
        $('a.blueBtn[href="' + location.pathname + '"]').addClass("blueActive");
    });

    $(document).ready(function () {
        $("a.navActive").removeClass("navActive");
        $('a.nav-link').addClass("navActive");
    });