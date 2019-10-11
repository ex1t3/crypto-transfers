using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL.DbRepository;
using MailKit.Net.Smtp;
using MimeKit;
using Model.Models;

namespace Service.Services
{
    public interface IEmailService
    {
        Task<string> GenerateVerificationCodeAsync(int userId);
        Task<bool> SendEmailAsync(string email, string subject, string message);

    }

    public class EmailService : IEmailService
    {
        private static string _emailAddress = "noreply@islb.one";
        private static string _password = "1QTGPFaSNpP5e5Q@@@";
        private static string _server = "mail.islb.one";
        private static int _port = 465;
        private static bool _isSsl = true;
        public async Task<string> GenerateVerificationCodeAsync(int userId)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(userId + DateTime.Now.ToBinary().ToString()));

                foreach (Byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("ISLB TRANSFERS", _emailAddress));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_server, _port, _isSsl);
                await client.AuthenticateAsync(_emailAddress, _password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
                return true;
            }
        }
    }

    
}
