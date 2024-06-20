using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SonMama_Burger.Models;
using SonMama_Burger.Models.Entitites;
using SonMama_Burger.Validations;
using SonMama_Burger.VM;
using System.Diagnostics;

namespace SonMama_Burger.Controllers
{
	public class HomeController : Controller
	{
        private readonly ILogger<HomeController> _logger;
        //private readonly IMenuService menuService;

        public HomeController(ILogger<HomeController> logger /*, IMenuService menuService*/)
        {
            _logger = logger;
            //this.menuService = menuService;
        }

        public IActionResult Index()
        {
            //List<Menu> menuler = menuService.GetAll();
            return View(/*menuler*/);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactUsVM contactUsVM)
        {
            ContactUsVMValidator validator = new();
            var valid = validator.Validate(contactUsVM);
            if (valid.IsValid)
            {
                SendEmail(contactUsVM);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in valid.Errors)
                {
                    ModelState.AddModelError("ContactUsHata", item.ErrorMessage);
                }
                return View();
            }
        }

        public void SendEmail(ContactUsVM contactUsVM)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HamburgerProjesi Admin", "projemaka@gmail.com"); // Mailin kimden gideceði!
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", "burgermaka4@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"<ul>
	<li>
	<h3><span style=""font-family:Georgia,serif""><strong>Adý: &nbsp;</strong>{contactUsVM.Name}</span></h3>
	</li>
	<li>
	<h3><span style=""font-family:Georgia,serif""><strong>Email: </strong>{contactUsVM.Email}</span></h3>
	</li>
	<li>
	<h3><span style=""font-family:Georgia,serif""><strong>Konu: </strong>{contactUsVM.Subject}</span></h3>
	</li>
	<li>
	<h3><span style=""font-family:Georgia,serif""><strong>Mesaj: </strong>{contactUsVM.Message}</span></h3>
	</li>
</ul>";
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = contactUsVM.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("projemaka@gmail.com", "wvgdopwbgegdlgcl");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
