USE EcommAppDb;

--Trigger – Order Status Validation
CREATE TRIGGER trg_OrderStatusValidation
ON orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY

        IF EXISTS (
            SELECT *
            FROM inserted
            WHERE order_status = 4 AND shipped_date IS NULL
        )
        BEGIN
            RAISERROR('Shipped date cannot be NULL when order is Completed.',16,1);
            ROLLBACK TRANSACTION;
        END

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;