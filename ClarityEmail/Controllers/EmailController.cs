using System;
using ClarityEmail.Models;
using Microsoft.AspNetCore.Mvc;
using EmailMethod;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;
using MailKit.Security;
using EmailMethod.DTOs;

namespace ClarityEmail.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class EmailController : ControllerBase
	{
		private readonly IEmailService _emailService;
		private readonly IConfiguration _config;

		public EmailController( IEmailService emailService, IConfiguration config )
		{
			_emailService = emailService;
			_config = config;


        }

		[HttpGet]
		public ActionResult<int> Get()
		{
			
			return Ok();

		}

		[HttpPost]
		public async Task<IActionResult> Send(EmailDto request)
		{
            var success = await _emailService.Send(request, _config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
			if (success)
			{
				return Ok();
			}

			return BadRequest();
		}
	}

}