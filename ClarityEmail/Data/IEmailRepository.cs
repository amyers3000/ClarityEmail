using System;
using ClarityEmail.Models;
using EmailMethod;
using EmailMethod.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClarityEmail.Data
{
	public interface IEmailRepository
	{
        Task<ActionResult<ServiceResponse<List<Email>>>> GetAll();

        Task<ActionResult<ServiceResponse<EmailDto>>> Send(EmailDto request);

    }
}

