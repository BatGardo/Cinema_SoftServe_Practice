document.addEventListener('DOMContentLoaded', (event) => {
    const dropArea = document.getElementById('drop-area');
    const fileInput = document.querySelector('.file-input');
    let fileProcessed = false; 

    ['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
        dropArea.addEventListener(eventName, preventDefaults, false);
    });

    ['dragenter', 'dragover'].forEach(eventName => {
        dropArea.addEventListener(eventName, highlight, false);
    });

    ['dragleave', 'drop'].forEach(eventName => {
        dropArea.addEventListener(eventName, unhighlight, false);
    });

    dropArea.addEventListener('drop', handleDrop, false);

    function preventDefaults(e) {
        e.preventDefault();
        e.stopPropagation();
    }

    function highlight() {
        dropArea.classList.add('highlight');
    }

    function unhighlight() {
        dropArea.classList.remove('highlight');
    }

    function handleDrop(e) {
        const dt = e.dataTransfer;
        const files = dt.files;
        handleFiles(files);
    }

    fileInput.addEventListener('change', function () {
        if (!fileProcessed) { 
            const files = this.files;
            if (files.length > 0) {
                const file = files[0];
                if (isImageFile(file)) {
                    handleFiles(files);
                    dropArea.classList.add('file-selected');
                } else {
                    alert('Некоректний тип файлу. Приймаються лише файли з розширенням img, png, webp або jpeg.');
                    this.value = ''; 
                }
            }
            fileProcessed = true; 
        }
    });


    function isImageFile(file) {
        return file.type.startsWith('image/') && /\.(png|webp|jpe?g)$/i.test(file.name);
    }


    function handleFiles(files) {
        const file = files[0]; 


        if (file && isImageFile(file)) {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = function () {
                dropArea.style.backgroundImage = `url('${reader.result}')`;
            };
        }
    }
});