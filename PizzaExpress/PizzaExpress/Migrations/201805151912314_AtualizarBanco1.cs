namespace PizzaExpress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizarBanco1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItensPedidoes", "ObjPizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.ItensPedidoes", "ObjProduto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.ItensPedidoes", "ObjPedido_Id", "dbo.Pedidoes");
            DropIndex("dbo.ItensPedidoes", new[] { "ObjPizza_Id" });
            DropIndex("dbo.ItensPedidoes", new[] { "ObjProduto_Id" });
            CreateTable(
                "dbo.ProdutoItensPedidoes",
                c => new
                    {
                        Produto_Id = c.Int(nullable: false),
                        ItensPedido_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_Id, t.ItensPedido_Id })
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id, cascadeDelete: true)
                .ForeignKey("dbo.ItensPedidoes", t => t.ItensPedido_Id, cascadeDelete: true)
                .Index(t => t.Produto_Id)
                .Index(t => t.ItensPedido_Id);
            
            AddColumn("dbo.Pedidoes", "ItensPedido_Id", c => c.Int());
            AddColumn("dbo.ItensPedidoes", "Pedido_Id", c => c.Int());
            AddColumn("dbo.Pizzas", "Nome", c => c.String());
            AddColumn("dbo.Pizzas", "ItensPedido_Id", c => c.Int());
            CreateIndex("dbo.Pedidoes", "ItensPedido_Id");
            CreateIndex("dbo.ItensPedidoes", "Pedido_Id");
            CreateIndex("dbo.Pizzas", "ItensPedido_Id");
            AddForeignKey("dbo.Pedidoes", "ItensPedido_Id", "dbo.ItensPedidoes", "Id");
            AddForeignKey("dbo.Pizzas", "ItensPedido_Id", "dbo.ItensPedidoes", "Id");
            AddForeignKey("dbo.ItensPedidoes", "Pedido_Id", "dbo.Pedidoes", "Id");
            DropColumn("dbo.ItensPedidoes", "ObjPizza_Id");
            DropColumn("dbo.ItensPedidoes", "ObjProduto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItensPedidoes", "ObjProduto_Id", c => c.Int());
            AddColumn("dbo.ItensPedidoes", "ObjPizza_Id", c => c.Int());
            DropForeignKey("dbo.ItensPedidoes", "Pedido_Id", "dbo.Pedidoes");
            DropForeignKey("dbo.ProdutoItensPedidoes", "ItensPedido_Id", "dbo.ItensPedidoes");
            DropForeignKey("dbo.ProdutoItensPedidoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Pizzas", "ItensPedido_Id", "dbo.ItensPedidoes");
            DropForeignKey("dbo.Pedidoes", "ItensPedido_Id", "dbo.ItensPedidoes");
            DropIndex("dbo.ProdutoItensPedidoes", new[] { "ItensPedido_Id" });
            DropIndex("dbo.ProdutoItensPedidoes", new[] { "Produto_Id" });
            DropIndex("dbo.Pizzas", new[] { "ItensPedido_Id" });
            DropIndex("dbo.ItensPedidoes", new[] { "Pedido_Id" });
            DropIndex("dbo.Pedidoes", new[] { "ItensPedido_Id" });
            DropColumn("dbo.Pizzas", "ItensPedido_Id");
            DropColumn("dbo.Pizzas", "Nome");
            DropColumn("dbo.ItensPedidoes", "Pedido_Id");
            DropColumn("dbo.Pedidoes", "ItensPedido_Id");
            DropTable("dbo.ProdutoItensPedidoes");
            CreateIndex("dbo.ItensPedidoes", "ObjProduto_Id");
            CreateIndex("dbo.ItensPedidoes", "ObjPizza_Id");
            AddForeignKey("dbo.ItensPedidoes", "ObjPedido_Id", "dbo.Pedidoes", "Id");
            AddForeignKey("dbo.ItensPedidoes", "ObjProduto_Id", "dbo.Produtoes", "Id");
            AddForeignKey("dbo.ItensPedidoes", "ObjPizza_Id", "dbo.Pizzas", "Id");
        }
    }
}
