USE [GPSDatabase];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

BEGIN TRANSACTION;
INSERT INTO [dbo].[Devices]([IMED_Device], [ID_User], [Status])
SELECT 1234567890, 1, 1
COMMIT;
RAISERROR (N'[dbo].[Devices]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

