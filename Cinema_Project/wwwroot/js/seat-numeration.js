document.querySelectorAll('.seat-row').forEach((row, index) => {
    const rowNumber = index + 1; // Індекс ряду + 1, так як індекси починаються з 0, а номери рядів зазвичай починаються з 1
    row.setAttribute('data-row-number', rowNumber); // Додаємо атрибут data-row-number з номером ряду
});