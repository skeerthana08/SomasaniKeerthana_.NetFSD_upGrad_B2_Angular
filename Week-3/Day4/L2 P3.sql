USE EcommAppDb;

--Products sold per store with revenue
SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS Total_Quantity_Sold,
    SUM((oi.quantity * oi.list_price) - oi.discount) AS Total_Revenue
FROM order_items oi
JOIN orders o ON oi.order_id = o.order_id
JOIN stores s ON o.store_id = s.store_id
JOIN products p ON oi.product_id = p.product_id
GROUP BY s.store_name, p.product_name;

--Products sold but currently zero stock
SELECT store_id, product_id
FROM order_items oi
JOIN orders o ON oi.order_id = o.order_id

INTERSECT

SELECT store_id, product_id
FROM stocks
WHERE quantity = 0;

--Update stock to 0 for discontinued products (simulation)
UPDATE stocks
SET quantity = 0
WHERE product_id IN
(
    SELECT product_id
    FROM products
    WHERE model_year < 2017
);