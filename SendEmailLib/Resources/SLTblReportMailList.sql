SELECT tblML.*,
       tblRN.ReportName,
       tblMSP.Permissions
FROM tblMailList AS tblML
LEFT JOIN tblReportName AS tblRN ON tblRN.ID = ReportNameID
LEFT JOIN tblMailSendPermission AS tblMSP ON tblMSP.ID = MailSendPermissionID
WHERE ReportName = @ReportName
ORDER BY MailSendPermissionID, Sort