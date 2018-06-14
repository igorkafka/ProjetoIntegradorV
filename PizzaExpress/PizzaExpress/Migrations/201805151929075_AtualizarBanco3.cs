namespace PizzaExpress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizarBanco3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedidoes", "ItensPedido_Id", "dbo.ItensPedidoes");
            DropForeignKey("dbo.Pizzas", "ItensPedido_Id", "dbo.ItensPedidoes");
            DropForeignKey("dbo.Produtoes", "ItensPedido_Id", "dbo.ItensPedidoes");
            DropForeignKey("dbo.ItensPedidoes", "Pedido_Id", "dbo.Pedidoes");
            DropIndex("dbo.Pedidoes", new[] { "ItensPedido_Id" });
            DropIndex("dbo.ItensPedidoes", new[] { "Pedido_Id" });
            DropIndex("dbo.Pizzas", new[] { "ItensPedido_Id" });
            DropIndex("dbo.Produtoes", new[] { "ItensPedido_Id" });
            CreateTable(
                "dbo.PizzaItensPedidoes",
                c => new
                    {
                        Pizza_Id = c.Int(nullable: false),
                        ItensPedido_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pizza_Id, t.ItensPedido_Id })
                .ForeignKey("dbo.Pizzas", t => t.Pizza_Id, cascadeDelete: true)
                .ForeignKey("dbo.ItensPedidoes", t => t.ItensPedido_Id, cascadeDelete: true)
                .Index(t => t.Pizza_Id)
                .Index(t => t.ItensPedido_Id);
            
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
            
            DropColumn("dbo.Pedidoes", "ItensPedido_Id");
            DropColumn("dbo.ItensPedidoes", "Pedido_Id");
            DropColumn("dbo.Pizzas", "ItensPedido_Id");
            DropColumn("dbo.Produtoes", "ItensPedido_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "ItensPedido_Id", c => c.Int());
            AddColumn("dbo.Pizzas", "ItensPedido_Id", c => c.Int());
            AddColumn("dbo.ItensPedidoes", "Pedido_Id", c => c.Int());
            AddColumn("dbo.Pedidoes", "ItensPedido_Id", c => c.Int());
            DropForeignKey("dbo.ProdutoItensPedidoes", "ItensPedido_Id", "dbo.ItensPedidoes");
            DropForeignKey("dbo.ProdutoItensPedidoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.PizzaItensPedidoes", "ItensPedido_Id", "dbo.ItensPedidoes");
            DropForeignKey("dbo.PizzaItensPedidoes", "Pizza_Id", "dbo.Pizzas");
            DropIndex("dbo.ProdutoItensPedidoes", new[] { "ItensPedido_Id" });
            DropIndex("dbo.ProdutoItensPedidoes", new[] { "Produto_Id" });
            DropIndex("dbo.PizzaItensPedidoes", new[] { "ItensPedido_Id" });
            DropIndex("dbo.PizzaItensPedidoes", new[] { "Pizza_Id" });
            DropTable("dbo.ProdutoItensPedidoes");
            DropTable("dbo.PizzaItensPedidoes");
            CreateIndex("dbo.Produtoes", "ItensPedido_Id");
            CreateIndex("dbo.Pizzas", "ItensPedido_Id");
            CreateIndex("dbo.ItensPedidoes", "Pedido_Id");
            CreateIndex("dbo.Pedidoes", "ItensPedido_Id");
            AddForeignKey("dbo.ItensPedidoes", "Pedido_Id", "dbo.Pedidoes", "Id");
            AddForeignKey("dbo.Produtoes", "ItensPedido_Id", "dbo.ItensPedidoes", "Id");
            AddForeignKey("dbo.Pizzas", "ItensPedido_Id", "dbo.ItensPedidoes", "Id");
            AddForeignKey("dbo.Pedidoes", "ItensPedido_Id", "dbo.ItensPedidoes", "Id");
        }
    }
}
