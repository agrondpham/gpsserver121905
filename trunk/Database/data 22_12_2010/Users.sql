USE [GPSDatabase];
SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

SET IDENTITY_INSERT [dbo].[Users] ON;
BEGIN TRANSACTION;
INSERT INTO [dbo].[Users]([ID_User], [Username], [Password], [Email], [Fullname], [Mobile], [Company], [Cop_Phone], [Status])
SELECT 1, N'demo', N'demo', N'abc@yahoo.com.nn', N'DuongLong', 90900000, N'DL', 883888, 1
COMMIT;
RAISERROR (N'[dbo].[Users]: Insert Batch: 1.....Done!', 10, 1) WITH NOWAIT;
GO

SET IDENTITY_INSERT [dbo].[Users] OFF;
