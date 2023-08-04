using LuxsuryWhatches.Models;
using LuxuryWhaches.BisnessLayer.Concreate;
using LuxuryWhaches.DataAcsessLayer.EFRepository;
using LuxuryWhaches.EntityLayer.Concreate;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace LuxsuryWhatches.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminMailController : Controller
    {
        NewsletterManager nm = new NewsletterManager(new EFNewsletterDal());
        ContactManager contactManager = new ContactManager(new EFContactDal());
        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> values = (from x in nm.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.NewsLetterMail,
                                               Value = x.NewsLetterMail.ToString(),
                                           }).ToList();
            ViewBag.cat = values;
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailSendViewModel mail)
        {
            MimeMessage mimemessage = new MimeMessage();
            MailboxAddress mailboxfrom = new MailboxAddress("Luxury Watches Admin", "sehriyarhaciyev@gmail.com");
            MailboxAddress mailboxto = new MailboxAddress("User", mail.RecieverMail);
            mimemessage.From.Add(mailboxfrom);
            mimemessage.To.Add(mailboxto);
            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = mail.MailBody;
            mimemessage.Body = bodybuilder.ToMessageBody();
            mimemessage.Subject = mail.MailSubject;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("sehriyarhaciyev@gmail.com", "iqwwaimqqcuapdbd");
            smtpClient.Send(mimemessage);
            smtpClient.Disconnect(true);
           
            return RedirectToAction("Index");
        }

		[HttpGet]
		public IActionResult Contact()
		{
			List<SelectListItem> values = (from x in contactManager.TGetAll()
										   select new SelectListItem
										   {
											   Text = x.ContactSubject,
											   Value = x.ContactSubject.ToString(),
										   }).ToList();
			ViewBag.contact = values;
			return View();
		}
		[HttpPost]
		public IActionResult Contact(MailSendViewModel mail)
		{
			MimeMessage mimemessage = new MimeMessage();
			MailboxAddress mailboxfrom = new MailboxAddress("Luxury Watches Admin", "sehriyarhaciyev@gmail.com");
			MailboxAddress mailboxto = new MailboxAddress("User", mail.RecieverMail);
			mimemessage.From.Add(mailboxfrom);
			mimemessage.To.Add(mailboxto);
			var bodybuilder = new BodyBuilder();
			bodybuilder.TextBody = mail.MailBody;
			mimemessage.Body = bodybuilder.ToMessageBody();
			mimemessage.Subject = mail.MailSubject;
			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Connect("smtp.gmail.com", 587, false);
			smtpClient.Authenticate("sehriyarhaciyev@gmail.com", "iqwwaimqqcuapdbd");
			smtpClient.Send(mimemessage);
			smtpClient.Disconnect(true);

			return RedirectToAction("Index");
		}
	}
}
