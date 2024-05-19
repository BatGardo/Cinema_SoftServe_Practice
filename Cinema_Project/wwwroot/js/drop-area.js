document.addEventListener('DOMContentLoaded', (event) => {
    const dropArea = document.getElementById('drop-area');
    const fileInput = document.querySelector('.file-input');
    let fileProcessed = false; // Флаг для відстеження обробки файлу

    // Виправляємо події перетягування для запобігання втрати подій
    ['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
        dropArea.addEventListener(eventName, preventDefaults, false);
    });

    // Захоплення подій dragenter та dragover
    ['dragenter', 'dragover'].forEach(eventName => {
        dropArea.addEventListener(eventName, highlight, false);
    });

    // Зняття підсвічення при виході з області перетягування
    ['dragleave', 'drop'].forEach(eventName => {
        dropArea.addEventListener(eventName, unhighlight, false);
    });

    // Захоплення події drop
    dropArea.addEventListener('drop', handleDrop, false);

    // Функція для запобігання дії за замовчуванням
    function preventDefaults(e) {
        e.preventDefault();
        e.stopPropagation();
    }

    // Функція для підсвічування області при перетягуванні
    function highlight() {
        dropArea.classList.add('highlight');
    }

    // Функція для зняття підсвічування області
    function unhighlight() {
        dropArea.classList.remove('highlight');
    }

    // Обробник події drop
    function handleDrop(e) {
        const dt = e.dataTransfer;
        const files = dt.files;
        handleFiles(files);
    }

    // Обробка вибору файлу через input[type=file]
    fileInput.addEventListener('change', function () {
        if (!fileProcessed) { // Перевірка, чи файл ще не був оброблений
            const files = this.files;
            if (files.length > 0) {
                const file = files[0];
                if (isImageFile(file)) {
                    handleFiles(files);
                    dropArea.classList.add('file-selected');
                } else {
                    alert('Некоректний тип файлу. Приймаються лише файли з розширенням img, png, webp або jpeg.');
                    this.value = ''; // Очищаємо значення input, щоб вибраний файл не був доданий
                }
            }
            fileProcessed = true; // Помітити файл як оброблений
        }
    });

    // Функція для перевірки, чи є файл зображенням та має підтримуване розширення
    function isImageFile(file) {
        return file.type.startsWith('image/') && /\.(png|webp|jpe?g)$/i.test(file.name);
    }

    // Функція для обробки файлів зображень
    function handleFiles(files) {
        const file = files[0]; // Беремо перший файл

        // Перевіряємо, чи є файл зображенням
        if (file && isImageFile(file)) {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = function () {
                dropArea.style.backgroundImage = `url('${reader.result}')`;
            };
        }
    }
});