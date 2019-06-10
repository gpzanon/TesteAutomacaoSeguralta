namespace Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class ContextDB : DbContext
    {
        public ContextDB()
            : base("name=ConexaoPadrao")
        {
        }

        public DbSet<Contato> Contato { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<StatusMensagemEnviada> StatusMensagemEnviada { get; set; }

    }
}
