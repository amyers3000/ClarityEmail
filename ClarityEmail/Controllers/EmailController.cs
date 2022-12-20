using ClarityEmail.Models;
using Microsoft.AspNetCore.Mvc;
using EmailMethod;
using EmailMethod.DTOs;
using ClarityEmail.Data;

namespace ClarityEmail.Controllers
{
    [ApiController]
	[Route("api/[controller]")]

	public class EmailController : ControllerBase
	{
        private readonly IEmailRepository _emailRepo;

        public EmailController( IEmailRepository emailRepo )
		{
			_emailRepo = emailRepo;

        }

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Email>>>> GetAll()
		{
			
            return Ok(await _emailRepo.GetAll());

		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<EmailDto>>> Send(EmailDto request)
		{
			return Ok (await _emailRepo.Send(request));

		}
	}

}