using System;
namespace ClarityEmail.Models
{
	public class ViewEmailDto
	{
		
        public string Sender { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty; 
        public bool Success { get; set; }
    
	}
}

