document.addEventListener('DOMContentLoaded', () => {
    const handleButtonClick = (event) => {
        event.preventDefault();
        const parentDiv = event.target.parentNode;

        Array.from(parentDiv.children).forEach(button => {
            button.classList.remove('active');
        });

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

    const handleSelectChange = (event) => {
        const parentDiv = event.target.parentNode;
        Array.from(parentDiv.children).forEach(select => {
            select.classList.remove('active');
        });

        event.target.classList.add('active');
    };

    document.querySelectorAll('.hall button, .time button').forEach(button => {
        button.addEventListener('click', handleButtonClick);
    });

    document.querySelectorAll('.date select').forEach(select => {
        select.addEventListener('change', handleSelectChange);
    });
});
