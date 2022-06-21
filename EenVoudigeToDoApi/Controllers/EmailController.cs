using EenVoudigeToDoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace EenVoudigeToDoApi.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        [HttpPost]
        public IActionResult SendEmail(string useremail)
        {
            string subject = "Automatische mail vervaldatum.";
            string body = "Uw todo is vervallen. Gelieve contact op te nemen met de systeembeheerder.";

            WebMail.Send(useremail, subject, body, null, null, null, true, null, null, null, null, null, null);
            ViewBag.msg = "email is succesvol verzonden!";
            return View();
        }
    }
}
