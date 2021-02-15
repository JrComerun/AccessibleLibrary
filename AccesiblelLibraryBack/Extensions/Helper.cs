﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Extensions
{
    public static class Helper
    {
        public static void SendMessage(string messageSubject, string messageBody , string mailTo)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("imbackend4000@gmail.com", "backend318");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage message = new MailMessage("imbackend4000@gmail.com", mailTo);
            message.Subject = messageSubject;

            message.Body = messageBody;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            client.Send(message);
        }
    }
}
