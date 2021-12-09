using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace M2BusBooking.Controllers
{
    [Route("/login")]
    public class LoginController : Controller
    {
        List<User> users = new List<User>();
        public LoginController()
        {
            users.Add(new User("nishant", "pass123", "Admin"));
            users.Add(new User("user001", "12345", "Member"));
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(
            string username,
            string password)
        {

            User loggedInUser = null;
            foreach (var user in users)
            {
                if (user.UserName == username && password == user.Password)
                {
                    loggedInUser = user;
                    break;
                }
            }
            if (loggedInUser != null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name,loggedInUser.UserName),
                    new Claim(ClaimTypes.Role,loggedInUser.Role),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                Response.Redirect("/");

            }
            else
            {
                ViewBag.Error = "Login Failed";
            }
            return View();
        }
    }
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public User(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }
    }
}
