    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/VotingHub")
        .build();

    connection.on('Liked',
        function (likes, vicId) {
            console.log("in liked")
            console.log(likes);
            var vic = vicId.toString();
            $("span." + vic).html(likes.toString())
            $("p." + vicId).html("Успешно гласувахте за вица!");
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