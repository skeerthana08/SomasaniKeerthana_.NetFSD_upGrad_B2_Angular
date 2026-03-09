USE EcommAppDb;

--Stored Procedure – Total Sales per Store
CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN
    SELECT 
        s.store_id,
        s.store_name,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
    FROM stores s
    JOIN orders o ON s.store_id = o.store_id
    JOIN order_items oi ON o.order_id = oi.order_id
    GROUP BY s.store_id, s.store_name;
END;


EXEC sp_TotalSalesPerStore;


--Stored Procedure – Orders by Date Range
CREATE PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT *
    FROM orders
    WHERE order_date BETWEEN @StartDate AND @EndDate;
END;


EXEC sp_GetOrdersByDateRange '2016-01-01','2017-12-31';


--Scalar Function – Price After Discount
CREATE FUNCTION fn_CalculateDiscountPrice
(
    @price DECIMAL(10,2),
    @discount DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @price * (1 - ISNULL(@discount,0));
END;


SELECT dbo.fn_CalculateDiscountPrice(1000,0.10) AS FinalPrice;


--Table Valued Function – Top 5 Selling Products
CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5 
        p.product_id,
        p.product_name,
        SUM(oi.quantity) AS total_sold
    FROM products p
    JOIN order_items oi ON p.product_id = oi.product_id
    GROUP BY p.product_id, p.product_name
    ORDER BY total_sold DESC
);


SELECT * FROM fn_Top5SellingProducts();





