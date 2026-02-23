        let amount = 4500;  // change this value to test

        let discount = 0;
        let finalAmount = 0;

        if (amount >= 5000) {
            discount = amount * 0.20;
        } else if (amount >= 3000) {
            discount = amount * 0.10;
        } else {
            discount = 0;
        }

        finalAmount = amount - discount;

        console.log("Original Amount: " + amount);
        console.log("Discount: " + discount);
        console.log("Final Amount: " + finalAmount);

