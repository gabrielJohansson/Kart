namespace LoclaPista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TabelaCarroPessoas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dtaCadastro = c.DateTime(nullable: false),
                        c_Id = c.Int(),
                        p_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Carroes", t => t.c_Id)
                .ForeignKey("dbo.Pessoas", t => t.p_Id)
                .Index(t => t.c_Id)
                .Index(t => t.p_Id);
            
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        placa = c.String(),
                        modelo = c.String(),
                        marca = c.String(),
                        cor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Adm = c.Byte(nullable: false),
                        Senha = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        dtaCadastro = c.DateTime(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComposicaoCorridas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        c_Id = c.Int(),
                        p_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Carroes", t => t.c_Id)
                .ForeignKey("dbo.Pessoas", t => t.p_Id)
                .Index(t => t.c_Id)
                .Index(t => t.p_Id);
            
            CreateTable(
                "dbo.Corridas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DtaCadastro = c.DateTime(nullable: false),
                        DtaCorrida = c.DateTime(nullable: false),
                        DtaCancelamento = c.DateTime(nullable: false),
                        Preco = c.Double(nullable: false),
                        comp_id = c.Int(),
                        Pista_Id = c.Int(),
                        Responsavel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComposicaoCorridas", t => t.comp_id)
                .ForeignKey("dbo.Pistas", t => t.Pista_Id)
                .ForeignKey("dbo.Pessoas", t => t.Responsavel_Id)
                .Index(t => t.comp_id)
                .Index(t => t.Pista_Id)
                .Index(t => t.Responsavel_Id);
            
            CreateTable(
                "dbo.Pistas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        dtaCadastro = c.DateTime(nullable: false),
                        Ativo = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HorarioPistas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Hora_inicial = c.DateTime(nullable: false),
                        Hora_Final = c.DateTime(nullable: false),
                        pista_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Pistas", t => t.pista_Id)
                .Index(t => t.pista_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HorarioPistas", "pista_Id", "dbo.Pistas");
            DropForeignKey("dbo.Corridas", "Responsavel_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Corridas", "Pista_Id", "dbo.Pistas");
            DropForeignKey("dbo.Corridas", "comp_id", "dbo.ComposicaoCorridas");
            DropForeignKey("dbo.ComposicaoCorridas", "p_Id", "dbo.Pessoas");
            DropForeignKey("dbo.ComposicaoCorridas", "c_Id", "dbo.Carroes");
            DropForeignKey("dbo.TabelaCarroPessoas", "p_Id", "dbo.Pessoas");
            DropForeignKey("dbo.TabelaCarroPessoas", "c_Id", "dbo.Carroes");
            DropIndex("dbo.HorarioPistas", new[] { "pista_Id" });
            DropIndex("dbo.Corridas", new[] { "Responsavel_Id" });
            DropIndex("dbo.Corridas", new[] { "Pista_Id" });
            DropIndex("dbo.Corridas", new[] { "comp_id" });
            DropIndex("dbo.ComposicaoCorridas", new[] { "p_Id" });
            DropIndex("dbo.ComposicaoCorridas", new[] { "c_Id" });
            DropIndex("dbo.TabelaCarroPessoas", new[] { "p_Id" });
            DropIndex("dbo.TabelaCarroPessoas", new[] { "c_Id" });
            DropTable("dbo.HorarioPistas");
            DropTable("dbo.Pistas");
            DropTable("dbo.Corridas");
            DropTable("dbo.ComposicaoCorridas");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Carroes");
            DropTable("dbo.TabelaCarroPessoas");
        }
    }
}
