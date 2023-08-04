using LuxsuryWhatches.Models;
using LuxuryWhaches.EntityLayer.Concreate;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace LuxsuryWhatches.Controllers
{
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[AllowAnonymous]
		[HttpGet]
		public IActionResult SingUp()
		{
			return View();
		}
		[AllowAnonymous]

		[HttpPost]
		public async Task<IActionResult> SingUp(AppUserRegisterViewModel p)
		{
			if(ModelState.IsValid)
			{
				Random random = new Random();
				int code;
				code = random.Next(100000, 1000000);
				AppUser appUser = new AppUser()
				{
					Name = p.Name,
					UserName = p.Username,
					Surname = p.Surname,
					Email = p.Email,
					ComfirmCode = code,
					About = p.About,
					City = p.City,
					Adress = p.Adress,
					ImageUrl = p.ImageUrl
				};
				if (p.Password == p.RePassword)
				{
					var result = await _userManager.CreateAsync(appUser, p.Password);

					if (result.Succeeded)
					{
						MimeMessage mimemessage = new MimeMessage();
						MailboxAddress mailboxfrom = new MailboxAddress("Luxury Watches Admin", "sehriyarhaciyev@gmail.com");
						MailboxAddress mailboxto = new MailboxAddress("User", appUser.Email);
						mimemessage.From.Add(mailboxfrom);
						mimemessage.To.Add(mailboxto);
						var bodybuilder = new BodyBuilder();
						bodybuilder.TextBody = "Qeydiyat üçün 6 rəqəmli kodunuz:" + code;
						mimemessage.Body = bodybuilder.ToMessageBody();
						mimemessage.Subject = "Təsdiqləmə Kodu";
						SmtpClient smtpClient = new SmtpClient();
						smtpClient.Connect("smtp.gmail.com", 587, false);
						smtpClient.Authenticate("sehriyarhaciyev@gmail.com", "iqwwaimqqcuapdbd");
						smtpClient.Send(mimemessage);
						smtpClient.Disconnect(true);
						TempData["Mail"] = p.Email;
						return RedirectToAction("Index", "EmaiConfirmed");
					}
					else
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError("", item.Description);
						}
					}

				}
				
			}
			return View();
		}
		[AllowAnonymous]

		[HttpGet]
		public IActionResult SingIn()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]

		public async Task<IActionResult> SingIn(LoginViewModel p)
		{
			var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
			if (result.Succeeded)
			{
				var user = await _userManager.FindByNameAsync(p.username);
				if(user.EmailConfirmed== true)
				{
					return RedirectToAction("MyAccount");
				}
				else
				{
					return RedirectToAction("Index", "EmaiConfirmed");
				}
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> MyAccount()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			AppUserRegisterViewModel p = new AppUserRegisterViewModel();
			p.Email = user.Email;
			p.City = user.City;
			p.Surname = user.Surname;
			p.Adress= user.Adress;
			p.ImageUrl= user.ImageUrl;
			p.Username = user.UserName;
			p.Name = user.Name;
			p.About = user.About;
			return View(p);
		}
		[HttpPost]
		public async Task<IActionResult> MyAccount(AppUserRegisterViewModel p)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			user.Adress = p.Adress;
			user.Name = p.Name;
			user.Surname = p.Surname;
			user.About = p.About;
			user.ImageUrl = p.ImageUrl;
			user.City = p.City;
			user.Adress = p.Adress;
			user.Email = p.Email;
			user.UserName = p.Username;
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("SingIn");
			}
			return View();	
		}
		public async Task<IActionResult> Singout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("SingIn");
		}
		[HttpGet]
		[AllowAnonymous]

		public IActionResult ForgetPassword()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]

		public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel p)
		{
			var user =await _userManager.FindByEmailAsync(p.Email);
			string passwordresedtoken = await _userManager.GeneratePasswordResetTokenAsync(user);

			//string passwordresedtoken = await _userManager.GeneratePasswordResetTokenAsync(user);
			var passwordresetlink =Url.Action("ResetPassword" , "Profile" , new
			{
				userid=user.Id,token =passwordresedtoken
			}, HttpContext.Request.Scheme);
			MimeMessage mimemessage = new MimeMessage();
			MailboxAddress mailboxfrom = new MailboxAddress("Luxury Watches Admin", "sehriyarhaciyev@gmail.com");
			MailboxAddress mailboxto = new MailboxAddress("User", p.Email);
			mimemessage.From.Add(mailboxfrom);
			mimemessage.To.Add(mailboxto);
			var bodybuilder = new BodyBuilder();
			bodybuilder.TextBody = passwordresetlink;
			mimemessage.Body = bodybuilder.ToMessageBody();
			mimemessage.Subject = "Şifrə Dəyişmə Tələbi";
			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Connect("smtp.gmail.com", 587, false);
			smtpClient.Authenticate("sehriyarhaciyev@gmail.com", "iqwwaimqqcuapdbd");
			smtpClient.Send(mimemessage);
			smtpClient.Disconnect(true);
		
			return View();
		}
		[AllowAnonymous]
		public IActionResult ResetPassword(string userid, string token)
		{
			TempData["userid"] = userid;
			TempData["token"] = token;
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
		{
			var userid = TempData["userid"];
			var token = TempData["token"];
			if (userid == null || token == null)
			{

			}
			var user = await _userManager.FindByIdAsync(userid.ToString());
			var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPassword.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("SingIn");
			}
			return View();
		}
	}
}
