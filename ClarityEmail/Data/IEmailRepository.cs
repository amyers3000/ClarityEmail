using System;
using ClarityEmail.Models;
using EmailMethod;
using EmailMethod.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClarityEmail.Data
{
	public interface IEmailRepository
	{
        Task<ServiceResponse<List<Email>>> GetAll();

        Task<ServiceResponse<EmailDto>> Send(EmailDto request);

    }
}

