USE EcommAppDb;
-- Customers with Orders
SELECT 
    c.customer_id,
    c.first_name + ' ' + c.last_name AS Full_Name,
    
    (SELECT SUM(oi.quantity * oi.list_price)
     FROM orders o
     JOIN order_items oi ON o.order_id = oi.order_id
     WHERE o.customer_id = c.customer_id) AS Total_Order_Value,

    CASE
        WHEN (SELECT SUM(oi.quantity * oi.list_price)
              FROM orders o
              JOIN order_items oi ON o.order_id = oi.order_id
              WHERE o.customer_id = c.customer_id) > 10000 THEN 'Premium'
              
        WHEN (SELECT SUM(oi.quantity * oi.list_price)
              FROM orders o
              JOIN order_items oi ON o.order_id = oi.order_id
              WHERE o.customer_id = c.customer_id) BETWEEN 5000 AND 10000 THEN 'Regular'
              
        ELSE 'Basic'
    END AS Customer_Category

FROM customers c
WHERE c.customer_id IN (SELECT customer_id FROM orders)

UNION

-- Customers without Orders
SELECT 
    c.customer_id,
    c.first_name + ' ' + c.last_name AS Full_Name,
    NULL AS Total_Order_Value,
    'No Orders' AS Customer_Category
FROM customers c
WHERE c.customer_id NOT IN (SELECT customer_id FROM orders);