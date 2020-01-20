// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//(function ($, window, document, undefined) {
//    $('#faceFile').each(function () {
//        var $input = $(this),
//            $label = $("input").next('label'),
//            labelVal = $("label").html();
//
//        $input.on('change', function (e) {
//            var fileName = '';
//
//            if (this.files && this.files.length > 1)
//                fileName = (this.getAttribute('data-multiple-caption') || '').replace('{count}', this.files.length);
//            else if (e.target.value)
//                fileName = e.target.value.split('\\').pop();
//
//            if (fileName)
//                $label.find('span').html(fileName);
//            else
//                $label.html(labelVal);
//        });
//
//        // Firefox bug fix
//        $input
//            .on('focus', function () { $input.addClass('has-focus'); })
//            .on('blur', function () { $input.removeClass('has-focus'); });
//    });
//})(jQuery, window, document);

$(document).ready(function () {
    $("#faceFile").change(function () {
        let input = $("#faceFile").val();
        let label = $("#faceFileLabel");
        console.log(input);
        console.log(this.files);
        if (this.files.length > 1) {
            label.text(this.files.length + " files selected");
        } else {
            label.text(this.files[0].name);
        }
    });
});