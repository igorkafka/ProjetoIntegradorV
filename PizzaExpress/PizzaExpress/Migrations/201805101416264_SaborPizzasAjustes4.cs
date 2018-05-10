namespace PizzaExpress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaborPizzasAjustes4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sabors", "ObjPizza_Id", "dbo.Pizzas");
            DropIndex("dbo.Sabors", new[] { "ObjPizza_Id" });
            DropColumn("dbo.Sabors", "ObjPizza_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sabors", "ObjPizza_Id", c => c.Int());
            CreateIndex("dbo.Sabors", "ObjPizza_Id");
            AddForeignKey("dbo.Sabors", "ObjPizza_Id", "dbo.Pizzas", "Id");
        }
    }
}
