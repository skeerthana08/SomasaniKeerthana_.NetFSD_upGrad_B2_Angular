USE EcommAppDb;

--Create archive table
CREATE TABLE archived_orders
(
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT,
    staff_id INT
);

--Insert rejected orders older than 1 year
INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

--Delete those orders
DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

--Customers whose all orders are completed
SELECT customer_id
FROM orders
GROUP BY customer_id
HAVING MIN(order_status) = 4 AND MAX(order_status) = 4;

--Order processing delay
SELECT 
    order_id,
    DATEDIFF(DAY, order_date, shipped_date) AS Processing_Delay,
    
    CASE
        WHEN shipped_date > required_date THEN 'Delayed'
        ELSE 'On Time'
    END AS Order_Status
FROM orders;

