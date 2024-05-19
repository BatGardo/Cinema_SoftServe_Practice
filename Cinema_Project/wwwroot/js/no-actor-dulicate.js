document.getElementById('add-actor').addEventListener('click', function() {
    const firstItem = document.querySelector('.item');
    
    if (firstItem) {
        const actorName = firstItem.textContent;
        
        if (!isActorAlreadyAdded(actorName)) {
            const newInput = document.createElement('input');
            newInput.id = 'active-actor';
            newInput.type = 'text';
            newInput.value = actorName;
            newInput.readOnly = true;

            const actorsList = document.getElementById('actors-list');

            actorsList.insertAdjacentElement('afterend', newInput);
        } else {
            alert('Цей актор вже доданий.');
        }
    } else {
        console.log('Елементи з класом "item" не знайдено.');
    }
});

function isActorAlreadyAdded(actorName) {

    const existingInputs = document.querySelectorAll('#active-actor');
    

    for (const input of existingInputs) {
        if (input.value === actorName) {
            return true; 
        }
    }
    return false; 
}