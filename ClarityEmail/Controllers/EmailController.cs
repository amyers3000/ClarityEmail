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

		[HttpGet("Logs")]
		public async Task<ActionResult<ServiceResponse<List<Email>>>> GetAll()
		{
			var response = await _emailRepo.GetAll();
			return response.Success ? Ok(response) : BadRequest(response);

		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<EmailDto>>> Send(EmailDto request)
		{
			var response = await _emailRepo.Send(request);
            return response.Success ? Ok(response) : BadRequest(response);

        }
	}

}