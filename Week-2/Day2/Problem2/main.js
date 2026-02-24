// main.js

import { calculateTotal } from './cart.js';

const products = [
    { name: "Shirt", price: 500, quantity: 2 },
    { name: "Jeans", price: 1000, quantity: 1 },
    { name: "Shoes", price: 1500, quantity: 1 }
];

// Calculate total
const total = calculateTotal(products);

// Display invoice using template literals
products.map(item => {
    console.log(`${item.name} - ${item.price} x ${item.quantity}`);
});

console.log(`Total Cart Value: ${total}`);