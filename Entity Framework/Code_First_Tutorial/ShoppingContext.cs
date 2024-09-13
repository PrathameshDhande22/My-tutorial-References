using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Tutorial
{
    public class ShoppingContext : DbContext
    {
        // passing the database you can also pass the connectionstring over it.
        public ShoppingContext() : base("name=shoppingDatabase")
        {

            // setting the initializer
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ShoppingContext>());

            // setting the initializer for the migrations
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShoppingContext, Code_First_Tutorial.Migrations.Configuration>());
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<ShopProducts> ShopProducts { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Sample> Samples { get; set; }


        // adding the stored Procedure
        public IList<ShopProducts> sp_GetProducts()
        {
            return this.Database.SqlQuery<ShopProducts>("exec sp_GetProducts").ToList();
        }

        // For implementing the Fluent API Override the OnModelCreating Method
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("shop"); // Assigns the Schema to all the Tables present in the Specified Context.

            // Map entity to table
            modelBuilder.Entity<Store>().ToTable("Shoppes", "dbo");  // assigns the table name or schema name.
            modelBuilder.Entity<Store>().HasKey(st => st.StoreId).HasIndex(st => st.ZipCode); // Assigned the primary key and index

            // Ignoring some properties
            modelBuilder.Entity<Store>().Ignore(st => st.StoreOwner); // ignores the storeOwner properties

            // configuring the composite key
            modelBuilder.Entity<Store>().HasKey(st => new { st.StoreId, st.StoreName });

            // Property based configurations
            // getting the current property and assigning the Max length adn setting the column as not null and column order to 2
            modelBuilder.Entity<Store>().Property(st => st.StoreName).HasMaxLength(30).IsRequired().HasColumnOrder(2);

            // Changing the column datatype
            modelBuilder.Entity<Store>().Property(st => st.GSTIN).IsOptional(); //  making it null column
        }
    }
}
