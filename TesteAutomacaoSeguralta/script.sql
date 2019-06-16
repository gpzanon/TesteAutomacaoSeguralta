----------------------
 -- Criando Database GrupoZanon
 -- Henrique Andrade - 16/09/2019
----------------------

IF (NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE ('[' + name + ']' = 'GrupoZanon' OR name = 'GrupoZanon')))
BEGIN

CREATE DATABASE [GrupoZanon]; 

END

GO

USE GrupoZanon;

----------------------
 -- Criando a tabela Pessoa
 -- Henrique Andrade - 16/09/2019
----------------------
PRINT 'Criando a tabela Pessoa ...'

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Pessoa')
BEGIN
   CREATE TABLE Pessoa (
          Id INT NOT NULL IDENTITY,
          Nome VARCHAR(300) NOT NULL,
          Cidade VARCHAR(300) NOT NULL,
          Estado VARCHAR(150) NOT NULL,
          Cep VARCHAR(8) NOT NULL,
		  CONSTRAINT PK_Pessoa PRIMARY KEY (Id)
   );

   INSERT INTO Pessoa (Nome, Cidade, Estado, Cep)
   SELECT 'Henrique Andrade', 'Barra Bonita', 'São Paulo', '17340000' UNION ALL
   SELECT 'Bruno Andrade', 'Pederneiras', 'São Paulo', '17280000' UNION ALL
   SELECT 'Alexandre Videschi Marques', 'São José do Rio Preto', 'São Paulo', '25780000'
END
GO

----------------------
 -- Criando a tabela Contato
 -- Henrique Andrade - 16/09/2019
----------------------
PRINT 'Criando a tabela Contato ...'

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Contato')
BEGIN
   CREATE TABLE Contato (
          Id INT NOT NULL IDENTITY,
		  Pessoa INT NOT NULL,
          Email VARCHAR(150) NOT NULL,
          DDD VARCHAR(3) NOT NULL,
          Telefone VARCHAR(15) NOT NULL,
		  CONSTRAINT PK_Contato PRIMARY KEY (Id),
		  CONSTRAINT FK_ContatoPessoa FOREIGN KEY (Pessoa)
	      REFERENCES Pessoa(Id)
   );

   INSERT INTO Contato (Pessoa, Email,  DDD, Telefone)
   SELECT 1, 'henrique.andradesilva@hotmail.com', '14', '996204986' UNION ALL
   SELECT 2, 'bruno.andradesilva@hotmail.com', '14', '995682158' UNION ALL
   SELECT 3, 'alexandre.ti@seguralta.com.br', '11', '997858458'
END
GO

----------------------
 -- Criando a tabela StatusMensagemEnviada
 -- Henrique Andrade - 16/09/2019
----------------------
PRINT 'Criando a tabela StatusMensagemEnviada ...'

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StatusMensagemEnviada')
BEGIN
   CREATE TABLE StatusMensagemEnviada (
          Id INT NOT NULL IDENTITY,
		  Pessoa INT NOT NULL,
		  Contato INT NOT NULL,
          Assunto VARCHAR(1000) NOT NULL,
          MensagemEnviada VARCHAR(MAX) NOT NULL,
          RetornoSite VARCHAR(MAX) NULL,
		  CONSTRAINT PK_StatusMensagemEnviada PRIMARY KEY (Id),
		  CONSTRAINT FK_StatusMensagemEnviadaPessoa FOREIGN KEY (Pessoa)
	      REFERENCES Pessoa(Id),
		  CONSTRAINT FK_StatusMensagemEnviadaContato FOREIGN KEY (Contato)
	      REFERENCES Contato(Id)
   );

   INSERT INTO StatusMensagemEnviada (Pessoa, Contato, Assunto, MensagemEnviada)
   SELECT 1, 1, 'Teste 01 - Projeto Seguralta', 'Teste do projeto da Seguralta - 01' UNION ALL
   SELECT 2, 2, 'Teste 02 - Projeto Seguralta', 'Teste do projeto da Seguralta - 02' UNION ALL
   SELECT 3, 3, 'Teste 03 - Projeto Seguralta', 'Teste do projeto da Seguralta - 03' 
END
GO