namespace LoclaPista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredcar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carroes", "placa", c => c.String(nullable: false));
            AlterColumn("dbo.Carroes", "modelo", c => c.String(nullable: false));
            AlterColumn("dbo.Carroes", "marca", c => c.String(nullable: false));
            AlterColumn("dbo.Carroes", "cor", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carroes", "cor", c => c.String());
            AlterColumn("dbo.Carroes", "marca", c => c.String());
            AlterColumn("dbo.Carroes", "modelo", c => c.String());
            AlterColumn("dbo.Carroes", "placa", c => c.String());
        }
    }
}
