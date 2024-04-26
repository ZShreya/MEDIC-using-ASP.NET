namespace Medic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCategories", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "Category_ID", "dbo.Categories");
            DropIndex("dbo.ProductCategories", new[] { "Product_ID" });
            DropIndex("dbo.ProductCategories", new[] { "Category_ID" });
            AddColumn("dbo.Products", "Category_ID", c => c.Int());
            CreateIndex("dbo.Products", "Category_ID");
            AddForeignKey("dbo.Products", "Category_ID", "dbo.Categories", "ID");
            DropTable("dbo.ProductCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ID, t.Category_ID });
            
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropColumn("dbo.Products", "Category_ID");
            CreateIndex("dbo.ProductCategories", "Category_ID");
            CreateIndex("dbo.ProductCategories", "Product_ID");
            AddForeignKey("dbo.ProductCategories", "Category_ID", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductCategories", "Product_ID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
