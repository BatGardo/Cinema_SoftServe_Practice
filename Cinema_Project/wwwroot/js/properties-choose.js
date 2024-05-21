document.querySelectorAll('.properties-droplist').forEach(droplist => {
    droplist.addEventListener('click', function (event) {
        if (event.target.classList.contains('properties-droplist-elem')) {
            droplist.querySelectorAll('.properties-droplist-elem').forEach(elem => {
                elem.classList.remove('elem-active');
            });

            event.target.classList.add('elem-active');

            const sortBy = event.target.getAttribute('data-sort');
            sortMovies(sortBy);
        }
    });
});

function sortMovies(sortBy) {
    const filmsContainer = document.querySelector('.FilmContainer');
    const filmsRows = Array.from(filmsContainer.querySelectorAll('.films-row'));

    filmsRows.forEach(row => {
        const films = Array.from(row.querySelectorAll('.film-search-elem'));

        films.sort((a, b) => {
            if (sortBy === 'title') {
                const titleA = a.querySelector('.film-elem-name').textContent.trim().toLowerCase();
                const titleB = b.querySelector('.film-elem-name').textContent.trim().toLowerCase();
                return titleA.localeCompare(titleB);
            } else if (sortBy === 'popularity') {
                const ratingA = parseFloat(a.getAttribute('data-rating'));
                const ratingB = parseFloat(b.getAttribute('data-rating'));
                return ratingB - ratingA; 
            }
        });

        const sortedFilmsContainer = document.createElement('div');
        sortedFilmsContainer.classList.add('films-row');

        films.forEach(film => {
            sortedFilmsContainer.appendChild(film);
        });

        row.parentNode.replaceChild(sortedFilmsContainer, row);
    });
}




