document.addEventListener('DOMContentLoaded', () => {
    // Функція для обробки натискання кнопок
    const handleButtonClick = (event) => {
        const parentDiv = event.target.parentNode;

        // Знайти всі кнопки всередині цього div і видалити у них клас active
        Array.from(parentDiv.children).forEach(button => {
            button.classList.remove('active');
        });

        // Додати клас active до натиснутої кнопки
        event.target.classList.add('active');
    };

    document.querySelectorAll('.date select').forEach(select => {
        select.addEventListener('focus', function() {
            this.classList.add('select-active');
        });

        select.addEventListener('blur', function() {
            this.classList.remove('select-active');
        });
    });

    // Функція для обробки зміни select
    const handleSelectChange = (event) => {
        const parentDiv = event.target.parentNode;

        // Знайти всі select всередині цього div і видалити у них клас active
        Array.from(parentDiv.children).forEach(select => {
            select.classList.remove('active');
        });

        // Додати клас active до вибраного select
        event.target.classList.add('active');
    };

    // Знайти всі кнопки всередині .hall і .time і додати обробник події click
    document.querySelectorAll('.hall button, .time button').forEach(button => {
        button.addEventListener('click', handleButtonClick);
    });

    // Знайти всі select всередині .date і додати обробник події change
    document.querySelectorAll('.date select').forEach(select => {
        select.addEventListener('change', handleSelectChange);
    });
});