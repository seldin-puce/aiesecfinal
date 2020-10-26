using System.Diagnostics;
using System.Threading.Tasks;
using Aiesec.ExternalServices.Mail;
using Aiesec.ExternalServices.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aiesec.Web.Models;
using Aiesec.Web.Options;
using Aiesec.Web.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Aiesec.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;
        private readonly EmailServerNoReplyOptions ServerNoReplyOptions;
        private readonly ILogger<HomeController> _logger;
        private readonly ValidationChecker _validationChecker;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(IMailService mailService,
            EmailServerNoReplyOptions ServerNoReplyOptions,
            ILogger<HomeController>
            logger, ValidationChecker validationChecker,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this._mailService = mailService;
            this.ServerNoReplyOptions = ServerNoReplyOptions;
            _logger = logger;
            _validationChecker = validationChecker;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<StatusCodeResult> SendEmail()
        {
            await _mailService.SendMailAsync(new MailMessage
            {
                Body = "Ovo je tijelo mejla",
                Subject = "Neki naslov",
                To = "puceseldin@gmail.com",
                MailServer = new MailServer(ServerNoReplyOptions)
            });
            return StatusCode(200);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Authenticate()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [Aiesec.Service.Attributes.AutoValidateModelState]
        public async Task<IActionResult> AuthenticateAsync(string username, string password)
        {
            if (username == null || password == null)
            {
                return View();
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        public async Task<IActionResult> RegisterAdminAsync()
        {
            var admin = new IdentityUser
            {
                UserName = "Admin",
                Email = "",
            };
            var result = await _userManager.CreateAsync(admin, "Admin123!");

            if (result.Succeeded)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(admin, "Admin", false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Authenticate));
        }
    }
}