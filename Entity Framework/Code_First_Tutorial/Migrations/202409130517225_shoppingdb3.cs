namespace Code_First_Tutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingdb3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("shop.Samples", "Roles", c => c.Int(nullable: false));

        }
        
        public override void Down()
        {
            DropColumn("shop.Samples", "Roles");
        }
    }
}
