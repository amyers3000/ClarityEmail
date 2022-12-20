using System;
using EmailMethod.DTOs;

namespace EmailMethod
{
	public interface IEmailService
	{
        Task<bool> Send(EmailDto request, string username, string password);
		
	}
}

