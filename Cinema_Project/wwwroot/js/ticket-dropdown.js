document.querySelectorAll('.ticket-top').forEach(top => {
    top.addEventListener('click', function() {
        let ticketElement = this.closest('.ticket-element');
        let droplist = ticketElement.querySelector('.ticket-droplist');
        let rotateIcon = this.querySelector('.ticket-svg');

        if (droplist.classList.contains('open')) {
            droplist.style.height = droplist.scrollHeight + 'px'; // Set current height
            requestAnimationFrame(() => {
                droplist.style.height = '0'; // Animate to 0
                droplist.classList.remove('open');
            });
            rotateIcon.classList.remove('rotated'); // Remove rotation
        } else {
            droplist.style.height = droplist.scrollHeight + 'px';
            droplist.classList.add('open');
            droplist.addEventListener('transitionend', function transitionEnd() {
                if (droplist.classList.contains('open')) {
                    droplist.style.height = 'auto';
                }
                droplist.removeEventListener('transitionend', transitionEnd);
            });
            rotateIcon.classList.add('rotated'); // Add rotation
        }
    });
});