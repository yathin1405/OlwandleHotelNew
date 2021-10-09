using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlwandleHotel.Models
{
    public class Payments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Payment Type")]
        public string payTypes { get; set; }

        [DisplayName("Paid Deposit")]
        public double deposit { get; set; }

        [DisplayName("Total Cost")]
        public double totalCost { get; set; }

        [DisplayName("Total Paid?")]
        public bool paidTotCost { get; set; }

        [DisplayName("Date Paid")]
        public Nullable<DateTime> date_PaidTotCost { get; set; }


        public int BookingID { get; set; }
        public Reservation reserve { get; set; }

        //public int pickupId { get; set; }
        //public PickMeUp pickmeup { get; set; }
    }
}