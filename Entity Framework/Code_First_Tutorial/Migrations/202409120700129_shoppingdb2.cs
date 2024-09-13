namespace Code_First_Tutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingdb2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("shop.Samples", "SampleDiv");
        }
        
        public override void Down()
        {
            AddColumn("shop.Samples", "SampleDiv", c => c.String());
        }
    }
}
