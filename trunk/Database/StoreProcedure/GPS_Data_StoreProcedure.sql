USE GPSDatabase
if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procGPS_Data_add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procGPS_Data_add]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procGPS_Data_add] (
@IMED_Device as int,
@Longitude as float,
@Latitude as float,
@Speed as float,
@Received_Data as varchar(100),
@Status as int
)
AS
BEGIN
INSERT INTO dbo.[GPS_Data](
IMED_Device,	
Longitude,	
Latitude,	
Speed,	
Received_Data,	
Status	
)
VALUES(
@IMED_Device,
@Longitude,
@Latitude,
@Speed,
@Received_Data,
@Status
	
	)
SELECT SCOPE_IDENTITY()
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procGPS_Data_update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procGPS_Data_update]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procGPS_Data_update](
@ID_Data as int,
@IMED_Device as int,
@Longitude as float,
@Latitude as float,
@Speed as float,
@Received_Data as varchar(100),
@Status as int
)
AS
BEGIN
UPDATE dbo.[GPS_Data] SET 
	Longitude = @Longitude,
	Latitude = @Latitude,
	Speed = @Speed,
	Received_Data = @Received_Data,
	Status = @Status,
	IMED_Device = @IMED_Device
	
WHERE 	(
		@ID_Data = ID_Data 
 )
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procGPS_Data_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procGPS_Data_delete]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procGPS_Data_delete](
@ID_Data as int
)
AS
BEGIN 
DELETE dbo.[GPS_Data]
WHERE 	(
		@ID_Data = ID_Data 
 )
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procGPS_Data_isexist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procGPS_Data_isexist]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procGPS_Data_isexist](
@ID_Data as int
)
AS
BEGIN
SELECT TOP 1
	ID_Data
	
FROM  dbo.[GPS_Data]
WHERE 	(
		@ID_Data = ID_Data 
)
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procGPS_Data_get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procGPS_Data_get]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procGPS_Data_get](
@ID_Data as int
)
AS
BEGIN 
SELECT
	ID_Data,
	IMED_Device,
	Longitude,
	Latitude,
	Speed,
	Received_Data,
	Status
	
FROM  dbo.[GPS_Data]
WHERE 	(
		@ID_Data = ID_Data 
)
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procGPS_Data_getall]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procGPS_Data_getall]

GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procGPS_Data_getall]
AS
BEGIN
SELECT 	
	ID_Data,
	IMED_Device,
	Longitude,
	Latitude,
	Speed,
	Received_Data,
	Status
	
FROM  dbo.[GPS_Data]
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procGPS_Data_getpaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procGPS_Data_getpaged]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procGPS_Data_getpaged](
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
	ID_Data as int
)
DECLARE @SQL as nvarchar(4000)
SET @SQL = 'INSERT INTO #PageIndex (
ID_Data
)'
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
End 
SET @SQL = @SQL + ' 
ID_Data
'
SET @SQL = @SQL + ' FROM dbo.[GPS_Data]'
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
	O.ID_Data,
	O.IMED_Device,
	O.Longitude,
	O.Latitude,
	O.Speed,
	O.Received_Data,
	O.Status
	
FROM  dbo.[GPS_Data] AS O, [#PageIndex] AS PageIndex
WHERE     (PageIndex.IndexID > @PageLowerBound)  AND (
	O.ID_Data = PageIndex.ID_Data 
)
ORDER BY PageIndex.IndexID
SET @SQL = 'SELECT COUNT(*) as TotalRecords'
SET @SQL = @SQL + ' FROM dbo.[GPS_Data]'
IF LEN(@WhereClause) > 0
BEGIN
SET @SQL = @SQL + ' WHERE ' + @WhereClause
End
exec sp_executesql @SQL
END 
GO

