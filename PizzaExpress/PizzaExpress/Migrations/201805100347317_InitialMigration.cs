namespace PizzaExpress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TelefoneCliente = c.String(nullable: false, maxLength: 18),
                        Rua = c.String(nullable: false, maxLength: 30),
                        Bairro = c.String(nullable: false, maxLength: 30),
                        Numero = c.String(nullable: false, maxLength: 8),
                        Nome = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Senha = c.String(),
                        Permissao = c.Int(nullable: false),
                        Setor = c.String(),
                        Nome = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItensPedidoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        IdItem = c.Int(nullable: false),
                        Quatidade = c.Int(nullable: false),
                        ObjPedido_Id = c.Int(),
                        ObjPizza_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Pedidoes", t => t.ObjPedido_Id)
                .ForeignKey("dbo.Pizzas", t => t.ObjPizza_Id)
                .Index(t => t.ObjPedido_Id)
                .Index(t => t.ObjPizza_Id);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        NumPedido = c.Int(nullable: false),
                        DescPedido = c.String(nullable: false, maxLength: 50),
                        DataPedido = c.DateTime(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatusPedido = c.String(),
                        TipoPedido = c.String(nullable: false),
                        ObjCliente_Id = c.Int(),
                        ObjPizza_Id = c.Int(nullable: false),
                        ObjProduto_Id = c.Int(nullable: false),
                        ObjSabor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ObjCliente_Id)
                .ForeignKey("dbo.Pizzas", t => t.ObjPizza_Id, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ObjProduto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sabors", t => t.ObjSabor_Id, cascadeDelete: true)
                .Index(t => t.ObjCliente_Id)
                .Index(t => t.ObjPizza_Id)
                .Index(t => t.ObjProduto_Id)
                .Index(t => t.ObjSabor_Id);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        PrecoPizza = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tamanho = c.String(nullable: false),
                        Pedido_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.Pedido_Id)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Sabors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeSabor = c.String(nullable: false, maxLength: 30),
                        DescSabor = c.String(nullable: false, maxLength: 60),
                        PrecoSabor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ObjPizza_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pizzas", t => t.ObjPizza_Id)
                .Index(t => t.ObjPizza_Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeProduto = c.String(nullable: false, maxLength: 50),
                        DescProduto = c.String(nullable: false, maxLength: 50),
                        PrecoProduto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProdutoItensPedidoes",
                c => new
                    {
                        Produto_Id = c.Int(nullable: false),
                        ItensPedido_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_Id, t.ItensPedido_id })
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id, cascadeDelete: true)
                .ForeignKey("dbo.ItensPedidoes", t => t.ItensPedido_id, cascadeDelete: true)
                .Index(t => t.Produto_Id)
                .Index(t => t.ItensPedido_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensPedidoes", "ObjPizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.Pizzas", "Pedido_Id", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "ObjSabor_Id", "dbo.Sabors");
            DropForeignKey("dbo.Pedidoes", "ObjProduto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.ProdutoItensPedidoes", "ItensPedido_id", "dbo.ItensPedidoes");
            DropForeignKey("dbo.ProdutoItensPedidoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "ObjPizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.Sabors", "ObjPizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.Pedidoes", "ObjCliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.ItensPedidoes", "ObjPedido_Id", "dbo.Pedidoes");
            DropIndex("dbo.ProdutoItensPedidoes", new[] { "ItensPedido_id" });
            DropIndex("dbo.ProdutoItensPedidoes", new[] { "Produto_Id" });
            DropIndex("dbo.Sabors", new[] { "ObjPizza_Id" });
            DropIndex("dbo.Pizzas", new[] { "Pedido_Id" });
            DropIndex("dbo.Pedidoes", new[] { "ObjSabor_Id" });
            DropIndex("dbo.Pedidoes", new[] { "ObjProduto_Id" });
            DropIndex("dbo.Pedidoes", new[] { "ObjPizza_Id" });
            DropIndex("dbo.Pedidoes", new[] { "ObjCliente_Id" });
            DropIndex("dbo.ItensPedidoes", new[] { "ObjPizza_Id" });
            DropIndex("dbo.ItensPedidoes", new[] { "ObjPedido_Id" });
            DropTable("dbo.ProdutoItensPedidoes");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Sabors");
            DropTable("dbo.Pizzas");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.ItensPedidoes");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Clientes");
        }
    }
}
