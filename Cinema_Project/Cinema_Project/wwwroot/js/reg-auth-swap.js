const span1 = document.getElementById('span1');
const span2 = document.getElementById('span2');
const block1 = document.getElementById('block1');
const block2 = document.getElementById('block2');

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