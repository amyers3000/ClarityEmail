using System;
namespace ClarityEmail.Models
{
	public class Email
	{
		public int Id { get; set; }
		public string Sender { get; set; } = string.Empty;
		public string Recipient { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
		public DateTime Date { get; set; } = DateTime.Now;
		public bool Success { get; set; } = false;

    }
}

