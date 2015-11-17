namespace Teste2DAW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluger",
                c => new
                    {
                        AlugerID = c.Int(nullable: false, identity: true),
                        FuncionarioID = c.Int(nullable: false),
                        UtenteID = c.Int(nullable: false),
                        CopiaID = c.Int(nullable: false),
                        dataEmpretimo = c.DateTime(nullable: false),
                        dataEmtrega = c.DateTime(nullable: false),
                        devolvida = c.Boolean(nullable: false),
                        Multa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AlugerID)
                .ForeignKey("dbo.Copias", t => t.CopiaID)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioID)
                .ForeignKey("dbo.Utente", t => t.UtenteID)
                .Index(t => t.FuncionarioID)
                .Index(t => t.UtenteID)
                .Index(t => t.CopiaID);
            
            CreateTable(
                "dbo.Copias",
                c => new
                    {
                        CopiaID = c.Int(nullable: false, identity: true),
                        FilmeID = c.Int(nullable: false),
                        EstadoID = c.Int(nullable: false),
                        disponivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CopiaID)
                .ForeignKey("dbo.Estados", t => t.EstadoID)
                .ForeignKey("dbo.Filmes", t => t.FilmeID)
                .Index(t => t.FilmeID)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        EstadoID = c.Int(nullable: false, identity: true),
                        Designacao = c.String(),
                    })
                .PrimaryKey(t => t.EstadoID);
            
            CreateTable(
                "dbo.Filmes",
                c => new
                    {
                        FilmeID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Sinopse = c.String(),
                        CategoriaID = c.Int(nullable: false),
                        ActorPrincipal = c.String(),
                        ActorSecundario = c.String(),
                    })
                .PrimaryKey(t => t.FilmeID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID)
                .Index(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Designacao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        FuncionarioID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UserName = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.Utente",
                c => new
                    {
                        UtenteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sexo = c.String(),
                        Bairro = c.String(),
                        distrito = c.String(),
                        identificacao = c.String(),
                    })
                .PrimaryKey(t => t.UtenteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluger", "UtenteID", "dbo.Utente");
            DropForeignKey("dbo.Aluger", "FuncionarioID", "dbo.Funcionarios");
            DropForeignKey("dbo.Copias", "FilmeID", "dbo.Filmes");
            DropForeignKey("dbo.Filmes", "CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.Copias", "EstadoID", "dbo.Estados");
            DropForeignKey("dbo.Aluger", "CopiaID", "dbo.Copias");
            DropIndex("dbo.Filmes", new[] { "CategoriaID" });
            DropIndex("dbo.Copias", new[] { "EstadoID" });
            DropIndex("dbo.Copias", new[] { "FilmeID" });
            DropIndex("dbo.Aluger", new[] { "CopiaID" });
            DropIndex("dbo.Aluger", new[] { "UtenteID" });
            DropIndex("dbo.Aluger", new[] { "FuncionarioID" });
            DropTable("dbo.Utente");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Categorias");
            DropTable("dbo.Filmes");
            DropTable("dbo.Estados");
            DropTable("dbo.Copias");
            DropTable("dbo.Aluger");
        }
    }
}
