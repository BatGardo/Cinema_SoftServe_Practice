var buttons = document.querySelectorAll(".activate-modal"); // Виберіть всі елементи з класом "film-trailer-button"

var btn_watch_open = document.getElementById("film-trailer-button");
var btn_watch_close = document.getElementById("btn_watch_close");
var overlay = document.getElementById("overlay");
var modal = document.getElementById("myModal");
var closeModal = document.getElementsByClassName("close")[0];
var videoPlayer = document.getElementById("videoPlayer");
videoPlayer.volume = 0.5;

// Додайте обробник подій до кожного елемента з класом "film-trailer-button"
buttons.forEach(function (button) {
    button.onclick = function () {
        modal.style.opacity = "1";
        modal.style.zIndex = "4";
        overlay.style.opacity = "1";
        overlay.style.zIndex = "3";
        overlay.style.pointerEvents = "auto"; // дозволяє кліки
        document.body.style.overflow = "hidden"; // блокування прокрутки

        setTimeout(function () {
            if (videoPlayer.contentWindow && videoPlayer.contentWindow.postMessage) {
                videoPlayer.contentWindow.postMessage('{"event":"command","func":"' + 'playVideo' + '","args":""}', '*');
            }
        }, 1000); 
    }
});

closeModal.onclick = function () {
    modal.style.opacity = "0";
    overlay.style.opacity = "0";
    document.body.style.overflow = ""; // знову дозволяє прокрутку
    modal.style.zIndex = "-1";
    overlay.style.zIndex = "-1";
    console.log('Modal zIndex:', modal.style.zIndex);
    console.log('Overlay zIndex:', overlay.style.zIndex);
    console.log('Overlay pointerEvents:', overlay.style.pointerEvents);
    setTimeout(function () {
        overlay.style.pointerEvents = "none"; // блокує кліки
    }, 1000);
}



document.addEventListener('DOMContentLoaded', function () {

    document.querySelectorAll('.activate-modal').forEach(button => {
        button.addEventListener('click', function () {
            const movieTitle = this.getAttribute('data-title');

            fetch(`/Search/GetMovieDetailsByTitle?title=${encodeURIComponent(movieTitle)}`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    document.querySelector('.modal-film-info .film-name').textContent = data.title;
                    document.querySelector('.modal-film-info .film-elem:nth-child(2)').innerHTML = `<b>Жанр: </b>${data.genres}`;
                    document.querySelector('.modal-film-info .film-elem:nth-child(3)').innerHTML = `<b>Дата виходу: </b>${data.releaseDate}`;
                    document.querySelector('.modal-film-info .film-elem:nth-child(4)').innerHTML = `<b>Тривалість: </b>${data.duration}`;
                    document.querySelector('.modal-film-info .film-elem:nth-child(5)').innerHTML = `<b>У головних ролях: </b>${data.stars}`;
                    document.querySelector('.modal-film-info .film-elem:nth-child(6)').innerHTML = `<b>Опис: </b>${data.description}`;
                    document.querySelector('.modal-film-side .film-rating').textContent = `${data.rating} ⭐️`;
                    document.querySelector('.modal-film-side img').src = data.posterUrl;
                    document.getElementById('videoPlayer').src = data.trailerUrl;

                    modal.style.display = 'block';
                })
                .catch(error => console.error('Error fetching movie details:', error));
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
