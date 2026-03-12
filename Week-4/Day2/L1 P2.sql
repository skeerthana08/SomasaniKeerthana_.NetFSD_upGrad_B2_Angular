USE EcommAppDb;

--Atomic Order Cancellation using SAVEPOINT

DECLARE @OrderID INT = 1;

BEGIN TRY

BEGIN TRANSACTION;

SAVE TRANSACTION BeforeStockRestore;

-- Restore stock
UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM stocks s
JOIN orders o ON o.store_id = s.store_id
JOIN order_items oi ON oi.product_id = s.product_id
WHERE oi.order_id = @OrderID;

-- Update order status to Rejected (3)
UPDATE orders
SET order_status = 3
WHERE order_id = @OrderID;

COMMIT TRANSACTION;

PRINT 'Order cancelled and stock restored successfully';

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION BeforeStockRestore;

PRINT 'Error occurred while restoring stock';
PRINT ERROR_MESSAGE();

ROLLBACK TRANSACTION;

END CATCH;

--TESTING
SELECT * FROM stocks;
SELECT * FROM orders
SELECT * FROM order_items