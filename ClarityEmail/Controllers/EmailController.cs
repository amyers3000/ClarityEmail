using System;
using ClarityEmail.Models;
using Microsoft.AspNetCore.Mvc;
using EmailMethod;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;
using MailKit.Security;

namespace ClarityEmail.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class EmailController : ControllerBase
	{
		public EmailController()
		{
		}

		[HttpGet]
		public ActionResult<int> Get()
		{
			
			return Ok();

		}

		[HttpPost]
		public IActionResult Send(string body)
		{

			return Ok();
		}
	}

}