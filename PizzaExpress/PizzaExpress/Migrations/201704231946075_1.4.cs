namespace PizzaExpress.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "CPF");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CPF", c => c.String());
        }
    }
}
