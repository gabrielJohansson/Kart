namespace LoclaPista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Corridas", "comp_id", "dbo.ComposicaoCorridas");
            DropIndex("dbo.Corridas", new[] { "comp_id" });
            AddColumn("dbo.ComposicaoCorridas", "ComposicaoGuid", c => c.String());
            AddColumn("dbo.Corridas", "ComposicaoGuid", c => c.String());
            DropColumn("dbo.Corridas", "comp_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Corridas", "comp_id", c => c.Int());
            DropColumn("dbo.Corridas", "ComposicaoGuid");
            DropColumn("dbo.ComposicaoCorridas", "ComposicaoGuid");
            CreateIndex("dbo.Corridas", "comp_id");
            AddForeignKey("dbo.Corridas", "comp_id", "dbo.ComposicaoCorridas", "id");
        }
    }
}
