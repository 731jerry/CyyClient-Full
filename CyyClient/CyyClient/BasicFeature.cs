using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

using System.Security.Cryptography;

namespace CyyService
{
    class BasicFeature
    {
        public static string SendMail(string topic, string attachmentUrl, string body, bool isHTML)
        {
            string userName = "3055054184";
            string password = "CYY3055054184";
            string sendAddress = userName + "@qq.com";
            //string receiveAddress = "993929135@qq.com";
            string receiveAddress = "993929135@qq.com";

            //body = "[此邮件由系统自动发出! 请勿回复!]<br><br>" + body + "<br><br><br>- 彩盈盈技术部";
            //string[] sendUsername = sendAddress.Split('@');
            //SmtpClient client = new SmtpClient("smtp." + sendUsername[1].ToString());   //设置邮件协议

            SmtpClient client = new SmtpClient("smtp.qq.com");   //设置邮件协议

            client.UseDefaultCredentials = false;//这一句得写前面
            //client.EnableSsl = true;//服务器不支持SSL连接

            client.DeliveryMethod = SmtpDeliveryMethod.Network; //通过网络发送到Smtp服务器
            client.Credentials = new NetworkCredential(userName.Trim(), password.Trim()); //通过用户名和密码 认证
            MailMessage mmsg = new MailMessage(new MailAddress(sendAddress), new MailAddress(receiveAddress)); //发件人和收件人的邮箱地址
            mmsg.CC.Add("70269387@qq.com, gm-zhou@foxmail.com");
            mmsg.Subject = topic;//邮件主题
            mmsg.SubjectEncoding = Encoding.UTF8;//主题编码
            mmsg.Body = body;//邮件正文
            mmsg.BodyEncoding = Encoding.UTF8;//正文编码
            mmsg.IsBodyHtml = isHTML;//设置为HTML格式           
            mmsg.Priority = MailPriority.High;//优先级
            if (attachmentUrl.Trim() != "")
            {
                mmsg.Attachments.Add(new Attachment(attachmentUrl));//增加附件
            }
            try
            {
                client.Send(mmsg);
                return "已发送信息给彩盈盈管理员!";
            }
            catch (Exception ee)
            {
                return "发送错误!" + ee.Message;
            }
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static string FormatID(string originalString, int bit, string replaceString)
        {
            string result = "";
            int gap = 0;
            string temp = "";
            if (originalString.Length < bit)
            {
                gap = bit - originalString.Length;
                for (int i = 0; i < gap; i++)
                {
                    temp += replaceString;
                }
                result = temp + originalString;
            }
            return result;
        }
    }
}
