document.addEventListener('DOMContentLoaded', function () {
    // Form validation code
    const form = document.getElementById('wordForm');
    const errorMessage = document.getElementById('error-message');
    const wordInput = document.getElementById('wordInput');

    // Only add event listener if form is present
    if (form) { 
        form.addEventListener('submit', function (event) {
            const input = wordInput.value.trim();
            const wordPattern = /^[a-zA-Z]+$/; // Pattern to match a single word without numbers

            // Check if input is empty
            if (input === '') {
                errorMessage.textContent = 'Input cannot be empty!';
                event.preventDefault();
            }
            // Check if input contains spaces
            else if (input.includes(' ')) {
                errorMessage.textContent = 'Try a single word; sentences will not be processed!';
                event.preventDefault();
            }
            // Check if input contains numbers or other invalid characters
            else if (!wordPattern.test(input)) {
                errorMessage.textContent = 'Words cannot contain numbers or special characters, please try again!';
                event.preventDefault();
            }
            else {
                errorMessage.textContent = ''; 
            }
        });

        // Event listener to clear error message when user starts editing
        wordInput.addEventListener('input', function () {
            errorMessage.textContent = '';
        });

        // Event listener to clear error message when user clicks on the input
        wordInput.addEventListener('focus', function () {
            errorMessage.textContent = '';
        });
    }

    // Animation code for the character table
    const table = document.querySelector('.char-table');
    const wordDisplay = document.getElementById('wordDisplay');


    // Only execute animation if relevant elements are present
    if (table && wordDisplay) {
        const table = document.querySelector('.char-table');
        // Retrieve the word from the HTML element
        const word = document.getElementById('wordDisplay').textContent.trim();

        //console.log(`The word length is "${word}"`);

        // Animate table cells based on length
        const cells = document.querySelectorAll('.char-table td');

        cells.forEach((cell, index) => {
            let delay;
            // Adjust the delay based on word length
            if (word > 15) {
                delay = index*20; // Faster delay for very long words
            } else if (word > 8) {
                delay = index * 40; // Moderate delay for medium-length words
            } else {
                delay = index * 80; // Longer delay for shorter words
            }

            // Apply the animation after the calculated delay
            setTimeout(() => {
                cell.classList.add('fadeIn'); // Add animation class
                cell.style.opacity = 1; 

                // Scroll to the cell
                cell.scrollIntoView({ behavior: 'smooth', block: 'nearest' });
            }, delay); 


        });

        // Hover message functionality for the fixed button
        var button = document.getElementById('fixed-button');
        var message = document.getElementById('hover-message');

        button.addEventListener('mouseover', function () {
            message.classList.remove('hidden');
        });

        button.addEventListener('mouseout', function () {
            message.classList.add('hidden');
        });

    }

});

function navigateToIndex() {
    window.location.href = './'; // Direct URL path
}
