using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OlwandleHotel.Models;
using PayPal.Api;

namespace OlwandleHotel.Controllers
{
    public class PayPalModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PayPalModels
        public ActionResult ValidateCommand(string product, float totalPrice, string quantity)
        {
            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
            var paypal = new PayPalModel(useSandbox);

            //paypal.item_name = product;
            paypal.amount = totalPrice;
            //paypal.item_quantity = quantity;
            return View(paypal);
        }

        public ActionResult RedirectFromPaypal()
        {
           
            return View();
        }

        public ActionResult CancelFromPaypal()
        {
            return View();
        }

        public ActionResult NotifyFromPaypal()
        {
            return View();
        }

    }
}
