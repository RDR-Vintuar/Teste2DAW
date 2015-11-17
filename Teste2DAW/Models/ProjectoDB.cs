using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Teste2DAW.Models
{
    public class ProjectoDB : DbContext
    {
        public ProjectoDB() {
            
            Configuration.ProxyCreationEnabled = false;
        } 
        
        public DbSet<Funcionario> funcionarios { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Filme> filmes { get; set; }

        public DbSet<Copia> copias { get; set; }

        public DbSet<Utente> utentes { get; set; }

        public DbSet<Aluger> aluger { get; set; }

        public DbSet<AlugerCopias> alugercopias { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultContext, Configuration>());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


        }
    }
}