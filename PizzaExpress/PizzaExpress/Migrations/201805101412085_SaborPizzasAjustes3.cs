namespace PizzaExpress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaborPizzasAjustes3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sabors", "Pizza_Id", "dbo.Pizzas");
            DropIndex("dbo.Sabors", new[] { "Pizza_Id" });
            AddColumn("dbo.Pizzas", "Sabor1_Id", c => c.Int());
            AddColumn("dbo.Pizzas", "Sabor2_Id", c => c.Int());
            AddColumn("dbo.Pizzas", "Sabor3_Id", c => c.Int());
            CreateIndex("dbo.Pizzas", "Sabor1_Id");
            CreateIndex("dbo.Pizzas", "Sabor2_Id");
            CreateIndex("dbo.Pizzas", "Sabor3_Id");
            AddForeignKey("dbo.Pizzas", "Sabor1_Id", "dbo.Sabors", "Id");
            AddForeignKey("dbo.Pizzas", "Sabor2_Id", "dbo.Sabors", "Id");
            AddForeignKey("dbo.Pizzas", "Sabor3_Id", "dbo.Sabors", "Id");
            DropColumn("dbo.Pedidoes", "Usuario");
            DropColumn("dbo.Sabors", "Pizza_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sabors", "Pizza_Id", c => c.Int());
            AddColumn("dbo.Pedidoes", "Usuario", c => c.String());
            DropForeignKey("dbo.Pizzas", "Sabor3_Id", "dbo.Sabors");
            DropForeignKey("dbo.Pizzas", "Sabor2_Id", "dbo.Sabors");
            DropForeignKey("dbo.Pizzas", "Sabor1_Id", "dbo.Sabors");
            DropIndex("dbo.Pizzas", new[] { "Sabor3_Id" });
            DropIndex("dbo.Pizzas", new[] { "Sabor2_Id" });
            DropIndex("dbo.Pizzas", new[] { "Sabor1_Id" });
            DropColumn("dbo.Pizzas", "Sabor3_Id");
            DropColumn("dbo.Pizzas", "Sabor2_Id");
            DropColumn("dbo.Pizzas", "Sabor1_Id");
            CreateIndex("dbo.Sabors", "Pizza_Id");
            AddForeignKey("dbo.Sabors", "Pizza_Id", "dbo.Pizzas", "Id");
        }
    }
}
