SELECT tblML.*,
       tblRN.NameEn,
       tblMSP.Permissions
FROM tblDistributorMailList AS tblML
LEFT JOIN tblDistributor AS tblRN ON tblRN.ID = DistributorID
LEFT JOIN tblMailSendPermission AS tblMSP ON tblMSP.ID = MailSendPermissionID
WHERE NameEn = @NameEn
ORDER BY MailSendPermissionID, Sort