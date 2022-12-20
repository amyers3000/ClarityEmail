using System;
using EmailMethod.Models;

namespace EmailMethod
{
	public interface IEmailService
	{
        Task<ServiceResponse<EmailDto>> Send(EmailDto request, string username, string password);
		
	}
}

