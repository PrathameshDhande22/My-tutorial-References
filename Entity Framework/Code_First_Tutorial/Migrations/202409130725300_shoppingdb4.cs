namespace Code_First_Tutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class shoppingdb4 : DbMigration
    {
        public override void Up()
        {
            // creating the stored procedure
            var storedProcedure = @"create proc sp_GetProducts
                                    as
                                    begin
                                        select * from shop.ShopProducts
                                    end";
            Sql(storedProcedure);
        }

        public override void Down()
        {
            // drop the stored procedure
            Sql("drop procedure sp_GetProducts");
        }
    }
}
