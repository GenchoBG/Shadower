$(document).ready(() => {
    $("#faceForm").submit(function (e) {
        e.preventDefault();

        const facesApiUrl = "http://94.156.180.190/getembeddings";
        for (var key of new FormData(this).keys()) {
            console.log(key);
        }

        console.log($('#faceFile')[0]);

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