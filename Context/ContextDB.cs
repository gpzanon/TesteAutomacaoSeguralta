namespace Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ContextDB : DbContext
    {
        public ContextDB()
            : base("name=ConexaoPadrao")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<StatusMensagemEnviada> StatusMensagemEnviada { get; set; }

        public bool VerificarConflito(string nome)
        {
            if (Pessoa.Any(p => p.Nome == nome))
                return true;
            else
                return false;
        }

    }
}
