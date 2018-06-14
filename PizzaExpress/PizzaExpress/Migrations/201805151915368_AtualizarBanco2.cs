namespace PizzaExpress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizarBanco2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProdutoItensPedidoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.ProdutoItensPedidoes", "ItensPedido_Id", "dbo.ItensPedidoes");
            DropIndex("dbo.ProdutoItensPedidoes", new[] { "Produto_Id" });
            DropIndex("dbo.ProdutoItensPedidoes", new[] { "ItensPedido_Id" });
            AddColumn("dbo.Produtoes", "ItensPedido_Id", c => c.Int());
            CreateIndex("dbo.Produtoes", "ItensPedido_Id");
            AddForeignKey("dbo.Produtoes", "ItensPedido_Id", "dbo.ItensPedidoes", "Id");
            DropTable("dbo.ProdutoItensPedidoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProdutoItensPedidoes",
                c => new
                    {
                        Produto_Id = c.Int(nullable: false),
                        ItensPedido_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_Id, t.ItensPedido_Id });
            
            DropForeignKey("dbo.Produtoes", "ItensPedido_Id", "dbo.ItensPedidoes");
            DropIndex("dbo.Produtoes", new[] { "ItensPedido_Id" });
            DropColumn("dbo.Produtoes", "ItensPedido_Id");
            CreateIndex("dbo.ProdutoItensPedidoes", "ItensPedido_Id");
            CreateIndex("dbo.ProdutoItensPedidoes", "Produto_Id");
            AddForeignKey("dbo.ProdutoItensPedidoes", "ItensPedido_Id", "dbo.ItensPedidoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutoItensPedidoes", "Produto_Id", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
    }
}
