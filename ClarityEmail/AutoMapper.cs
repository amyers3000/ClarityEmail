using System;
using AutoMapper;
using ClarityEmail.Models;
using EmailMethod.DTOs;

namespace ClarityEmail
{
	public class AutoMapper : Profile
    {
		public AutoMapper()
		{
			CreateMap<EmailDto,Email>();
		}
	}
}

