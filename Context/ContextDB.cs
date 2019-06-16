namespace Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextDB : DbContext
    {
        public ContextDB()
            : base("name=Conexao")
        {
        }

        public virtual DbSet<Contato> Contato { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<StatusMensagemEnviada> StatusMensagemEnviada { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.DDD)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Contato>()
                .HasMany(e => e.StatusMensagemEnviada)
                .WithOptional(e => e.Contato1)
                .HasForeignKey(e => e.Contato);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Cep)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Contato)
                .WithOptional(e => e.Pessoa1)
                .HasForeignKey(e => e.Pessoa);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.StatusMensagemEnviada)
                .WithOptional(e => e.Pessoa1)
                .HasForeignKey(e => e.Pessoa);

            modelBuilder.Entity<StatusMensagemEnviada>()
                .Property(e => e.Assunto)
                .IsUnicode(false);

            modelBuilder.Entity<StatusMensagemEnviada>()
                .Property(e => e.MensagemEnviada)
                .IsUnicode(false);

            modelBuilder.Entity<StatusMensagemEnviada>()
                .Property(e => e.RetornoSite)
                .IsUnicode(false);
        }
    }
}
