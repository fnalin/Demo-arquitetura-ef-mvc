(function () {
    //mais informações www.html5rocks.com/pt/tutorials/file/dndfiles/

    if (window.File && window.FileReader) {
        $("#foto-aluno-div figure").on("click", function () {
            $("#file").val("").click();
        });

        $("#file").on("click", function () {
            $("#foto-aluno-div img").attr("src", fotoAnonymous);
            $("#FotoNome").val("");
            $("#foto-aluno-div figcaption").remove();
        });

        $("#file").on("change", function (evt) {
            var file = evt.target.files[0];

            if (!file.type.match('image.*')) {
                $("#file").val("");
                return false;
            }

            $("#FotoNome").val(file.name);

            var reader = new FileReader();
            reader.onload = (function () {
                return function (e) {
                    $("div.validation-summary-errors").empty();
                    $("#foto-aluno-div img").attr("src", e.target.result);
                };
            })(file);

                   

            reader.readAsDataURL(file);
        });
    } else {
        console.log('API não suportada!');
    }
})();