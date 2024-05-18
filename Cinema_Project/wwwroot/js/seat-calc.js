document.addEventListener('DOMContentLoaded', () => {
    const seatContainer = document.querySelector('.seat-container');
    const bookedSeatsContainer = document.getElementById('booked-seats');
    const singleSeatPriceElement = document.querySelector('.single-seat-price');
    const totalPriceElement = document.querySelector('.total-price');
    
    const seatPrice = parseFloat(singleSeatPriceElement.textContent.replace('Seat price: ', '').replace('₴', ''));
    let totalPrice = 0;

    seatContainer.addEventListener('click', (event) => {
        const target = event.target;
        if (target.classList.contains('seat')) {
            const seatRow = Array.from(target.parentElement.children);
            const seatIndex = seatRow.indexOf(target);
            const rowIndex = Array.from(seatContainer.children).indexOf(target.parentElement);

            if (target.classList.contains('seat-blocked')) {
                return;
            }

            const seatInfoId = `seat-${rowIndex}-${seatIndex}`;

            if (target.classList.contains('seat-active')) {
                target.classList.remove('seat-active');
                const seatInfo = document.getElementById(seatInfoId);
                if (seatInfo) {
                    totalPrice -= seatPrice;
                    seatInfo.remove();
                }
            } else {
                target.classList.add('seat-active');
                const seatInfo = document.createElement('div');
                seatInfo.classList.add('seat-info');
                seatInfo.id = seatInfoId;
                seatInfo.innerHTML = `
                    <div class="seat-coords">Row ${rowIndex + 1}, seat ${seatIndex + 1}</div>
                    <div class="seat-price">${seatPrice}₴</div>
                `;
                bookedSeatsContainer.appendChild(seatInfo);
                totalPrice += seatPrice;
            }

            totalPriceElement.textContent = `Total: ${totalPrice}₴`;
        }
    });
});