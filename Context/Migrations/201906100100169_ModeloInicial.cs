namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contatos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 150),
                        DDD = c.String(maxLength: 3),
                        Telefone = c.String(maxLength: 15),
                        StatusMensagemEnviada_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StatusMensagemEnviadas", t => t.StatusMensagemEnviada_Id)
                .Index(t => t.StatusMensagemEnviada_Id);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 300),
                        Cidade = c.String(maxLength: 300),
                        Estado = c.String(maxLength: 150),
                        Contato_Id = c.Int(),
                        StatusMensagemEnviada_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contatos", t => t.Contato_Id)
                .ForeignKey("dbo.StatusMensagemEnviadas", t => t.StatusMensagemEnviada_Id)
                .Index(t => t.Contato_Id)
                .Index(t => t.StatusMensagemEnviada_Id);
            
            CreateTable(
                "dbo.StatusMensagemEnviadas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Assunto = c.String(maxLength: 1000),
                        MensagemEnviada = c.String(),
                        RetornoSite = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pessoas", "StatusMensagemEnviada_Id", "dbo.StatusMensagemEnviadas");
            DropForeignKey("dbo.Contatos", "StatusMensagemEnviada_Id", "dbo.StatusMensagemEnviadas");
            DropForeignKey("dbo.Pessoas", "Contato_Id", "dbo.Contatos");
            DropIndex("dbo.Pessoas", new[] { "StatusMensagemEnviada_Id" });
            DropIndex("dbo.Pessoas", new[] { "Contato_Id" });
            DropIndex("dbo.Contatos", new[] { "StatusMensagemEnviada_Id" });
            DropTable("dbo.StatusMensagemEnviadas");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Contatos");
        }
    }
}
