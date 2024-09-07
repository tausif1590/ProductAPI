using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace ProdAPI.DB.CodeFirstMigration.Context
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public long Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UtcUpdatedOn { get; set; }
    }

    public class ProdDBContext : DbContext
    {
        public ProdDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product {Id=100000, Name = "PC Cabinet", Description = "PC Cabinet", Quantity = 10, IsActive = true},
                new Product {Id=100001, Name = "Graphic Card", Description = "Graphic Card", Quantity = 18, IsActive = true },
                new Product {Id=100002, Name = "SSD", Description = "SSD", Quantity = 20, IsActive = true},
                new Product {Id=100003, Name = "RAM", Description = "RAM", Quantity = 40, IsActive = true },
                new Product {Id=100004, Name = "Ext. SSD", Description = "External SSD", Quantity = 29, IsActive = true },
                new Product {Id=100005, Name = "Mother Board", Description = "Mother Board", Quantity = 16, IsActive = true }
            );
        }
    }
}


namespace ProdAPI.DB.CodeFirstMigration.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "100000, 1"),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: false, defaultValue: 0),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    UtcUpdatedOn = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}