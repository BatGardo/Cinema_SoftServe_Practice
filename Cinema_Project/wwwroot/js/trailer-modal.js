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
        /*setTimeout(function () {
            videoPlayer.play(); // Воспроизведение видео
        }, 1000); // задержка 3 секунды*/
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

document.addEventListener('DOMContentLoaded', function () {
    const modal = document.getElementById('myModal');
    const closeModal = document.getElementById('btn_watch_close');

    document.querySelectorAll('.activate-modal').forEach(button => {
        button.addEventListener('click', function () {
            const movieId = this.getAttribute('data-movie-id');
            const title = this.getAttribute('data-title');
            const rating = this.getAttribute('data-rating');
            const categories = this.getAttribute('data-categories');
            const year = this.getAttribute('data-year');
            const duration = this.getAttribute('data-duration');
            const stars = this.getAttribute('data-stars');
            const description = this.getAttribute('data-description');
            
            document.getElementById('modalTitle').textContent = title;
            document.getElementById('modalRating').textContent = rating;
            document.getElementById('modalCategories').textContent = categories;
            document.getElementById('modalYear').textContent = year;
            document.getElementById('modalDuration').textContent = duration;
            document.getElementById('modalStars').textContent = stars;
            document.getElementById('modalDescription').textContent = description;

            const youtubelink = this.getAttribute('data-youtubelink');
            const youtubelink1 = `${youtubelink}`;
            alert(youtubelink1);
            document.getElementById('videoPlayer').src = youtubelink1;

            const imagePath = `/img_posters/${title}/${title}_SP.jpg`;
            document.getElementById('modalImageTag').src = imagePath;

            modal.style.display = 'block';
        });
    });

    closeModal.addEventListener('click', function () {
        modal.style.display = 'none';
    });

    window.addEventListener('click', function (event) {
        if (event.target == modal) {
            modal.style.display = 'none';
        }
    });
});