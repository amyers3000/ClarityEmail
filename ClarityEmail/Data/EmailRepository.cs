using System;
using AutoMapper;
using ClarityEmail.Models;
using EmailMethod;
using EmailMethod.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ClarityEmail.Data
{
	public class EmailRepository : IEmailRepository
	{
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmailRepository(IEmailService emailService, IConfiguration config, DataContext context, IMapper mapper)
        {
            _emailService = emailService;
            _config = config;
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<Email>>> GetAll()
        {
            var response = new ServiceResponse<List<Email>>();
            try
            {
                var emailList = await _context.Emails.ToListAsync();
                response.Data = emailList;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<EmailDto>> Send(EmailDto request)
        {
            
            var response = await _emailService.Send(request, _config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);

            try
            {
                Email email = _mapper.Map<Email>(request);
                email.Sender = _config.GetSection("EmailUsername").Value;
                email.Success = response.Success;

                _context.Emails.Add(email);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

    }
}

