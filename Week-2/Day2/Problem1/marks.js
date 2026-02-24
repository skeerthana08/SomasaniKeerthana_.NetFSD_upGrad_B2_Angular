// Store marks in array
const marks = [70, 80, 65, 90, 50];

// Calculate total using reduce
const total = marks.reduce((sum, mark) => sum + mark, 0);

// Calculate average
const average = total / marks.length;

// Pass / Fail based on average
const result = average >= 50 ? "Pass" : "Fail";

// Display output using template literals
console.log(`Total Marks: ${total}`);
console.log(`Average Marks: ${average}`);
console.log(`Result: ${result}`);