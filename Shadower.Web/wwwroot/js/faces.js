$(document).ready(() => {
    $("#faceForm").submit(function (e) {
        e.preventDefault();

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
                } else if (embeddings.length !== 1) {
                    console.log('More than one face found!');
                } else {
                    $.ajax({
                        method: "post",
                        url: '/Home/SearchFace',
                        data: {
                            embedding: embeddings[0]
                        },
                        success: function (posts) {
                            for (let post of posts) {
                                console.log(post.link);
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