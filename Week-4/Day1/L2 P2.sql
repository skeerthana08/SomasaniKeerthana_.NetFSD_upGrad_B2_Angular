USE EcommAppDb;

--Trigger – Auto Update Stock
CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN orders o ON i.order_id = o.order_id
            JOIN stocks s ON s.product_id = i.product_id AND s.store_id = o.store_id
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
        JOIN orders o ON i.order_id = o.order_id
        WHERE s.store_id = o.store_id;

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;