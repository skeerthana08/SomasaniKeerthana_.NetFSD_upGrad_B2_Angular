        let num = 5;

        // Positive or Negative
        let result = (num >= 0) ? "Positive" : "Negative";
        console.log("Number is: " + result);

        // Even or Odd
        if (num % 2 === 0) {
            console.log("Even Number");
        } else {
            console.log("Odd Number");
        }

        // Loop
        console.log("Numbers:");
        for (let i = 1; i <= num; i++) {
            console.log(i);
        }
