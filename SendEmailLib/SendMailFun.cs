using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace SendEmailLib
{
    // [ASP.net / C#] .Net 完整的Mail寄信(Send Mail)功能 歡迎直接Copy Paste
    // https://dotblogs.com.tw/shadow/archive/2011/05/23/25887.aspx
    class SendMailFun
    {
        /// <summary>
        /// 寄信smtp server
        /// </summary>
        private string SmtpServer
        {
            get
            {
                return "mail.vscinemas.com.tw";
            }
        }
        /// <summary>
        /// 寄信smtp server的Port，預設25
        /// </summary>
        private int SmtpPort
        {
            get
            {
                return 25;
            }
        }
        /// <summary>
        /// Send Mail
        /// </summary>
        public SendMailFun()
        {
        }

        /// <summary>
        /// Run
        /// </summary>
        /// <param name="InMailFrom">Mail From</param>
        /// <param name="InlMailTos">Mail Tos</param>
        /// <param name="InlCcMail">副本</param>
        /// <param name="InlBccMail">密件副本</param>
        /// <param name="InlAttachment">附件</param>
        /// <param name="InSubject">信件主旨</param>
        /// <param name="InBody">信件內容</param>
        /// <returns>true or false</returns>
        public bool Run(string InMailFrom,
                        List<string> InlMailTos,
                        List<string> InlCcMail,
                        List<string> InlBccMail,
                        List<Attachment> InlAttachment,
                        string InSubject,
                        string InBody,
                        bool IsBodyHtml = false)
        {
            //命名空間： System.Web.Mail已過時，http://msdn.microsoft.com/zh-tw/library/system.web.mail.mailmessage(v=vs.80).aspx
            //建立MailMessage物件
            using (MailMessage mms = new MailMessage())
            {
                // 指定一位寄信人 MailAddress
                mms.From = new MailAddress(InMailFrom);

                //End if (MailTos !=null)//防呆
                foreach (string item in InlMailTos)
                {
                    //加入信件的收信人(們)address
                    if (!string.IsNullOrEmpty(item.Trim()))
                    {
                        mms.To.Add(new MailAddress(item.Trim()));
                    }
                }

                //End if (Ccs!=null) //防呆
                foreach (string item in InlCcMail)
                {
                    if (!string.IsNullOrEmpty(item.Trim()))
                    {
                        //加入信件的副本(們)address
                        mms.CC.Add(new MailAddress(item.Trim()));
                    }
                }

                //End if (Ccs!=null) //防呆
                foreach (string item in InlBccMail)
                {
                    if (!string.IsNullOrEmpty(item.Trim()))
                    {
                        //加入信件的密件副本(們)address
                        mms.Bcc.Add(new MailAddress(item.Trim()));
                    }
                }

                //End if (filePaths!=null)//防呆
                foreach (Attachment item in InlAttachment)
                {   //有夾帶檔案
                    if (item != null)
                    {
                        //加入信件的夾帶檔案
                        mms.Attachments.Add(item);
                    }
                }

                //信件主旨
                mms.Subject = InSubject;
                mms.SubjectEncoding = Encoding.UTF8;

                //信件內容
                mms.Body = InBody;
                mms.BodyEncoding = Encoding.UTF8;

                //信件內容 是否採用Html格式
                mms.IsBodyHtml = IsBodyHtml;

                // Smtp Client
                using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))//或公司、客戶的smtp_server
                {
#if fa
                    if (!string.IsNullOrEmpty(mailAccount) && !string.IsNullOrEmpty(mailPwd))//.config有帳密的話
                    {//寄信要不要帳密？眾說紛紜Orz，分享一下經驗談....

                        //網友阿尼尼:http://www.dotblogs.com.tw/kkc123/archive/2012/06/26/73076.aspx
                        //※公司內部不用認證,寄到外部信箱要特別認證 Account & Password

                        //自家公司MIS:
                        //※要看smtp server的設定呀~

                        //結論...
                        //※程式在客戶那邊執行的話，問客戶，程式在自家公司執行的話，問自家公司MIS，最準確XD
                        client.Credentials = new NetworkCredential(mailAccount, mailPwd);//寄信帳密
                    }
#endif
                    try
                    {
                        client.Send(mms);//寄出一封信
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }//end using 
                //釋放每個附件，才不會Lock住
                if (mms.Attachments != null && mms.Attachments.Count > 0)
                {
                    for (int i = 0; i < mms.Attachments.Count; i++)
                    {
                        mms.Attachments[i].Dispose();
                        //mms.Attachments[i] = null;
                    }
                }
#if fa
                #region 要刪除附檔
                if (deleteFileAttachment && filePaths != null && filePaths.Length>0)
                {

                    foreach (string filePath in filePaths)
                    {
                        File.Delete(filePath.Trim());
                    }

                }
                #endregion
#endif
            }

            return true;
        }
    }
}
