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
    const closeModal = document.querySelector('.close');

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
                    console.log(data);
                    document.querySelector('.modal-film-info .film-name').textContent = data.title;
                    document.querySelector('.modal-film-info .film-elem:nth-child(2)').innerHTML = `<b>Жанр: </b>${data.genres}`;
                    document.querySelector('.modal-film-info .film-elem:nth-child(3)').innerHTML = `<b>Дата виходу: </b>${data.releaseDate}`;
                    document.querySelector('.modal-film-info .film-elem:nth-child(4)').innerHTML = `<b>Тривалість: </b>${data.duration}`;
                    document.querySelector('.modal-film-info .film-elem:nth-child(5)').innerHTML = `<b>У головних ролях: </b>${data.stars}`;
                    document.querySelector('.modal-film-info .film-elem:nth-child(6)').innerHTML = `<b>Опис: </b>${data.description}`;
                    document.querySelector('.modal-film-side .film-rating').textContent = data.rating;
                    document.querySelector('.modal-film-side img').src = data.posterUrl;
                    document.getElementById('videoPlayer').src = data.trailerUrl;
                    document.getElementById('linkcurrent').setAttribute('href', `/Booking/BookingView?movieId=` + data.movieId);

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
