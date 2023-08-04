using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryWhaches.EntityLayer.Concreate
{
	public class NewsLetter
	{
		[Key] 
		public int NewsLetterId { get; set; }
		public string NewsLetterMail { get; set; }
		public bool Status { get; set; }
	}
}
