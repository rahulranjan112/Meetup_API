namespace Meetup_API.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Age = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false, precision: 0),
                        Profession = c.Boolean(nullable: false),
                        Locality = c.String(unicode: false),
                        NumGuests = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Participants");
        }
    }
}
