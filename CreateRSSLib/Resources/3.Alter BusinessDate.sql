DECLARE @Amount int
DECLARE @StartDate DateTime,@EndDate DateTime

SET @Amount=0

--convert(varchar(10),getdate(),120) 
WHILE (@Amount<125)
BEGIN
  if (@Amount=0)
    BEGIN
      SET @StartDate={fn CURRENT_DATE()}+' 06:00'
    End
  ELSE
    BEGIN
      SET @StartDate=DATEADD(day, 1,@StartDate)
    End
  
  Set @EndDate=DATEADD(day, 1,@StartDate)
  
  UPDATE [VSWEB].[dbo].[T_movieSessions]
   SET [BusinessDate] = @StartDate
   WHERE [Session_dtmDate_Time] >=@StartDate and [Session_dtmDate_Time] < @EndDate

SET @Amount=@Amount+1

End