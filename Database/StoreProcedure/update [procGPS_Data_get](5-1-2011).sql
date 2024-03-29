set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

--CREATEd:02/08/2010
--Author: daiduong19051986@gmail.com
ALTER procedure [dbo].[procGPS_Data_get](
@ID_Data as int = null,
@IMED_Device VARCHAR(100) = null,
@StartTime nvarchar(12) = null,
@StopTime nvarchar(12) = null
)
AS
BEGIN 
	if isnull(@StartTime, '') = '' set @StartTime = '01/01/1900'
	if isnull(@StopTime, '') = '' set @StopTime = '31/12/2080'
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
		isnull(@ID_Data,ID_Data) = ID_Data and
		isnull(@IMED_Device,IMED_Device) = IMED_Device and
		convert(datetime,Received_Data,103) BETWEEN Convert(datetime,@StartTime,103) AND Convert(datetime,@StopTime,103)
)
END

