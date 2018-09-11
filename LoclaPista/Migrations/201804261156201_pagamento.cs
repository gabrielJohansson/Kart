namespace LoclaPista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pagamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pagamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        pagamento = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Corridas", "pagamento_Id", c => c.Int());
            CreateIndex("dbo.Corridas", "pagamento_Id");
            AddForeignKey("dbo.Corridas", "pagamento_Id", "dbo.Pagamentoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Corridas", "pagamento_Id", "dbo.Pagamentoes");
            DropIndex("dbo.Corridas", new[] { "pagamento_Id" });
            DropColumn("dbo.Corridas", "pagamento_Id");
            DropTable("dbo.Pagamentoes");
        }
    }
}
