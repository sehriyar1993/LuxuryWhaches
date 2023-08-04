using LuxuryWhaches.EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.DataAcsessLayer.Concreate
{
	public class Context: IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=.\\MSSQLSERVER19; database=LuxuryWhachesDB; integrated security = true;  Trusted_Connection=True;");
		}
		public DbSet<About> Abouts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<NewsLetter> NewsLetters { get; set; }
		public DbSet<ProductColor> ProductColors { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Brand> Brands { get; set; }
	}
}
