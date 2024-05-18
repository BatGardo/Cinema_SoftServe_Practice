var buttons = document.querySelectorAll(".activate-modal"); // Виберіть всі елементи з класом "film-trailer-button"

var btn_watch_open = document.getElementById("film-trailer-button");
var btn_watch_close = document.getElementById("btn_watch_close");

var modal = document.getElementById("myModal");
var span = document.getElementsByClassName("close")[0];
var videoPlayer = document.getElementById("videoPlayer");
videoPlayer.volume = 0.5;

// Додайте обробник подій до кожного елемента з класом "film-trailer-button"
buttons.forEach(function (button) {
    button.onclick = function () {
        modal.style.opacity = "1";
        modal.style.zIndex = "3";
        document.body.style.overflow = "hidden"; // блокирование прокрутки
        setTimeout(function () {
            videoPlayer.play(); // Воспроизведение видео
        }, 1000); // задержка 3 секунды
    }
});

span.onclick = function () {
    modal.style.opacity = "0";
    document.body.style.overflow = ""; // знову дозволяє прокрутку
    videoPlayer.pause(); // Призупинити відтворення відео
    setTimeout(function () {
        modal.style.zIndex = "-1"; // Воспроизведение видео
    }, 1000);
}