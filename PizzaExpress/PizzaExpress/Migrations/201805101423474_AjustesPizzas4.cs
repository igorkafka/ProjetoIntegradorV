namespace PizzaExpress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustesPizzas4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pizzas", "Sabor_Id", "dbo.Sabors");
            DropIndex("dbo.Pizzas", new[] { "Sabor_Id" });
            DropColumn("dbo.Pizzas", "Sabor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pizzas", "Sabor_Id", c => c.Int());
            CreateIndex("dbo.Pizzas", "Sabor_Id");
            AddForeignKey("dbo.Pizzas", "Sabor_Id", "dbo.Sabors", "Id");
        }
    }
}
