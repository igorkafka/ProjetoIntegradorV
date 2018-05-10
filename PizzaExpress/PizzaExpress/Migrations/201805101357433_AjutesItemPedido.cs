namespace PizzaExpress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjutesItemPedido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "ObjSabor_Id", "dbo.Sabors");
            DropIndex("dbo.Pedidoes", new[] { "ObjSabor_Id" });
            DropIndex("dbo.Produtoes", new[] { "Produto_Id" });
            DropColumn("dbo.Pedidoes", "ObjSabor_Id");
            DropColumn("dbo.ItensPedidoes", "IdItem");
            DropColumn("dbo.Produtoes", "Produto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "Produto_Id", c => c.Int());
            AddColumn("dbo.ItensPedidoes", "IdItem", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "ObjSabor_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "Produto_Id");
            CreateIndex("dbo.Pedidoes", "ObjSabor_Id");
            AddForeignKey("dbo.Pedidoes", "ObjSabor_Id", "dbo.Sabors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Produtoes", "Produto_Id", "dbo.Produtoes", "Id");
        }
    }
}
