document.querySelectorAll('.properties-droplist').forEach(droplist => {
    droplist.addEventListener('click', function(event) {
        // Перевірка, чи був клік зроблений по елементу з класом properties-droplist-elem
        if (event.target.classList.contains('properties-droplist-elem')) {
            // Знайти всі елементи properties-droplist-elem в поточному droplist і видалити клас elem-active
            droplist.querySelectorAll('.properties-droplist-elem').forEach(elem => {
                elem.classList.remove('elem-active');
            });

            // Додати клас elem-active до натиснутого елемента
            event.target.classList.add('elem-active');
        }
    });
});