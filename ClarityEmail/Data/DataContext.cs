using System;
using ClarityEmail.Models;
using Microsoft.EntityFrameworkCore;

namespace ClarityEmail.Data
{
	public class DataContext : DbContext
	{

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

        public DbSet<Email> Emails { get; set; }

    }
}

