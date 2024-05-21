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


    let selectedDate = null;
    let selectedTime = null;
    let selectedHall = null;

    document.querySelectorAll('.row-button.date').forEach(button => {
        button.addEventListener('click', () => {
            selectedDate = button;
            loadReservedSeats();
        });
    });

    document.querySelectorAll('.row-button.time').forEach(button => {
        button.addEventListener('click', () => {
            selectedTime = button;
            loadReservedSeats();
        });
    });

    document.querySelectorAll('.row-button.hall').forEach(button => {
        button.addEventListener('click', () => {
            selectedHall = button;
            loadReservedSeats();
        });
    });

    function loadReservedSeats() {
        if (selectedDate && selectedTime && selectedHall) {
            const showtime = selectedDate.dataset.date + 'T' + selectedTime.dataset.time + ':00';
            const hallNumber = selectedHall.dataset.hall;
            const movieId = document.getElementById('MovieId').value;

            fetch(`/Booking/GetReservedSeats?movieId=${movieId}&showtime=${showtime}&hallNumber=${hallNumber}`)
                .then(response => response.json())
                .then(data => {
                    document.querySelectorAll('.seat').forEach(seat => {
                        seat.classList.remove('seat-blocked');
                    });
                    data.forEach(seat => {
                        const row = seat.rowNumber;
                        const seatNum = seat.seatNumber;
                        const seatElement = document.querySelector(`.seat-row:nth-child(${row}) .seat:nth-child(${seatNum})`);
                        if (seatElement) {
                            seatElement.classList.add('seat-blocked');
                        }
                    });
                })
                .catch(error => console.error('Error fetching reserved seats:', error));
        }
    }

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


    document.querySelector('.buy-button').addEventListener('click', function (e) {
        e.preventDefault();

        const selectedDate = document.querySelector('.row-button.date.selected');
        const selectedTime = document.querySelector('.row-button.time.selected');
        const selectedHall = document.querySelector('.row-button.hall.selected');

        const rowIndexes = [];
        const seatIndexes = [];

        document.querySelectorAll('.seat-info').forEach(seatInfo => {
            const id = seatInfo.id;
            const parts = id.split('-');
            const rowIndex = parseInt(parts[1]);
            const seatIndex = parseInt(parts[2]);
            rowIndexes.push(rowIndex);
            seatIndexes.push(seatIndex);
        });

        if (selectedDate && selectedTime && selectedHall && rowIndexes && seatIndexes) {
            flag = false;
            const showtime = selectedDate.dataset.date + 'T' + selectedTime.dataset.time + ':00';
            const price = parseFloat(selectedTime.dataset.price);
            const hallNumber = selectedHall.dataset.hall;

            for (let i = 0; i < rowIndexes.length; i++) {
                const rowNumber = rowIndexes[i] + 1;
                const seatNumber = seatIndexes[i] + 1;

                const formData = {
                    Showtime: showtime,
                    Price: price,
                    HallNumber: parseInt(hallNumber),
                    RowNumber: rowNumber,
                    SeatNumber: seatNumber,
                    MovieId: parseInt(document.getElementById('MovieId').value),
                    UserId: document.getElementById('UserId').value
                };

                fetch('/Booking/Create', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(formData)
                })
                    .then(response => response.json())
                    .then(data => {
                        if (data.success) {
                            window.location.href = data.redirectUrl;
                            flag = true;
                        } else {
                            console.error('Error booking ticket:', data.errors);
                            alert('Error booking ticket.');
                        }
                    })
                    .catch(error => console.error('Error:', error));
            }
            if (flag = true) {
                alert('Квитки успішно придбано!');
            }
        } else {
            alert('Не всі параметри обрані');
        }
    });


    document.querySelectorAll('.row-button.date').forEach(button => {
        button.addEventListener('click', function () {
            document.querySelectorAll('.row-button.date').forEach(btn => btn.classList.remove('selected'));
            this.classList.add('selected');
        });
    });

    document.querySelectorAll('.row-button.time').forEach(button => {
        button.addEventListener('click', function () {
            document.querySelectorAll('.row-button.time').forEach(btn => btn.classList.remove('selected'));
            this.classList.add('selected');
        });
    });

    document.querySelectorAll('.row-button.hall').forEach(button => {
        button.addEventListener('click', function () {
            document.querySelectorAll('.row-button.hall').forEach(btn => btn.classList.remove('selected'));
            this.classList.add('selected');
        });
    });
});