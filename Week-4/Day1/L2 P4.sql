USE EcommAppDb;

--Cursor – Store Revenue Calculation
CREATE PROCEDURE sp_CalculateRevenueByStore
AS
BEGIN
    BEGIN TRY

        BEGIN TRANSACTION;

        DECLARE @order_id INT;
        DECLARE @store_id INT;
        DECLARE @revenue DECIMAL(12,2);

        CREATE TABLE #RevenueTemp
        (
            store_id INT,
            revenue DECIMAL(12,2)
        );

        DECLARE order_cursor CURSOR FOR
        SELECT order_id, store_id
        FROM orders
        WHERE order_status = 4;

        OPEN order_cursor;

        FETCH NEXT FROM order_cursor INTO @order_id, @store_id;

        WHILE @@FETCH_STATUS = 0
        BEGIN

            SELECT @revenue = SUM(quantity * list_price * (1-discount))
            FROM order_items
            WHERE order_id = @order_id;

            INSERT INTO #RevenueTemp
            VALUES(@store_id,@revenue);

            FETCH NEXT FROM order_cursor INTO @order_id, @store_id;

        END

        CLOSE order_cursor;
        DEALLOCATE order_cursor;

        SELECT store_id, SUM(revenue) AS total_store_revenue
        FROM #RevenueTemp
        GROUP BY store_id;

        COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;


EXEC sp_CalculateRevenueByStore;