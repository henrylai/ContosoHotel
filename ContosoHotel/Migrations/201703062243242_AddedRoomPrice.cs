namespace ContosoHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoomPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Room", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Room", "Price");
        }
    }
}
