namespace OlwandleHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class demo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cruises",
                c => new
                    {
                        CruiseID = c.Int(nullable: false, identity: true),
                        ShipName = c.Int(nullable: false),
                        Email = c.String(),
                        FROM = c.Int(nullable: false),
                        TO = c.Int(nullable: false),
                        Ship_Name = c.String(),
                        Cruise_Duration = c.String(),
                        Num_Guests = c.String(),
                        Departure_Date = c.DateTime(nullable: false),
                        DepartureTime = c.String(),
                    })
                .PrimaryKey(t => t.CruiseID);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightID = c.Int(nullable: false, identity: true),
                        Airways = c.Int(nullable: false),
                        FROM = c.Int(nullable: false),
                        TO = c.Int(nullable: false),
                        SeatType = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Departure_Date = c.DateTime(nullable: false),
                        DepartureTime = c.String(),
                        Return_Flight = c.Boolean(nullable: false),
                        Return_Date = c.DateTime(nullable: false),
                        Return_Time = c.String(),
                        NumAdults = c.Int(nullable: false),
                        NumAChild = c.Int(nullable: false),
                        Seat_Type_Calc = c.Double(nullable: false),
                        Airline_Fee = c.Double(nullable: false),
                        ReturnTicket_Price = c.Double(nullable: false),
                        passenger_Cost = c.Double(nullable: false),
                        Num_Pass = c.Int(nullable: false),
                        Add_Flight_Delay = c.String(),
                        Available_Seats = c.String(),
                        SEAT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightID);
            
            CreateTable(
                "dbo.PayPalModels",
                c => new
                    {
                        Pay = c.Int(nullable: false, identity: true),
                        cmd = c.String(),
                        business = c.String(),
                        no_shipping = c.String(),
                        _return = c.String(name: "return"),
                        cancel_return = c.String(),
                        notify_url = c.String(),
                        currency_code = c.String(),
                        actionURL = c.String(),
                        Flight_FlightID = c.Int(),
                    })
                .PrimaryKey(t => t.Pay)
                .ForeignKey("dbo.Flights", t => t.Flight_FlightID)
                .Index(t => t.Flight_FlightID);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        NumAdults = c.Int(nullable: false),
                        NumKids = c.Int(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        TourL = c.Int(nullable: false),
                        CruiseL = c.Int(nullable: false),
                        FlightL = c.Int(nullable: false),
                        HotelL = c.Int(nullable: false),
                        estimatedPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        TourId = c.Int(nullable: false, identity: true),
                        Tour_Type = c.Int(nullable: false),
                        Tour_Name = c.String(),
                        Tour_Duration = c.String(),
                        Email = c.String(),
                        Tour_Date = c.DateTime(nullable: false),
                        Tour_Time = c.String(),
                    })
                .PrimaryKey(t => t.TourId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PayPalModels", "Flight_FlightID", "dbo.Flights");
            DropIndex("dbo.PayPalModels", new[] { "Flight_FlightID" });
            DropTable("dbo.Tours");
            DropTable("dbo.Quotes");
            DropTable("dbo.PayPalModels");
            DropTable("dbo.Flights");
            DropTable("dbo.Cruises");
        }
    }
}
