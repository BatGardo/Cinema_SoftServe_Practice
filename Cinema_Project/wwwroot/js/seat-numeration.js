document.querySelectorAll('.seat-row').forEach((row, index) => {
    const rowNumber = index + 1;
    row.setAttribute('data-row-number', rowNumber); 
});