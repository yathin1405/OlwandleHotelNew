namespace OlwandleHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitiaCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddEvents",
                c => new
                    {
                        EventId = c.String(nullable: false, maxLength: 128),
                        EventType = c.String(nullable: false),
                        MaxNumAttNum = c.Int(nullable: false),
                        DEventP = c.Double(nullable: false),
                        NEventP = c.Double(nullable: false),
                        NightLessD = c.Double(nullable: false),
                        DayGreaterD = c.Double(nullable: false),
                        DayLessD = c.Double(nullable: false),
                        NightGreaterD = c.Double(nullable: false),
                        MDQA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.AddPrices",
                c => new
                    {
                        priceID = c.Int(nullable: false, identity: true),
                        BPrice = c.Double(nullable: false),
                        LPrice = c.Double(nullable: false),
                        DPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.priceID);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        billID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        checkInDate = c.DateTime(nullable: false),
                        checkOutDate = c.DateTime(nullable: false),
                        DayNo = c.Int(nullable: false),
                        RoomNo = c.String(nullable: false, maxLength: 128),
                        BasicCharge = c.Double(nullable: false),
                        BookingId = c.Int(nullable: false),
                        Discount = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        BreakFast = c.Boolean(nullable: false),
                        Lunch = c.Boolean(nullable: false),
                        Supper = c.Boolean(nullable: false),
                        BPrice = c.Double(nullable: false),
                        LPrice = c.Double(nullable: false),
                        DPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.billID)
                .ForeignKey("dbo.Reservations", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomNo, cascadeDelete: true)
                .Index(t => t.RoomNo)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        checkInDate = c.DateTime(nullable: false),
                        checkOutDate = c.DateTime(nullable: false),
                        numGuests = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                        RoomNo = c.String(maxLength: 128),
                        DateBooked = c.DateTime(nullable: false),
                        checkedIn = c.Boolean(nullable: false),
                        checkedOut = c.Boolean(nullable: false),
                        date_CheckedOut = c.DateTime(),
                        DayNo = c.Int(nullable: false),
                        bookings = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        status = c.String(),
                        Paymentstatus = c.String(),
                        AdvancedPayment = c.Double(nullable: false),
                        BookingStatus = c.String(),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomNo)
                .Index(t => t.Id)
                .Index(t => t.RoomNo);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        Gender = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserType = c.String(),
                        CssTheme = c.String(),
                        numBookings = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        payTypes = c.String(),
                        deposit = c.Double(nullable: false),
                        totalCost = c.Double(nullable: false),
                        paidTotCost = c.Boolean(nullable: false),
                        date_PaidTotCost = c.DateTime(),
                        BookingID = c.Int(nullable: false),
                        Shuttle_PickupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.BookingID, cascadeDelete: true)
                .ForeignKey("dbo.Shuttles", t => t.Shuttle_PickupId)
                .Index(t => t.BookingID)
                .Index(t => t.Shuttle_PickupId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomNo = c.String(nullable: false, maxLength: 128),
                        RoomTypeId = c.Int(nullable: false),
                        FloorNum = c.Int(nullable: false),
                        Picture = c.Binary(),
                        Id = c.String(maxLength: 128),
                        RoomStatus = c.String(),
                        NoBooked = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        NumOfRooms = c.Int(nullable: false),
                        numguests = c.Int(nullable: false),
                        Numbeds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomNo)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.RoomTypeId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        RoomTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Qty = c.Int(nullable: false),
                        NumOfRooms = c.Int(nullable: false),
                        BasicCharge = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.BookEvents",
                c => new
                    {
                        bookID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        GName = c.String(nullable: false),
                        NumAtt = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        Dduration = c.Int(nullable: false),
                        Nduration = c.Int(nullable: false),
                        EventId = c.String(nullable: false, maxLength: 128),
                        CheckoutDate = c.DateTime(nullable: false),
                        DayDiscount = c.Double(nullable: false),
                        DayBasicCost = c.Double(nullable: false),
                        NightDiscount = c.Double(nullable: false),
                        NightBasicCost = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.bookID)
                .ForeignKey("dbo.AddEvents", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.EventId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Cancellations",
                c => new
                    {
                        CancelID = c.Int(nullable: false, identity: true),
                        checkInDate = c.DateTime(nullable: false),
                        checkOutDate = c.DateTime(nullable: false),
                        numGuests = c.Int(nullable: false),
                        Email = c.String(),
                        RoomNo = c.String(),
                        DateBooked = c.DateTime(nullable: false),
                        checkedIn = c.Boolean(nullable: false),
                        checkedOut = c.Boolean(nullable: false),
                        date_CheckedOut = c.DateTime(),
                        DayNo = c.Int(nullable: false),
                        bookings = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.CancelID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 35),
                        MName = c.String(maxLength: 35),
                        LName = c.String(nullable: false, maxLength: 35),
                        Title = c.String(nullable: false),
                        IdentityNumber = c.String(nullable: false, maxLength: 13),
                        Gender = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        desc = c.Int(nullable: false, identity: true),
                        ReturnUrl = c.String(),
                    })
                .PrimaryKey(t => t.desc);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        ThemeColor = c.String(nullable: false),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer = c.Int(),
                        Comment = c.String(maxLength: 500),
                        FullName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuestDetails",
                c => new
                    {
                        g = c.Int(nullable: false, identity: true),
                        checkInDate = c.DateTime(nullable: false),
                        checkOutDate = c.DateTime(nullable: false),
                        DayNo = c.Int(nullable: false),
                        numGuests = c.Int(nullable: false),
                        RoomNo = c.String(nullable: false),
                        FloorNum = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        BasicCharge = c.Double(nullable: false),
                        BookingID = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.g)
                .ForeignKey("dbo.Reservations", t => t.BookingID, cascadeDelete: true)
                .Index(t => t.BookingID);
            
            CreateTable(
                "dbo.PersonalDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Tel = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RegisterAllViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountType = c.String(nullable: false),
                        FName = c.String(nullable: false, maxLength: 35),
                        MName = c.String(maxLength: 35),
                        LName = c.String(nullable: false, maxLength: 35),
                        IdentityNumber = c.String(nullable: false, maxLength: 13),
                        Gender = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RoomServices",
                c => new
                    {
                        servicesID = c.Int(nullable: false, identity: true),
                        BreakFast = c.Boolean(nullable: false),
                        Launch = c.Boolean(nullable: false),
                        Dinner = c.Boolean(nullable: false),
                        priceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.servicesID)
                .ForeignKey("dbo.AddPrices", t => t.priceID, cascadeDelete: true)
                .Index(t => t.priceID);
            
            CreateTable(
                "dbo.Shuttles",
                c => new
                    {
                        PickupId = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        source = c.String(nullable: false),
                        finacharge = c.Double(nullable: false),
                        pickedup = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PickupId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 35),
                        MName = c.String(maxLength: 35),
                        LName = c.String(nullable: false, maxLength: 35),
                        Title = c.String(nullable: false),
                        IdentityNumber = c.String(nullable: false, maxLength: 13),
                        Gender = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.ViewModels",
                c => new
                    {
                        view = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(maxLength: 35),
                        LastName = c.String(maxLength: 35),
                        checkInDate = c.DateTime(nullable: false),
                        checkOutDate = c.DateTime(nullable: false),
                        numGuests = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.view);
            
            CreateTable(
                "dbo.VMs",
                c => new
                    {
                        VMK = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Tel = c.String(),
                        CheckinDate = c.DateTime(nullable: false),
                        CheckoutDate = c.DateTime(nullable: false),
                        NumGuests = c.Int(nullable: false),
                        NumDays = c.Int(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        RoomNo = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.VMK);
            
            CreateTable(
                "dbo.WalkinReserves",
                c => new
                    {
                        ResId = c.Int(nullable: false, identity: true),
                        CheckinDate = c.DateTime(nullable: false),
                        CheckoutDate = c.DateTime(nullable: false),
                        NumGuests = c.Int(nullable: false),
                        NumDays = c.Int(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        RoomNo = c.String(maxLength: 128),
                        RoomTypeId = c.Int(nullable: false),
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResId)
                .ForeignKey("dbo.PersonalDatas", t => t.ID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomNo)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.RoomNo)
                .Index(t => t.RoomTypeId)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WalkinReserves", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.WalkinReserves", "RoomNo", "dbo.Rooms");
            DropForeignKey("dbo.WalkinReserves", "ID", "dbo.PersonalDatas");
            DropForeignKey("dbo.Payments", "Shuttle_PickupId", "dbo.Shuttles");
            DropForeignKey("dbo.Shuttles", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RoomServices", "priceID", "dbo.AddPrices");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.GuestDetails", "BookingID", "dbo.Reservations");
            DropForeignKey("dbo.BookEvents", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookEvents", "EventId", "dbo.AddEvents");
            DropForeignKey("dbo.Bills", "RoomNo", "dbo.Rooms");
            DropForeignKey("dbo.Bills", "BookingId", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "RoomNo", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payments", "BookingID", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WalkinReserves", new[] { "ID" });
            DropIndex("dbo.WalkinReserves", new[] { "RoomTypeId" });
            DropIndex("dbo.WalkinReserves", new[] { "RoomNo" });
            DropIndex("dbo.Shuttles", new[] { "Id" });
            DropIndex("dbo.RoomServices", new[] { "priceID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.GuestDetails", new[] { "BookingID" });
            DropIndex("dbo.BookEvents", new[] { "Id" });
            DropIndex("dbo.BookEvents", new[] { "EventId" });
            DropIndex("dbo.Rooms", new[] { "Id" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.Payments", new[] { "Shuttle_PickupId" });
            DropIndex("dbo.Payments", new[] { "BookingID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Reservations", new[] { "RoomNo" });
            DropIndex("dbo.Reservations", new[] { "Id" });
            DropIndex("dbo.Bills", new[] { "BookingId" });
            DropIndex("dbo.Bills", new[] { "RoomNo" });
            DropTable("dbo.WalkinReserves");
            DropTable("dbo.VMs");
            DropTable("dbo.ViewModels");
            DropTable("dbo.Staffs");
            DropTable("dbo.Shuttles");
            DropTable("dbo.RoomServices");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RegisterAllViewModels");
            DropTable("dbo.PersonalDatas");
            DropTable("dbo.GuestDetails");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Events");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Customers");
            DropTable("dbo.Cancellations");
            DropTable("dbo.BookEvents");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Payments");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Reservations");
            DropTable("dbo.Bills");
            DropTable("dbo.AddPrices");
            DropTable("dbo.AddEvents");
        }
    }
}
