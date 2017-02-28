namespace ContosoHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Number");
        }
    }
}
