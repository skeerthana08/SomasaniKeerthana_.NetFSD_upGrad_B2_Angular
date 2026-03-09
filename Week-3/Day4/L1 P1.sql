USE EcommAppDb;
SELECT 
    p.product_name + ' (' + CAST(p.model_year AS VARCHAR) + ')' AS Product_Details,
    p.model_year,
    p.list_price,
    (p.list_price - 
        (SELECT AVG(list_price) 
         FROM products 
         WHERE category_id = p.category_id)
    ) AS Price_Difference
FROM products p
WHERE p.list_price >
      (SELECT AVG(list_price)
       FROM products
       WHERE category_id = p.category_id);