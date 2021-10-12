using PayPal.Api;
using System.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using AngleSharp.Io;
//using AngleSharp.Io;

namespace OlwandleHotel.Models
{
    public class PayPalModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int Pay { get; set; }
        public string cmd { get; set; }
        public string business { get; set; }
        public string no_shipping { get; set; }
        public string @return { get; set; }
        public string cancel_return { get; set; }
        public string notify_url { get; set; }
        public string currency_code { get; set; }
        //public string item_name { get; set; }
        //public string item_quantity { get; set; }
        public float amount = Flight.Price;
        public string actionURL { get; set; }
        public virtual Flight Flight { get; set; }
        public PayPalModel(bool useSandbox)
        {
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);

            this.cmd = "_xclick";
            this.business = ConfigurationManager.AppSettings["business"];
            this.cancel_return = ConfigurationManager.AppSettings["cancel_return"];
            this.@return = ConfigurationManager.AppSettings["return"];
            if (useSandbox)
            {
                var payer = new Payer() { payment_method = "paypal" };
                


                var guid = Convert.ToString((new Random()).Next(100000));
                var redirUrls = new RedirectUrls()
                {
                    cancel_url = "http://localhost:3000/cancel",
                    return_url = "http://localhost:3000/process"

                };

                var itemList = new ItemList()
                {
                    items = new List<Item>()
                    {
                       new Item()
                       {
                         name = "Item Name",
                         currency = "USD",
                         price = "15",
                         quantity = "5",
                         sku = "sku"
                       }
                    }
                };
                var details = new Details()
                {
                    tax = "15",
                    shipping = "10",
                    subtotal = "75"
                };

                var amount = new Amount()
                {
                    currency = "USD",
                    total = "100.00", // Total must be equal to sum of shipping, tax and subtotal.
                    details = details
                };

                var transactionList = new List<Transaction>();

                transactionList.Add(new Transaction()
                {
                    description = "Transaction description.",
                    //invoice_number = Common.GetRandomInvoiceNumber(),
                    amount = amount,
                    item_list = itemList
                });

                var payment = new Payment()
                {
                    intent = "sale",
                    payer = payer,
                    redirect_urls = redirUrls,
                    transactions = transactionList
                };

                var createdPayment = payment.Create(apiContext);

                var links = createdPayment.links.GetEnumerator();
                while (links.MoveNext())
                {

                    var link = links.Current;
                    if (link.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        string url = "http://localhost:3000/process" + (100) + "&business=yathz14@gmail.com&item_name=Booking_amount&return=Page http://localhost:57531";
                        // Redirect the customer to link.href

                    }


                }

                

            }

            //this.actionURL = ConfigurationManager.AppSettings["test_url"];

            else
            {
                this.actionURL = ConfigurationManager.AppSettings["Prod_url"];
            }
            // We can add parameters here, for example OrderId, CustomerId, etc....  
            this.notify_url = ConfigurationManager.AppSettings["notify_url"];
            // We can add parameters here, for example OrderId, CustomerId, etc....  
            this.currency_code = ConfigurationManager.AppSettings["currency_code"];
        }

    }

}