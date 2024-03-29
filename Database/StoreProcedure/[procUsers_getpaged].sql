set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
ALTER procedure [dbo].[procUsers_getpaged](
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
 [IndexId] int IDENTITY (1, 1) NOT NULL,Username varchar(100)
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
WHERE     (PageIndex.IndexID > @PageLowerBound)  
AND (
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


