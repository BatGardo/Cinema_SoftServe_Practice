var buttons = document.querySelectorAll(".film-trailer-button"); // Виберіть всі елементи з класом "film-trailer-button"
var modal = document.getElementById("myModal");
var span = document.getElementsByClassName("close")[0];
var videoPlayer = document.getElementById("videoPlayer");
videoPlayer.volume = 0.5;

// Додайте обробник подій до кожного елемента з класом "film-trailer-button"
buttons.forEach(function(button) {
    button.onclick = function() {
        modal.style.display = "block";
        document.body.style.overflow = "hidden"; // блокування прокрутки
        videoPlayer.play(); // Відтворення відео
    }
});

span.onclick = function() {
    modal.style.display = "none";
    document.body.style.overflow = ""; // знову дозволяє прокрутку
    videoPlayer.pause(); // Призупинити відтворення відео
}
