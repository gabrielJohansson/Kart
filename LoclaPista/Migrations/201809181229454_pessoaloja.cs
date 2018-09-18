namespace LoclaPista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pessoaloja : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PessoaLojas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        loja_Id = c.Int(),
                        pessoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lojas", t => t.loja_Id)
                .ForeignKey("dbo.Pessoas", t => t.pessoa_Id)
                .Index(t => t.loja_Id)
                .Index(t => t.pessoa_Id);
            
            AddColumn("dbo.Carroes", "loja_Id", c => c.Int());
            CreateIndex("dbo.Carroes", "loja_Id");
            AddForeignKey("dbo.Carroes", "loja_Id", "dbo.Lojas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PessoaLojas", "pessoa_Id", "dbo.Pessoas");
            DropForeignKey("dbo.PessoaLojas", "loja_Id", "dbo.Lojas");
            DropForeignKey("dbo.Carroes", "loja_Id", "dbo.Lojas");
            DropIndex("dbo.PessoaLojas", new[] { "pessoa_Id" });
            DropIndex("dbo.PessoaLojas", new[] { "loja_Id" });
            DropIndex("dbo.Carroes", new[] { "loja_Id" });
            DropColumn("dbo.Carroes", "loja_Id");
            DropTable("dbo.PessoaLojas");
        }
    }
}
