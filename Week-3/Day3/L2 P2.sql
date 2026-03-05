SELECT 
    p.product_name,
    st.store_name,
    s.quantity AS available_stock,
    SUM(oi.quantity) AS total_quantity_sold
FROM stocks s
INNER JOIN products p
ON s.product_id = p.product_id
INNER JOIN stores st
ON s.store_id = st.store_id
LEFT JOIN order_items oi
ON s.product_id = oi.product_id
GROUP BY 
    p.product_name,
    st.store_name,
    s.quantity
ORDER BY p.product_name;