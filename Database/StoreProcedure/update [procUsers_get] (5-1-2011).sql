set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
ALTER procedure [dbo].[procUsers_get](
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
		@Username = Username and 
		Status = 1
)
END

