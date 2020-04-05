using DeratMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailModel emailModel);

        Task SendEmailToSupport(EmailSupportModel emailSupportModel);
    }
}
