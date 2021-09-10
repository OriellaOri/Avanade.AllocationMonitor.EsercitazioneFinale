using Avanade.AllocationMonitor.Core.BusinessLayers;
using Avanade.AllocationMonitor.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Avanade.AllocationMonitor.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly AuthenticationBusinessLayer bl;

        public UserController()
        {
            bl = new AuthenticationBusinessLayer();
        }

        //GET
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userVM)
        {
            if (userVM == null)
                return View("ERROR");

            //recupero l'user attravero Username 
            var account = bl.GetUserByUserName(userVM.UserName);
            // controllo non sia nullo e che lo stato del model sia valido 
            if (account != null )
            {
                // confornto le password per vedere se uguale 
                if (account.Password.Equals(userVM.Password))
                {
                    // inizializzo la lista di Claim per associzare le identità 
                    var claim = new List<Claim>
                {
                    // TODO : cancellare ? new Claim(ClaimTypes.Role, account.IsAdministrator.ToString()),
                    new Claim(ClaimTypes.Role, account.IsEnabled.ToString()),
                };

                    // setto proprietà dell'autenticazione 
                    // dura un ore e gli ripassa le info del RedirectUri con i dati di accesso 
                    var properties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                        RedirectUri = userVM.ReturnUrl
                    };

                    // inzializo l'identità del claim 
                    var claimIdentity = new ClaimsIdentity
                        (claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                        );

                    //TODO : redirect login >> io voglio che va alla pagina di acesso
                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError(nameof(userVM.Password), "Invalid Password");
                    return View(userVM);
                }
            }
            return View(userVM);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
