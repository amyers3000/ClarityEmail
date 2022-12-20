using System;
namespace EmailMethod.DTOs;

	public class EmailDto
	{
    public string Recipient { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}

