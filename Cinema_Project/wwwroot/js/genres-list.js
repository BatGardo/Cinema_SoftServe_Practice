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

    // Обмеження кількості вибраних жанрів до 3
    if (selectedGenres.length > 3) {
        selectedGenres = selectedGenres.slice(0, 3);
        selectedGenres.push("...");
    }

    genresElement.textContent = selectedGenres.length > 0 ? selectedGenres.join(', ') : 'None';
}

// Додаємо обробник подій на всі чекбокси
document.querySelectorAll('.properties-droplist-check input[type="checkbox"]').forEach(checkbox => {
    checkbox.addEventListener('change', updateGenres);
});

// Ініціалізація початкового стану
updateGenres();