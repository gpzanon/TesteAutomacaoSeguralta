namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 150),
                        DDD = c.String(maxLength: 3),
                        Telefone = c.String(maxLength: 15),
                        Pessoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_Id)
                .Index(t => t.Pessoa_Id);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 300),
                        Cidade = c.String(maxLength: 300),
                        Estado = c.String(maxLength: 150),
                        CEP = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusMensagemEnviada",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Assunto = c.String(maxLength: 1000),
                        MensagemEnviada = c.String(),
                        RetornoSite = c.String(),
                        Contato_Id = c.Int(),
                        Pessoa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contato", t => t.Contato_Id)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_Id)
                .Index(t => t.Contato_Id)
                .Index(t => t.Pessoa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatusMensagemEnviada", "Pessoa_Id", "dbo.Pessoa");
            DropForeignKey("dbo.StatusMensagemEnviada", "Contato_Id", "dbo.Contato");
            DropForeignKey("dbo.Contato", "Pessoa_Id", "dbo.Pessoa");
            DropIndex("dbo.StatusMensagemEnviada", new[] { "Pessoa_Id" });
            DropIndex("dbo.StatusMensagemEnviada", new[] { "Contato_Id" });
            DropIndex("dbo.Contato", new[] { "Pessoa_Id" });
            DropTable("dbo.StatusMensagemEnviada");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Contato");
        }
    }
}
