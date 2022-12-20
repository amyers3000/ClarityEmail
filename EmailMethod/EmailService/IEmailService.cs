using System;
using EmailMethod.DTOs;

namespace EmailMethod
{
	public interface IEmailService
	{
		void Send(EmailDto request, string username, string password);
		
	}
}

