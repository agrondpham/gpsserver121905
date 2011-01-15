USE GPSDatabase
if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procUsers_add]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procUsers_add]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procUsers_add] (
@Username as varchar(100),
@Password as varchar(100),
@Email as varchar(100),
@Fullname as varchar(100),
@Mobile as int,
@Company as text,
@Cop_Phone as int,
@Status as int
)
AS
BEGIN
INSERT INTO dbo.[Users](
Username,	
Password,	
Email,	
Fullname,	
Mobile,	
Company,	
Cop_Phone,	
Status	
)
VALUES(
@Username,
@Password,
@Email,
@Fullname,
@Mobile,
@Company,
@Cop_Phone,
@Status
	
	)
SELECT SCOPE_IDENTITY()
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procUsers_update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procUsers_update]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procUsers_update](
@Username as varchar(100),
@Password as varchar(100),
@Email as varchar(100),
@Fullname as varchar(100),
@Mobile as int,
@Company as text,
@Cop_Phone as int,
@Status as int
)
AS
BEGIN
UPDATE dbo.[Users] SET 
	Password = @Password,
	Email = @Email,
	Fullname = @Fullname,
	Mobile = @Mobile,
	Company = @Company,
	Cop_Phone = @Cop_Phone,
	Status = @Status
	
WHERE 	(
		@Username = Username 
 )
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procUsers_delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procUsers_delete]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procUsers_delete](
@Username as varchar(100)
)
AS
BEGIN 
DELETE dbo.[Users]
WHERE 	(
		@Username = Username 
 )
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procUsers_isexist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procUsers_isexist]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procUsers_isexist](
@Username as varchar(100)
)
AS
BEGIN
SELECT TOP 1
	Username
	
FROM  dbo.[Users]
WHERE 	(
		@Username = Username 
)
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procUsers_get]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procUsers_get]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procUsers_get](
@Username as varchar(100)
)
AS
BEGIN 
SELECT
	Username,
	Password,
	Email,
	Fullname,
	Mobile,
	Company,
	Cop_Phone,
	Status
	
FROM  dbo.[Users]
WHERE 	(
		@Username = Username 
)
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procUsers_getall]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procUsers_getall]

GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procUsers_getall]
AS
BEGIN
SELECT 	
	Username,
	Password,
	Email,
	Fullname,
	Mobile,
	Company,
	Cop_Phone,
	Status
	
FROM  dbo.[Users]
END
GO

if exists (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.[procUsers_getpaged]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.[procUsers_getpaged]
GO
--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
CREATE procedure dbo.[procUsers_getpaged](
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
	Username as varchar
)
DECLARE @SQL as nvarchar(4000)
SET @SQL = 'INSERT INTO #PageIndex (
Username
)'
SET @SQL = @SQL + ' SELECT'
IF @PageSize > 0
BEGIN
SET @SQL = @SQL + ' TOP ' + convert(nvarchar, @PageUpperBound)
End 
SET @SQL = @SQL + ' 
Username
'
SET @SQL = @SQL + ' FROM dbo.[Users]'
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
	O.Username,
	O.Password,
	O.Email,
	O.Fullname,
	O.Mobile,
	O.Company,
	O.Cop_Phone,
	O.Status
	
FROM  dbo.[Users] AS O, [#PageIndex] AS PageIndex
WHERE     (PageIndex.IndexID > @PageLowerBound)  AND (
	O.Username = PageIndex.Username 
)
ORDER BY PageIndex.IndexID
SET @SQL = 'SELECT COUNT(*) as TotalRecords'
SET @SQL = @SQL + ' FROM dbo.[Users]'
IF LEN(@WhereClause) > 0
BEGIN
SET @SQL = @SQL + ' WHERE ' + @WhereClause
End
exec sp_executesql @SQL
END 
GO

