namespace Teste2DAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Qualquernome : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Aluger", "CopiaID", "dbo.Copias");
            DropIndex("dbo.Aluger", new[] { "CopiaID" });
            CreateTable(
                "dbo.AlugerCopias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CopiaID = c.Int(nullable: false),
                        AlugerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Aluger", t => t.AlugerID)
                .ForeignKey("dbo.Copias", t => t.CopiaID)
                .Index(t => t.CopiaID)
                .Index(t => t.AlugerID);
            
            DropColumn("dbo.Aluger", "CopiaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluger", "CopiaID", c => c.Int(nullable: false));
            DropForeignKey("dbo.AlugerCopias", "CopiaID", "dbo.Copias");
            DropForeignKey("dbo.AlugerCopias", "AlugerID", "dbo.Aluger");
            DropIndex("dbo.AlugerCopias", new[] { "AlugerID" });
            DropIndex("dbo.AlugerCopias", new[] { "CopiaID" });
            DropTable("dbo.AlugerCopias");
            CreateIndex("dbo.Aluger", "CopiaID");
            AddForeignKey("dbo.Aluger", "CopiaID", "dbo.Copias", "CopiaID");
        }
    }
}
