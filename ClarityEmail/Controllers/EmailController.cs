using System;
using ClarityEmail.Models;
using Microsoft.AspNetCore.Mvc;

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
		public ActionResult<List<Email>> Get()
		{
			return Ok();

		}

		[HttpPost]
		public ActionResult<List<Email>> Send()
		{
			return Ok();
		}
	}

}