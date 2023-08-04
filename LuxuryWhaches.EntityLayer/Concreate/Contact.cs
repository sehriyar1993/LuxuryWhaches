using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.EntityLayer.Concreate
{
	public class Contact
	{
		[Key] 
		public int ContactId { get; set; }
		public string ContactNaame { get; set; }
		public string ContactSubject { get; set; }
		public string ContactBody { get; set; }
		public string ContactPhone { get; set; }
		public bool ContactStatus { get; set; }
		public DateTime ContactDate { get; set; }
	}
}
