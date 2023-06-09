﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoProgra5.Models;
using ProyectoProgra5.Models.Login;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ProyectoProgra5.Controllers
{
    public class SecurityController : Controller
    {
        private readonly ProyectoProgra5Context _context;
        public SecurityController(ProyectoProgra5Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            User? usuario = _context.Users.Include(x => x.UserxRols)
                                          .ThenInclude(x => x.IdRolNavigation)
                                        .FirstOrDefault(x => x.Usuario == login.Usuario && x.Contraseña == login.Contraseña);
            try
            {
				string rolName = usuario.UserxRols.FirstOrDefault().IdRolNavigation.Nombre;

				if (usuario != null && rolName != null)
				{
					var claims = new List<Claim>()
							 {
								new Claim("IDUser", usuario.Id.ToString()),
								new Claim(ClaimTypes.Name, usuario.Nombre),
								new Claim(ClaimTypes.Role, rolName)
							 };

					var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var principal = new ClaimsPrincipal(identity);
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
						new AuthenticationProperties()
						{
							IsPersistent = login.Recordarme
						});
				}


				return RedirectToAction("Index", "Home");
			}
			catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }

        public async Task<IActionResult> Logout()
        {
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return LocalRedirect("/");
        }

        public IActionResult Unauthorized() => View();
    }
}
