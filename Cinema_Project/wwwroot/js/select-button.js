document.addEventListener('DOMContentLoaded', () => {
    // Функция для обработки нажатия кнопок
    const handleButtonClick = (event) => {
        event.preventDefault();
        const parentDiv = event.target.parentNode;

        // Найти все кнопки внутри этого div и удалить у них класс active
        Array.from(parentDiv.children).forEach(button => {
            button.classList.remove('active');
        });

        // Добавить класс active к нажатой кнопке
        event.target.classList.add('active');

        // Получить ID нажатой кнопки
        const buttonId = event.target.getAttribute('data-id');
        console.log("ID нажатой кнопки:", buttonId);
    };

    // Функция для обработки изменения select
    const handleSelectChange = (event) => {
        const parentDiv = event.target.parentNode;
        // Найти все select внутри этого div и удалить у них класс active
        Array.from(parentDiv.children).forEach(select => {
            select.classList.remove('active');
        });

        // Добавить класс active к выбранному select
        event.target.classList.add('active');
    };

    // Найти все кнопки внутри .hall и назначить обработчик события click
    document.querySelectorAll('.hall button').forEach(button => {
        button.addEventListener('click', handleButtonClick);
    });

    // Найти все select внутри .date и назначить обработчик события change
    document.querySelectorAll('.date select').forEach(select => 
        {
        select.addEventListener('change', handleSelectChange);
    });
});
