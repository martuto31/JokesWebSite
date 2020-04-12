$(document).ready(function () {
        $("a.blueActive").removeClass("blueActive");
        $('a.blueBtn[href="' + location.pathname + '"]').addClass("blueActive");
});

$(document).ready(function () {
    $("button.sortBtnActive").removeClass("sortBtnActive");
    $('button.sortBtn[href="' + location.pathname + '"]').addClass("sortBtnActive");
});


var connection = new signalR.HubConnectionBuilder()
        .withUrl("/MainHub")
        .build();

    connection.on('Liked',
        function (likes, vicId, check) {
            console.log("in liked")
            console.log(check);
            var vic = vicId.toString();
            $("span." + vic).html(likes.toString())
            if (check) {
                $("p." + vicId).html("Благодаря за харесването!");
                setTimeout(function () {
                    $("p." + vicId).fadeIn(400);
                    $("p." + vicId).fadeOut(2500);
                });
                if ($("i." + vicId).hasClass("far fa-thumbs-up")) {
                    console.log("yes");
                    $("i." + vicId).removeClass("far fa-thumbs-up");
                };
                $("i." + vicId).addClass("fas fa-thumbs-up");
            }
            else if (!check) {
                if($("i." + vicId).hasClass("fas fa-thumbs-up")) {
                    console.log("yes");
                    $("i." + vicId).removeClass("fas fa-thumbs-up");
                };
                $("i." + vicId).addClass("far fa-thumbs-up");
            }
        });

    connection.on('Upload',
        function (vicId) {
            $("li." + vicId).html("Успешно качихте вица!");
        });

    connection.on('Delete',
        function (vicId) {
            $("li." + vicId).html("Успешно изтрихте вица!");
        });


    connection.start().then(function () {
        console.log("connected");
    });

$(".like-button").click(function () {
        var VicId = $(this).data("id");
        console.log(parseInt(VicId));
        connection.invoke("Like", parseInt(VicId)).catch(function (err) {
            return console.error(err.toString());
        });
});

$(".upload").click(function () {
    var VicId = $(this).data("id");
    connection.invoke("UploadVic", parseInt(VicId)).catch(function (err) {
        return console.error(err.toString());
    });
});

$(".delete").click(function () {
    var VicId = $(this).data("id");
    connection.invoke("DeleteVic", parseInt(VicId)).catch(function (err) {
        return console.error(err.toString());
    });
});


    //e.preventDefault();

//$(function () {

//    if ($(".like-button").size() > 0) {
//        var vicClient = $.connection.VotingHub;

//        vicClient.on('Liked',
//            function (vicPoints, vicId) {
//            var counter = $(".like-count");
//                $(counter).fadeOut(function (vicPoints, vicId) {
//                    $(this).text(vicPoints);
//                    $(this).fadeIn();
//                });
//        });

//        $(".like-button").on("click", function () {
//            var code = $(this).attr("data-id");
//            vicClient.server.like(code);
//        });

//        $.connection.hub.start();
//    }

//});