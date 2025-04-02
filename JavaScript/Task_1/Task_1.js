function calculateInterest(event) {
    event.preventDefault(); // Prevents form submission & page refresh

    // Get input values
    let principal = parseFloat(document.getElementById("amount").value);
    let rate = parseFloat(document.getElementById("rate").value);
    let time = parseFloat(document.getElementById("time").value);

    // Validate inputs
    if (isNaN(principal) || isNaN(rate) || isNaN(time) || principal <= 0 || rate <= 0 || time <= 0) {
        alert("Please enter valid positive numbers for all fields.");
        return;
    }

    // Calculate Simple Interest
    let interest = (principal * rate * time) / 100;
    let totalAmount = principal + interest;

    // Display results dynamically
    document.getElementById("interest-result").innerText = `Interest: ₹${interest.toFixed(2)}`;
    document.getElementById("total-amount").innerText = `Total Amount: ₹${totalAmount.toFixed(2)}`;
    document.getElementById("additional-info").innerText = `For ${time} years at ${rate}% interest per year.`;
    
}

// Attach event listener to prevent default form submission
document.querySelector("form").addEventListener("submit", calculateInterest);
