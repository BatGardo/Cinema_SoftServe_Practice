document.addEventListener('DOMContentLoaded', () => {
    const seatContainer = document.querySelector('.seat-container');
    const bookedSeatsContainer = document.getElementById('booked-seats');
    const singleSeatPriceElement = document.querySelector('.single-seat-price');
    const totalPriceElement = document.querySelector('.total-price');

    const seatPrice = parseFloat(singleSeatPriceElement.textContent.replace('Ціна місця: ', '').replace('₴', ''));
    let totalPrice = 0;

    const updateTotalPrice = () => {
        const activeSeats = seatContainer.querySelectorAll('.seat-active');
        const seatPrice = parseFloat(singleSeatPriceElement.textContent.replace('Ціна місця: ', '').replace('₴', ''));
        totalPrice = activeSeats.length * seatPrice;
        totalPriceElement.textContent = `Всього: ${totalPrice}₴`;
    };

    const updateSeatPrices = () => {
        const seatPrice = parseFloat(singleSeatPriceElement.textContent.replace('Ціна місця: ', '').replace('₴', ''));
        const seatPriceElements = document.querySelectorAll('.seat-price');
        seatPriceElements.forEach(seatPriceElement => {
            seatPriceElement.textContent = `${seatPrice}₴`;
        });
    };

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
                    seatInfo.remove();
                }
            } else {
                target.classList.add('seat-active');
                const seatInfo = document.createElement('div');
                seatInfo.classList.add('seat-info');
                seatInfo.id = seatInfoId;
                seatInfo.innerHTML = `
                <div class="seat-coords">Ряд ${rowIndex + 1}, місце ${seatIndex + 1}</div>
                <div class="seat-price">${seatPrice}₴</div>
                `;
                bookedSeatsContainer.appendChild(seatInfo);
            }

            updateTotalPrice();
            updateSeatPrices();
        }
    });



    const dateButtons = document.querySelectorAll('.row-button.date');
    const timeButtons = document.querySelectorAll('.row-button.time');
    const hallButtons = document.querySelectorAll('.row-button.hall-red, .row-button.hall-green, .row-button.hall-blue');

    timeButtons.forEach(button => {
        button.addEventListener('click', () => {
            timeButtons.forEach(btn => btn.classList.remove('active'));
            button.classList.add('active');

            const price = button.getAttribute('data-price');
            singleSeatPriceElement.textContent = `Ціна місця: ${price}₴`;

            updateTotalPrice();
            updateSeatPrices();
        });
    });

    dateButtons.forEach(button => {
        button.addEventListener('click', () => {

            dateButtons.forEach(btn => btn.classList.remove('active'));
            button.classList.add('active');

            const selectedDate = button.getAttribute('data-date');

            // Filter time buttons based on selected date and update their visibility or data attributes
            timeButtons.forEach(timeButton => {
                const screeningDateTime = new Date(`${selectedDate}T${timeButton.getAttribute('data-time')}`);
                const matchingScreening = screenings.find(screening => new Date(screening.ScreeningDate).getTime() === screeningDateTime.getTime());

                if (matchingScreening) {
                    timeButton.setAttribute('data-price', matchingScreening.Price);
                    timeButton.style.display = 'inline-block';
                } else {
                    timeButton.style.display = 'none';
                }
            });

            // Optionally, update the single seat price based on the first visible time button
            const firstVisibleTimeButton = Array.from(timeButtons).find(button => button.style.display !== 'none');
            if (firstVisibleTimeButton) {
                seatPrice = parseFloat(button.getAttribute('data-price'));
                singleSeatPriceElement.textContent = `Ціна місця: ${seatPrice}₴`;

                updateTotalPrice();
                updateSeatPrices();
            }
        });
    });
    hallButtons.forEach(button => {
        button.addEventListener('click', () => {
            hallButtons.forEach(btn => btn.classList.remove('active'));
            button.classList.add('active');
        });
    });
});