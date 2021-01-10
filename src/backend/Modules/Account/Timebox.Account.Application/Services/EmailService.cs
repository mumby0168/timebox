using System;
using System.Net.Mail;
using Timebox.Account.Application.Interfaces.Services;

namespace Timebox.Account.Application.Services
{
    public class EmailService : IEmailService
    {
        public bool IsValidEmailAddress(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // ReSharper disable once CA1806
                new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}