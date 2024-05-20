function updateGenres() {
    const genresElement = document.getElementById('genres').querySelector('u');
    const checkboxes = document.querySelectorAll('.properties-droplist-check input[type="checkbox"]');
    let selectedGenres = [];

    checkboxes.forEach(checkbox => {
        if (checkbox.checked) {
            const label = checkbox.nextElementSibling;
            selectedGenres.push(label.textContent.trim());
        }
    });

    // Limit the number of selected genres to 3
    if (selectedGenres.length > 99) {
        selectedGenres = selectedGenres.slice(0, 3);
        selectedGenres.push("...");
    }

    genresElement.textContent = selectedGenres.length > 0 ? selectedGenres.join(', ') : 'Немає';

    updateMovieGenres(selectedGenres);
}

function updateMovieGenres(selectedGenres) {
    const movies = document.querySelectorAll('.film-search-elem');

    movies.forEach(movie => {
        const movieGenres = movie.getAttribute('data-genres').split(',').map(g => g.trim());
        const match = selectedGenres.length === 0 || selectedGenres.some(genre => movieGenres.includes(genre));

        // Debugging: Log each movie's genres and whether it matches the selected genres
        console.log("Movie Genres:", movieGenres, "Selected Genres:", selectedGenres, "Match:", match);

        if (match) {
            movie.style.display = 'block';
        } else {
            movie.style.display = 'none';
        }
    });
}

// Assuming this is called when a checkbox is clicked
document.querySelectorAll('.properties-droplist-check input[type="checkbox"]').forEach(checkbox => {
    checkbox.addEventListener('change', updateGenres);
});

// Ініціалізація початкового стану
updateGenres();