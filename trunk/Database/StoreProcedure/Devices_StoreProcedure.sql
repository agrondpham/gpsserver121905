USE GPSDatabase
if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procDevices_add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procDevices_add]
GO
--CREATEd:02/08/2010
--Author: nnamthach@gmail.com
CREATE procedure dbo.[procDevices_add] (
@IMED_Device as int,
@ID_User as int,
@Status as int
)
AS
BEGIN
INSERT INTO dbo.[Devices](
IMED_Device,	
ID_User,	
Status	
)
VALUES(
@IMED_Device,
@ID_User,
@Status
	
	)
SELECT SCOPE_IDENTITY()
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procDevices_update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procDevices_update]
GO
--CREATEd:02/08/2010
--Author: nnamthach@gmail.com
CREATE procedure dbo.[procDevices_update](
@IMED_Device as int,
@ID_User as int,
@Status as int
)
AS
BEGIN
UPDATE dbo.[Devices] SET 
	ID_User = @ID_User,
	Status = @Status
	
WHERE 	(
		@IMED_Device = IMED_Device 
 )
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procDevices_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procDevices_delete]
GO
--CREATEd:02/08/2010
--Author: nnamthach@gmail.com
CREATE procedure dbo.[procDevices_delete](
@IMED_Device as int
)
AS
BEGIN 
DELETE dbo.[Devices]
WHERE 	(
		@IMED_Device = IMED_Device 
 )
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procDevices_isexist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procDevices_isexist]
GO
--CREATEd:02/08/2010
--Author: nnamthach@gmail.com
CREATE procedure dbo.[procDevices_isexist](
@IMED_Device as int
)
AS
BEGIN
SELECT TOP 1
	IMED_Device
	
FROM  dbo.[Devices]
WHERE 	(
		@IMED_Device = IMED_Device 
)
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procDevices_get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procDevices_get]
GO
--CREATEd:02/08/2010
--Author: nnamthach@gmail.com
CREATE procedure dbo.[procDevices_get](
@IMED_Device as int
)
AS
BEGIN 
SELECT
	IMED_Device,
	ID_User,
	Status
	
FROM  dbo.[Devices]
WHERE 	(
		@IMED_Device = IMED_Device 
)
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procDevices_getall]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procDevices_getall]

GO
--CREATEd:02/08/2010
--Author: nnamthach@gmail.com
CREATE procedure dbo.[procDevices_getall]
AS
BEGIN
SELECT 	
	IMED_Device,
	ID_User,
	Status
	
FROM  dbo.[Devices]
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procDevices_getpaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procDevices_getpaged]
GO
--CREATEd:02/08/2010
--Author: nnamthach@gmail.com
CREATE procedure dbo.[procDevices_getpaged](
@WhereClause nvarchar (4000)  ,
@OrderBy varchar (2000)  ,
@PageIndex int   ,
@PageSize int  
)
AS
BEGIN
DECLARE @PageLowerBound int
DECLARE @PageUpperBound int
SET @PageLowerBound = @PageSize * @PageIndex
SET @PageUpperBound = @PageLowerBound + @PageSize
CREATE Table #PageIndex
(
 [IndexId] int IDENTITY (1, 1) NOT NULL,
	IMED_Device as int
)
DECLARE @SQL as nvarchar(4000)
SET @SQL = 'INSERT INTO #PageIndex (
IMED_Device
)'
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
End 
SET @SQL = @SQL + ' 
IMED_Device
'
SET @SQL = @SQL + ' FROM dbo.[Devices]'
IF LEN(@WhereClause) > 0
BEGIN
SET @SQL = @SQL + ' WHERE ' + @WhereClause
End
IF LEN(@OrderBy) > 0
BEGIN
SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
End
exec sp_executesql @SQL
SELECT 	
	O.IMED_Device,
	O.ID_User,
	O.Status
	
FROM  dbo.[Devices] AS O, [#PageIndex] AS PageIndex
WHERE     (PageIndex.IndexID > @PageLowerBound)  AND (
	O.IMED_Device = PageIndex.IMED_Device 
)
ORDER BY PageIndex.IndexID
SET @SQL = 'SELECT COUNT(*) as TotalRecords'
SET @SQL = @SQL + ' FROM dbo.[Devices]'
IF LEN(@WhereClause) > 0
BEGIN
SET @SQL = @SQL + ' WHERE ' + @WhereClause
End
exec sp_executesql @SQL
END 
GO

