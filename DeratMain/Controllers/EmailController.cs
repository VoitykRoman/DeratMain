using DeratMain.Interfaces.Services;
using DeratMain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeratMain.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            this._emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmailModel emailModel)
        {
            await _emailService.SendEmailAsync(emailModel);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> SendEmailToSupport(EmailSupportModel emailModel)
        {
            await _emailService.SendEmailToSupport(emailModel);
            return Ok();
        }

    }
}
