function calculateInterest() {
    console.log("Calculating Interest...");
    let principalAmount = parseFloat(document.querySelector(".pricipal").value);
    let time = parseFloat(document.querySelector(".time").value);
    let interestRate;
  
    let amtError = document.querySelector(".amterrorMessage");
    let timeeErrorMessage = document.querySelector(".timeeErrorMessage");
  
    // Validate Principal Amount
    if (isNaN(principalAmount) || principalAmount < 500 || principalAmount > 10000) {
      amtError.style.display = "block";
      return;
    } else {
      amtError.style.display = "none";
    }
  
    // Validate Time
    if (isNaN(time) || time <= 0) {
      timeeErrorMessage.style.display = "block";
      return;
    } else {
      timeeErrorMessage.style.display = "none";
    }
  
    // Determine Base Interest Rate
    if (principalAmount < 1000) {
      interestRate = 5;
    } else if (principalAmount >= 1000 && principalAmount <= 5000) {
      interestRate = 7;
    } else {
      interestRate = 10;
    }
  
    // Additional 2% if time is more than 5 years
    if (time > 5) {
      interestRate += 2;
    }
  
    let interest = (principalAmount * interestRate * time) / 100;
    let totalAmount = principalAmount + interest;
  
    console.log("Interest:", interest);
    document.querySelector(".interest").textContent = interest.toFixed(2);
    document.querySelector(".tAmt").textContent = totalAmount.toFixed(2);
    document.querySelector(".additonalinfo").textContent =`Interest Rate Applied: ${interestRate}%`;
  }
  
  // Get elements correctly
  let principalAmountInput = document.querySelector(".pricipal");
  let timeInput = document.querySelector(".time");
  let amtError = document.querySelector(".amterrorMessage");
  let timeeErrorMessage = document.querySelector(".timeeErrorMessage");
  
  // Real-time validation for Principal Amount
  principalAmountInput.addEventListener("input", () => {
    let value = parseFloat(principalAmountInput.value);
    if (!isNaN(value) && value >= 500 && value <= 10000) {
      amtError.style.display = "none";
    } else {
      amtError.style.display = "block";
    }
  });
  
  // Real-time validation for Time
  timeInput.addEventListener("input", () => {
    let value = parseFloat(timeInput.value);
    if (!isNaN(value) && value > 0) {
      timeeErrorMessage.style.display = "none";
    } else {
      timeeErrorMessage.style.display = "block";
    }
  });