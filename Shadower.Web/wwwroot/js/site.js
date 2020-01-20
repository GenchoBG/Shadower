// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function handleFileSelect() {
    //Check File API support
    if (window.File && window.FileList && window.FileReader) {

        var files = event.target.files; //FileList object
        
        var file = files[0];
        //Only pics
        if (!file.type.match('image')) {
            alert("error");
        }

        var picReader = new FileReader();
        picReader.addEventListener("load", function (event) {
            var picFile = event.target;
            var div = $("#form-header-content");
            var image = $("<img class='thumbnail' alt='pic' src='" + picFile.result + "'" + "title='" + file.name + "'/>")

            image.ready(function(parameters) {
                div.append(image);
               
                var box = $("#form-header");
                image.width(box.width() - parseInt($("#form-header-content").css("padding-left")) * 2);

                box.animate({ height: "+=" + image.height + "px" }, 1000);
            });
        });

        

        //Read the image
        picReader.readAsDataURL(file);
    } else {
        console.log("Your browser does not support File API");
    }
}

$(document).ready(function () {
    $("#faceFile").change(function () {
        let input = $("#faceFile").val();
        let label = $("#faceFileLabel");
        console.log(input);
        console.log(this.files);

        label.text(this.files[0].name);

        handleFileSelect();
    });

    
});