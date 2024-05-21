console.log('1===========');

const span1 = document.getElementById('span1');
const span2 = document.getElementById('span2');
const block1 = document.getElementById('block1');
const block2 = document.getElementById('block2');

span1.addEventListener('click', function () {
    block1.classList.remove('active');
    block2.classList.add('active');

    console.log('3===========');

});
console.log('2===========');
span2.addEventListener('click', function () {
    block2.classList.remove('active');
    block1.classList.add('active');

    console.log('3===========');

});