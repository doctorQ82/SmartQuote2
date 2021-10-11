using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartQuote.Models
{
    public class SendMail
    {



        public static bool SendEmail(string agentCode, string strTo, string emailfrom, string strCC, string strBCC, string strSubject, string strBody, List<string> strAttachments, bool resend)
        {
            bool isSuccess = false;
            string errMsg = "";
            try
            {
                if (strTo != "")
                {
                    MailMessage insMail = new MailMessage();
                    insMail.From = new MailAddress(emailfrom.Replace(" ", ""));
                    insMail.To.Add(strTo);
                    insMail.Subject = strSubject;
                    insMail.Body = strBody;

                    if (!String.IsNullOrEmpty(strCC))
                    {
                        string[] mails = strCC.Split(',');
                        foreach (string mail in mails)
                        {
                            insMail.CC.Add(mail);
                        }
                    }

                    if (!String.IsNullOrEmpty(strBCC))
                    {
                        string[] mailsbcc = strBCC.Split(',');
                        foreach (string mailbcc in mailsbcc)
                        {
                            insMail.Bcc.Add(mailbcc);
                        }
                    }

                    insMail.IsBodyHtml = true;

                    if (strAttachments != null)
                    {
                        foreach (string PathFile in strAttachments)
                        {
                            if (File.Exists(PathFile))
                            {
                                string extension = Path.GetExtension(PathFile);
                                if (extension == ".pdf" || extension == ".xlsx" || extension == ".txt")
                                {
                                    insMail.Attachments.Add(new Attachment(PathFile.Trim()));
                                }
                            }
                        }
                    }

                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "10.132.168.19";
                    smtp.EnableSsl = false;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential("Noreply@falconinsurance.co.th", "");
                    smtp.Port = 25;


                    smtp.Send(insMail);
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
         
            }

            return isSuccess;
        }


    }

}
