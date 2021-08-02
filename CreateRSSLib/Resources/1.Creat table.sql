/****** Object:  Table [dbo].[T_movieCinemas]    Script Date: 10/05/2010 13:43:08 ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_movieCinemas]') AND type in (N'U'))
--DROP TABLE [dbo].[T_movieCinemas]
--GO


--SELECT VFD.* into T_movieCinemas FROM 
--(SELECT * FROM [VISTAIT].[dbo].[V_VISTAIT_Films])VFD

SELECT TOP (100) PERCENT Cinema_strID,
                         Cinema_strOrder,
                         CinOperator_strCode,
                         Cinema_name,
                         Movie_HOFilmCode,
                         Movie_strID,
                         Movie_strName,
                         Movie_strName_2,
                         Film_intDuration,
                         Movie_strRating,
                         Movie_strRating_2,
                         Film_dtmOpeningDate,
                         dtmAdvanceBookingDate
FROM dbo.V_VISTAIT_movieSessions
GROUP BY Cinema_strID,
         CinOperator_strCode,
         Cinema_name,
         Movie_strID,
         Movie_strName,
         Movie_strName_2,
         Movie_strRating,
         Movie_strRating_2,
         Movie_HOFilmCode,
         Film_intDuration,
         Cinema_strOrder,
         Film_dtmOpeningDate,
         dtmAdvanceBookingDate
ORDER BY Film_dtmOpeningDate DESC,
         Movie_HOFilmCode,
         CONVERT(int, Cinema_strOrder)

/****** Object:  Table [dbo].[T_movieSessions]    Script Date: 10/01/2010 17:11:15 ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_movieSessions]') AND type in (N'U'))
--DROP TABLE [dbo].[T_movieSessions]
--GO

--DECLARE @StartDate as DateTime
--SET @StartDate = getdate()

--SELECT VFD.* into T_movieSessions FROM 
--(SELECT * FROM [VISTAIT].[dbo].[V_VISTAIT_movieSessions])VFD
--where Session_dtmDate_Time >= @StartDate

SELECT C.Cinema_strID,
       C.CinOperator_strCode,
       C.Cinema_strOrder,
       C.Cinema_name,
       M.Movie_HOFilmCode,
       M.Movie_strID,
       S.Session_strID,
       vf.strType,
       REPLACE(M.Movie_strName, '''', '') AS Movie_strName,
       REPLACE(M.Movie_strName_2, '''', '') AS Movie_strName_2,
       F.Film_intDuration,
       M.Movie_strRating,
       M.Movie_strRating_2,
       S.Screen_bytNum,
       S.Session_decSeats_Available,
       S.Session_dtmDate_Time,
       S.Session_strSalesChannels,
       F.Film_dtmOpeningDate,
       fo.dtmAdvanceBookingDate
FROM
  (SELECT dbo.tblCinema.Cinema_strID,
          dbo.tblCinema_Operator.CinOperator_strCode,
          dbo.tblCinema.Cinema_strOrder,
          dbo.tblCinema.Cinema_strName AS Cinema_name
   FROM dbo.tblCinema
   INNER JOIN dbo.tblCinema_Operator ON dbo.tblCinema.Cinema_strID = dbo.tblCinema_Operator.Cinema_strID
   WHERE (dbo.tblCinema_Operator.CinOperator_strDefault = 'Y')
     OR (RIGHT(dbo.tblCinema_Operator.CinOperator_strHOOperatorCode, 8) = 'GC      ')
     OR (RIGHT(dbo.tblCinema_Operator.CinOperator_strHOOperatorCode, 8) = 'MP      ')
     OR (RIGHT(dbo.tblCinema_Operator.CinOperator_strHOOperatorCode, 10) = 'MUC       ')) AS C
INNER JOIN dbo.tblMovies AS M ON M.Cinema_strID = C.Cinema_strID
INNER JOIN dbo.tblFilm AS F ON F.Film_strHOFilmCode = M.Movie_HOFilmCode
INNER JOIN dbo.tblSessions AS S ON S.Movie_strID = M.Movie_strID
AND S.Cinema_strID = C.Cinema_strID
AND S.CinOperator_strCode = C.CinOperator_strCode
LEFT OUTER JOIN dbo.V_FilmAdvanceOpendate AS fo ON C.Cinema_strID = fo.Cinema_strID
AND M.Movie_strID = fo.Movie_strID
LEFT OUTER JOIN VSWEB.dbo.V_Film AS vf ON M.Movie_strID = vf.strHOCode
WHERE (S.Session_strSalesChannels LIKE '%WWW%')
  AND (S.Session_dtmDate_Time > CONVERT(varchar(16), GETDATE(), 120))
  AND Session_dtmDate_Time >= @StartDate




SELECT M.Cinema_strID,
       M.Movie_strID,
       M.Movie_strName_2 AS Movie_Name,
       M.Movie_HOFilmCode,
       CONVERT(varchar, ABD.dtmAdvanceBookingDate, 120) AS dtmAdvanceBookingDate
FROM dbo.tblMovies AS M
INNER JOIN dbo.tblMovieSalesProfile AS MP ON M.Movie_strID = MP.Movie_strCode
AND M.Cinema_strID = MP.Cinema_strID
INNER JOIN dbo.tblAdvanceBookingDate AS ABD ON ABD.MovieSalesProfile_intID = MP.MovieSalesProfile_intID
AND MP.Cinema_strID = ABD.Cinema_strID
WHERE (CONVERT(varchar, ABD.dtmAdvanceBookingDate, 120) > GETDATE())
GROUP BY M.Movie_strID,
         M.Movie_strName_2,
         M.Movie_HOFilmCode,
         CONVERT(varchar, ABD.dtmAdvanceBookingDate, 120),
         M.Cinema_strID