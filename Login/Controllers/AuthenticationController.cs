using Login.DAL;
using Login.Models;
using Login.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UsuarioDAL dal = new UsuarioDAL();
                Usuario usuario = dal.GetUsuarioLogin(model.UserName, model.Password);

                // Validar usuario
                if (usuario != null)
                {
                    HttpContext.Session.SetString("Username", usuario.UserName);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
                }
            }
            return View(model);
        }
    }
}
