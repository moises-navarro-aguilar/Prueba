using CosumoPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CosumoPrueba.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult Autherize(string correo, string contraseña)
        {
            if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(contraseña))
            {
                Entities db = new Entities();
                var datos = db.Usuarios.FirstOrDefault(e => e.Correo == correo && e.Contraseña == contraseña);
                if (datos != null)
                {
                    FormsAuthentication.SetAuthCookie(datos.Correo, true);
                    return RedirectToAction("Index", "Usuario_Rol");
                }
                else
                {
                    return RedirectToAction("Index", new { message = "Datos no validos" });
                }
            }
            else
            {
                return RedirectToAction("Index", new { message = "Completa los campos" });
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Index();
        }
    }
}