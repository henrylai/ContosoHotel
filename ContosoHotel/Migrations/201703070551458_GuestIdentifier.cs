namespace ContosoHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuestIdentifier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guest", "Identifier", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guest", "Identifier");
        }
    }
}
