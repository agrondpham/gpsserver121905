USE [GPSDatabase];
GO

IF OBJECT_ID('[dbo].[usp_DevicesSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_DevicesSelect] 
END 
GO
CREATE PROC [dbo].[usp_DevicesSelect] 
    @IMED_Device INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [IMED_Device], [ID_User], [Status] 
	FROM   [dbo].[Devices] 
	WHERE  ([IMED_Device] = @IMED_Device OR @IMED_Device IS NULL) 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_DevicesInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_DevicesInsert] 
END 
GO
CREATE PROC [dbo].[usp_DevicesInsert] 
    @IMED_Device int,
    @ID_User int,
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Devices] ([IMED_Device], [ID_User], [Status])
	SELECT @IMED_Device, @ID_User, @Status
	
	-- Begin Return Select <- do not remove
	SELECT [IMED_Device], [ID_User], [Status]
	FROM   [dbo].[Devices]
	WHERE  [IMED_Device] = @IMED_Device
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_DevicesUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_DevicesUpdate] 
END 
GO
CREATE PROC [dbo].[usp_DevicesUpdate] 
    @IMED_Device int,
    @ID_User int,
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Devices]
	SET    [IMED_Device] = @IMED_Device, [ID_User] = @ID_User, [Status] = @Status
	WHERE  [IMED_Device] = @IMED_Device
	
	-- Begin Return Select <- do not remove
	SELECT [IMED_Device], [ID_User], [Status]
	FROM   [dbo].[Devices]
	WHERE  [IMED_Device] = @IMED_Device	
	-- End Return Select <- do not remove

	COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_DevicesDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_DevicesDelete] 
END 
GO
CREATE PROC [dbo].[usp_DevicesDelete] 
    @IMED_Device int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Devices]
	WHERE  [IMED_Device] = @IMED_Device

	COMMIT
GO

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('[dbo].[usp_GPS_DataSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_GPS_DataSelect] 
END 
GO
CREATE PROC [dbo].[usp_GPS_DataSelect] 
    @ID_Data INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID_Data], [IMED_Device], [Longitude], [Latitude], [Speed], [Received_Data], [Status] 
	FROM   [dbo].[GPS_Data] 
	WHERE  ([ID_Data] = @ID_Data OR @ID_Data IS NULL) 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_GPS_DataInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_GPS_DataInsert] 
END 
GO
CREATE PROC [dbo].[usp_GPS_DataInsert] 
    @IMED_Device int,
    @Longitude float,
    @Latitude float,
    @Speed float,
    @Received_Data varchar(100),
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[GPS_Data] ([IMED_Device], [Longitude], [Latitude], [Speed], [Received_Data], [Status])
	SELECT @IMED_Device, @Longitude, @Latitude, @Speed, @Received_Data, @Status
	
	-- Begin Return Select <- do not remove
	SELECT [ID_Data], [IMED_Device], [Longitude], [Latitude], [Speed], [Received_Data], [Status]
	FROM   [dbo].[GPS_Data]
	WHERE  [ID_Data] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_GPS_DataUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_GPS_DataUpdate] 
END 
GO
CREATE PROC [dbo].[usp_GPS_DataUpdate] 
    @ID_Data int,
    @IMED_Device int,
    @Longitude float,
    @Latitude float,
    @Speed float,
    @Received_Data varchar(100),
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[GPS_Data]
	SET    [IMED_Device] = @IMED_Device, [Longitude] = @Longitude, [Latitude] = @Latitude, [Speed] = @Speed, [Received_Data] = @Received_Data, [Status] = @Status
	WHERE  [ID_Data] = @ID_Data
	
	-- Begin Return Select <- do not remove
	SELECT [ID_Data], [IMED_Device], [Longitude], [Latitude], [Speed], [Received_Data], [Status]
	FROM   [dbo].[GPS_Data]
	WHERE  [ID_Data] = @ID_Data	
	-- End Return Select <- do not remove

	COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_GPS_DataDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_GPS_DataDelete] 
END 
GO
CREATE PROC [dbo].[usp_GPS_DataDelete] 
    @ID_Data int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[GPS_Data]
	WHERE  [ID_Data] = @ID_Data

	COMMIT
GO

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

IF OBJECT_ID('[dbo].[usp_UsersSelect]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_UsersSelect] 
END 
GO
CREATE PROC [dbo].[usp_UsersSelect] 
    @ID_User INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT [ID_User], [Username], [Password], [Email], [Fullname], [Mobile], [Company], [Cop_Phone], [Status] 
	FROM   [dbo].[Users] 
	WHERE  ([ID_User] = @ID_User OR @ID_User IS NULL) 

	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_UsersInsert]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_UsersInsert] 
END 
GO
CREATE PROC [dbo].[usp_UsersInsert] 
    @Username varchar(100),
    @Password varchar(100),
    @Email varchar(100),
    @Fullname varchar(100),
    @Mobile int,
    @Company text,
    @Cop_Phone int,
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Users] ([Username], [Password], [Email], [Fullname], [Mobile], [Company], [Cop_Phone], [Status])
	SELECT @Username, @Password, @Email, @Fullname, @Mobile, @Company, @Cop_Phone, @Status
	
	-- Begin Return Select <- do not remove
	SELECT [ID_User], [Username], [Password], [Email], [Fullname], [Mobile], [Company], [Cop_Phone], [Status]
	FROM   [dbo].[Users]
	WHERE  [ID_User] = SCOPE_IDENTITY()
	-- End Return Select <- do not remove
               
	COMMIT
GO
IF OBJECT_ID('[dbo].[usp_UsersUpdate]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_UsersUpdate] 
END 
GO
CREATE PROC [dbo].[usp_UsersUpdate] 
    @ID_User int,
    @Username varchar(100),
    @Password varchar(100),
    @Email varchar(100),
    @Fullname varchar(100),
    @Mobile int,
    @Company text,
    @Cop_Phone int,
    @Status int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Users]
	SET    [Username] = @Username, [Password] = @Password, [Email] = @Email, [Fullname] = @Fullname, [Mobile] = @Mobile, [Company] = @Company, [Cop_Phone] = @Cop_Phone, [Status] = @Status
	WHERE  [ID_User] = @ID_User
	
	-- Begin Return Select <- do not remove
	SELECT [ID_User], [Username], [Password], [Email], [Fullname], [Mobile], [Company], [Cop_Phone], [Status]
	FROM   [dbo].[Users]
	WHERE  [ID_User] = @ID_User	
	-- End Return Select <- do not remove

	COMMIT TRAN
GO
IF OBJECT_ID('[dbo].[usp_UsersDelete]') IS NOT NULL
BEGIN 
    DROP PROC [dbo].[usp_UsersDelete] 
END 
GO
CREATE PROC [dbo].[usp_UsersDelete] 
    @ID_User int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	DELETE
	FROM   [dbo].[Users]
	WHERE  [ID_User] = @ID_User

	COMMIT
GO

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

