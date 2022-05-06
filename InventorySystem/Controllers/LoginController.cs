using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class LoginController : Controller
    {
        ItemsEntities db = new ItemsEntities();
        // GET: Login
        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Username, string Password)
        {
            if (ModelState.IsValid)
            {


                var password = (Password);
                var data = db.Logins.Where(s => s.Username.Equals(Username) & s.Password.Equals(Password)).FirstOrDefault();
                if (data != null )
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
    }
}