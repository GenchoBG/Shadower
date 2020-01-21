$(document).ready(() => {
    $("#faceFile").change(function () {
        let label = $("#faceFileLabel");

        label.text(this.files[0].name);

        handleFileSelect();
    });
    var banner = $("#banner");
    $(".modal-body").children().hide();
    banner.show();

    $("#faceForm").submit(function (e) {
        e.preventDefault();
        $("#toggleResult").trigger("click");

		const facesApiUrl = "http://94.156.180.190:80/getembeddings";
        var formData = new FormData();
        formData.append('face', $('#faceFile')[0].files[0]);

        $.ajax({
            url: facesApiUrl,
            method: "post",
            data: formData,
            contentType: false,
            processData: false,
            crossDomain: true,
            cache: false,
            success: function (embeddings) {
                if (embeddings.length === 0) {
                    console.log('No face found!');
                    banner.hide();
                    $("#nothingFound").show();
                } else if (embeddings.length !== 1) {
                    console.log('More than one face found!');
                    banner.hide();
                    $("#moreThanOne").show();
                } else {
                    $.ajax({
                        method: "post",
                        url: '/Home/SearchFace',
                        data: {
                            embedding: embeddings[0]
                        },
                        success: function (posts) {
                            banner.hide();
                            var postsTable = $("#posts");
                            var i = 1;
                            for (let post of posts) {
                                postsTable.append($(`<tr>
                                                        <th scope="row">${i}</th>
                                                        <td>${post.link}</td>
                                                    </tr>`));
                                console.log(post.link);
                                i++;
                            }
                        },
                        error: function (req, status, err) {
                            console.log("something went wrong");
                            console.log(status);
                            console.log(err);
                            console.log(req);
                        }
                    });

                    console.log('All is good! One face found');
                }

                console.log(embeddings);
            },
            error: function (req, status, err) {
                console.log("something went wrong");
                console.log(status);
                console.log(err);
                console.log(req);
            }
        });
    });
});

function handleFileSelect() {
    //Check File API support
    if ($(".thumbnail")) {
        $(".thumbnail").remove();
    }

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

            image.ready(function (parameters) {
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