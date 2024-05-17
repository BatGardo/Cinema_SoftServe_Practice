const span1 = document.getElementById('span1');
const span2 = document.getElementById('span2');
const block1 = document.getElementById('block1');
const block2 = document.getElementById('block2');

const header1 = document.getElementById('header1');
document.addEventListener("DOMContentLoaded", function (event) {
    header1.classList.add('remove');


    var footer = document.getElementById("footer1");

    // Проверяем, существует ли элемент footer
    if (footer) {
        // Скрываем footer
        footer.style.display = "none";
    } else {
        console.log("Footer не найден");
    }
});

// Додаємо обробники подій
span1.addEventListener('click', function () {
    // Знімаємо клас active з першого блоку
    block1.classList.remove('active');
    // Додаємо клас active до другого блоку
    block2.classList.add('active');
});

span2.addEventListener('click', function () {
    // Знімаємо клас active з першого блоку
    block2.classList.remove('active');
    // Додаємо клас active до другого блоку
    block1.classList.add('active');
});