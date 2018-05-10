namespace PizzaExpress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refatoracao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedidoes", "ObjCliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Pedidoes", "ObjPizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.ProdutoItensPedidoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.ProdutoItensPedidoes", "ItensPedido_id", "dbo.ItensPedidoes");
            DropForeignKey("dbo.Pedidoes", "ObjProduto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Pizzas", "Pedido_Id", "dbo.Pedidoes");
            DropForeignKey("dbo.Sabors", "ObjPizza_Id", "dbo.Pizzas");
            DropIndex("dbo.Pedidoes", new[] { "ObjCliente_Id" });
            DropIndex("dbo.Pedidoes", new[] { "ObjPizza_Id" });
            DropIndex("dbo.Pedidoes", new[] { "ObjProduto_Id" });
            DropIndex("dbo.Pizzas", new[] { "Pedido_Id" });
            DropIndex("dbo.ProdutoItensPedidoes", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutoItensPedidoes", new[] { "ItensPedido_id" });
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dia = c.DateTime(nullable: false),
                        ObjPedido_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.ObjPedido_Id)
                .Index(t => t.ObjPedido_Id);
            
            AddColumn("dbo.ItensPedidoes", "ObjProduto_Id", c => c.Int());
            AddColumn("dbo.Pedidoes", "ObjFuncionario_Id", c => c.Int());
            AddColumn("dbo.Pizzas", "Sabor_Id", c => c.Int());
            AddColumn("dbo.Sabors", "Pizza_Id", c => c.Int());
            AddColumn("dbo.Produtoes", "Produto_Id", c => c.Int());
            CreateIndex("dbo.Pedidoes", "ObjFuncionario_Id");
            CreateIndex("dbo.ItensPedidoes", "ObjProduto_Id");
            CreateIndex("dbo.Pizzas", "Sabor_Id");
            CreateIndex("dbo.Sabors", "Pizza_Id");
            CreateIndex("dbo.Produtoes", "Produto_Id");
            AddForeignKey("dbo.Pizzas", "Sabor_Id", "dbo.Sabors", "Id");
            AddForeignKey("dbo.Produtoes", "Produto_Id", "dbo.Produtoes", "Id");
            AddForeignKey("dbo.ItensPedidoes", "ObjProduto_Id", "dbo.Produtoes", "Id");
            AddForeignKey("dbo.Pedidoes", "ObjFuncionario_Id", "dbo.Funcionarios", "Id");
            AddForeignKey("dbo.Sabors", "Pizza_Id", "dbo.Pizzas", "Id");
            DropColumn("dbo.Pedidoes", "ValorTotal");
            DropColumn("dbo.Pedidoes", "ObjCliente_Id");
            DropColumn("dbo.Pedidoes", "ObjPizza_Id");
            DropColumn("dbo.Pedidoes", "ObjProduto_Id");
            DropColumn("dbo.Pizzas", "Pedido_Id");
            DropTable("dbo.ProdutoItensPedidoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProdutoItensPedidoes",
                c => new
                    {
                        Produto_Id = c.Int(nullable: false),
                        ItensPedido_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_Id, t.ItensPedido_id });
            
            AddColumn("dbo.Pizzas", "Pedido_Id", c => c.Int());
            AddColumn("dbo.Pedidoes", "ObjProduto_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "ObjPizza_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "ObjCliente_Id", c => c.Int());
            AddColumn("dbo.Pedidoes", "ValorTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Sabors", "Pizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.Vendas", "ObjPedido_Id", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "ObjFuncionario_Id", "dbo.Funcionarios");
            DropForeignKey("dbo.ItensPedidoes", "ObjProduto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Pizzas", "Sabor_Id", "dbo.Sabors");
            DropIndex("dbo.Vendas", new[] { "ObjPedido_Id" });
            DropIndex("dbo.Produtoes", new[] { "Produto_Id" });
            DropIndex("dbo.Sabors", new[] { "Pizza_Id" });
            DropIndex("dbo.Pizzas", new[] { "Sabor_Id" });
            DropIndex("dbo.ItensPedidoes", new[] { "ObjProduto_Id" });
            DropIndex("dbo.Pedidoes", new[] { "ObjFuncionario_Id" });
            DropColumn("dbo.Produtoes", "Produto_Id");
            DropColumn("dbo.Sabors", "Pizza_Id");
            DropColumn("dbo.Pizzas", "Sabor_Id");
            DropColumn("dbo.Pedidoes", "ObjFuncionario_Id");
            DropColumn("dbo.ItensPedidoes", "ObjProduto_Id");
            DropTable("dbo.Vendas");
            CreateIndex("dbo.ProdutoItensPedidoes", "ItensPedido_id");
            CreateIndex("dbo.ProdutoItensPedidoes", "Produto_Id");
            CreateIndex("dbo.Pizzas", "Pedido_Id");
            CreateIndex("dbo.Pedidoes", "ObjProduto_Id");
            CreateIndex("dbo.Pedidoes", "ObjPizza_Id");
            CreateIndex("dbo.Pedidoes", "ObjCliente_Id");
            AddForeignKey("dbo.Sabors", "ObjPizza_Id", "dbo.Pizzas", "Id");
            AddForeignKey("dbo.Pizzas", "Pedido_Id", "dbo.Pedidoes", "Id");
            AddForeignKey("dbo.Pedidoes", "ObjProduto_Id", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutoItensPedidoes", "ItensPedido_id", "dbo.ItensPedidoes", "id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutoItensPedidoes", "Produto_Id", "dbo.Produtoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pedidoes", "ObjPizza_Id", "dbo.Pizzas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pedidoes", "ObjCliente_Id", "dbo.Clientes", "Id");
        }
    }
}
