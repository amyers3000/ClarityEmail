using System;
using ClarityEmail.Models;
using Microsoft.AspNetCore.Mvc;
using EmailMethod;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;
using MailKit.Security;
using EmailMethod.DTOs;
using ClarityEmail.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ClarityEmail.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class EmailController : ControllerBase
	{
		private readonly IEmailService _emailService;
		private readonly IConfiguration _config;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmailController( IEmailService emailService, IConfiguration config, DataContext context, IMapper mapper )
		{
			_emailService = emailService;
			_config = config;
			_context = context;
			_mapper = mapper;

        }

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Email>>>> GetAll()
		{
			var response = new ServiceResponse<List<Email>>();
			var emailList = await _context.Emails.ToListAsync();
			response.Data = emailList;
            return Ok(response);

		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<EmailDto>>> Send(EmailDto request)
		{
            var response = await _emailService.Send(request, _config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);

			Email email = _mapper.Map<Email>(request);
			email.Sender = _config.GetSection("EmailUsername").Value;
			email.Success = response.Success;

			_context.Emails.Add(email);
			await _context.SaveChangesAsync();

            if (response.Success)
			{
				return Ok(response);
			}

			return BadRequest(response);
		}
	}

}