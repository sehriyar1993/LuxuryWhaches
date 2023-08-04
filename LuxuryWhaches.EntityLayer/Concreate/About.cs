using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.EntityLayer.Concreate
{
	public class About
	{
		[Key] 
		public int AboutId { get; set; }
		public string AboutTitle { get; set; }
		public string AboutDescription { get; set; }
		public string AboutImage{ get; set; }
		public string AboutImage2{ get; set; }
		public string AboutImage3{ get; set; }
		public bool AboutStatus{ get; set; }
	}
}
