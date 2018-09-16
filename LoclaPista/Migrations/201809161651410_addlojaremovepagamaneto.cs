namespace LoclaPista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlojaremovepagamaneto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Corridas", "pagamento_Id", "dbo.Pagamentoes");
            DropIndex("dbo.Corridas", new[] { "pagamento_Id" });
            CreateTable(
                "dbo.Lojas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Dono_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.Dono_Id)
                .Index(t => t.Dono_Id);
            
            AddColumn("dbo.Corridas", "loja_Id", c => c.Int());
            AddColumn("dbo.Pistas", "loja_Id", c => c.Int());
            CreateIndex("dbo.Corridas", "loja_Id");
            CreateIndex("dbo.Pistas", "loja_Id");
            AddForeignKey("dbo.Corridas", "loja_Id", "dbo.Lojas", "Id");
            AddForeignKey("dbo.Pistas", "loja_Id", "dbo.Lojas", "Id");
            DropColumn("dbo.Corridas", "pagamento_Id");
            DropTable("dbo.Pagamentoes");
        }
        
        public override void Down()
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
            DropForeignKey("dbo.Pistas", "loja_Id", "dbo.Lojas");
            DropForeignKey("dbo.Corridas", "loja_Id", "dbo.Lojas");
            DropForeignKey("dbo.Lojas", "Dono_Id", "dbo.Pessoas");
            DropIndex("dbo.Pistas", new[] { "loja_Id" });
            DropIndex("dbo.Lojas", new[] { "Dono_Id" });
            DropIndex("dbo.Corridas", new[] { "loja_Id" });
            DropColumn("dbo.Pistas", "loja_Id");
            DropColumn("dbo.Corridas", "loja_Id");
            DropTable("dbo.Lojas");
            CreateIndex("dbo.Corridas", "pagamento_Id");
            AddForeignKey("dbo.Corridas", "pagamento_Id", "dbo.Pagamentoes", "Id");
        }
    }
}
