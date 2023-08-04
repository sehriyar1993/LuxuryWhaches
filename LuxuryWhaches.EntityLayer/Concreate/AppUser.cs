using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.EntityLayer.Concreate
{
	public class AppUser:IdentityUser<int>
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string ImageUrl { get; set; }
        public double ComfirmCode { get; set; }
        public List<Order> Orders { get; set; } 

    }
}
