USE EcommAppDb;


--Trigger to Reduce Stock After Order Insert
CREATE TRIGGER trg_ReduceStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    IF EXISTS (
        SELECT *
        FROM inserted i
        JOIN stocks s 
        ON s.product_id = i.product_id
        JOIN orders o 
        ON o.order_id = i.order_id AND o.store_id = s.store_id
        WHERE s.quantity < i.quantity
    )
    BEGIN
        RAISERROR('Insufficient stock available.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN inserted i ON s.product_id = i.product_id
    JOIN orders o ON o.order_id = i.order_id AND o.store_id = s.store_id;
END;


--Transaction to Place Order
BEGIN TRY

BEGIN TRANSACTION;

INSERT INTO orders
(customer_id,order_status,order_date,required_date,store_id,staff_id)
VALUES
(1,1,GETDATE(),DATEADD(day,5,GETDATE()),1,1);

DECLARE @orderid INT = SCOPE_IDENTITY();

INSERT INTO order_items
(order_id,item_id,product_id,quantity,list_price,discount)
VALUES
(@orderid,1,1,2,379.99,0.05);

COMMIT TRANSACTION;

PRINT 'Order placed successfully';

END TRY

BEGIN CATCH
ROLLBACK TRANSACTION;
PRINT ERROR_MESSAGE();
END CATCH;