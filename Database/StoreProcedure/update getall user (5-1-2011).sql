set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
ALTER procedure [dbo].[procUsers_getall]
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
	Status,
	 
		CASE Status when 0 then 'Cancel-icon24.PNG'
		when 1 then 'Check-icon24.PNG' end
	 as StatusImage
	
FROM  dbo.[Users]
END

