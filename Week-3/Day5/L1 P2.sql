USE EcommAppDb;

--View for product details
CREATE VIEW vw_product_details AS
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
JOIN brands b 
    ON p.brand_id = b.brand_id
JOIN categories c 
    ON p.category_id = c.category_id;


SELECT * FROM vw_product_details;


--View for order summary
CREATE VIEW vw_order_summary AS
SELECT 
    o.order_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    s.store_name,
    st.first_name + ' ' + st.last_name AS staff_name,
    o.order_date,
    o.order_status
FROM orders o
JOIN customers c 
    ON o.customer_id = c.customer_id
JOIN stores s 
    ON o.store_id = s.store_id
JOIN staffs st 
    ON o.staff_id = st.staff_id;


SELECT * FROM vw_order_summary;


--Index on products
CREATE INDEX idx_products_brand
ON products(brand_id);

CREATE INDEX idx_products_category
ON products(category_id);

--Index on orders
CREATE INDEX idx_orders_customer
ON orders(customer_id);

CREATE INDEX idx_orders_store
ON orders(store_id);

CREATE INDEX idx_orders_staff
ON orders(staff_id);