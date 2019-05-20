# Desafio Desenvolvedor Automação

Seja parte de um dos grupos de empresas e franqueadoras que mais cresce no Brasil.

Esse é o nosso desafio para a vaga de desenvolvedor de automações  no [Grupo Zanon](http://www.grupozanon.com.br/). 

Procuramos desenvolvedor engajado, versátil em resolver problemas que impactam o negócio de empresas, utilizando conhecimento de desenvolvimento de tecnologias para automações.
Confortável com a responsabilidade de criar, gerir e publicar aplicações.
Ávido por buscar sempre boas práticas para trabalhar com inovação, tecnologias modernas e emergentes.


### O que procuramos?
- Perfil proativo, saber trabalhar em equipe , raciocínio lógico, responsabilidade e comprometimento são imprescindíveis para essa oportunidade.
- Fácil adaptação em projetos experimentais e complexos;
- Aprendizado rápido no uso de tecnologias de desenvolvimento de software


### Instruções para o desafio

- **Fork** esse repositório e faça o desafio numa branch com o seu nome (exemplo: `nome-sobrenome`);
- Assim que concluir o seu desafio, abra um **pull request** com suas alterações.

### Tempo gasto
- Recomendamos utilizar no máximo até 3 horas no desenvolvimento deste projeto.

### Desafio 
- Criar o banco de dados de acordo com a seguinte estrutura: Tabela Pessoa (Id PrimaryKey Identity, Nome VARCHAR 300, Cidade VARCHAR 300, Estado VARCHAR 150) tabela Contato (Id INT Primary Key Identity, Pessoa INT Foreign Key tabela Pessoa, Email VARCHAR 150, DDD VARCHAR 3, Telefone VARCHAR 15), Tabela StatusMensagemEnviada (Id INT Primary Key identity, Pessoa INT Foreign Key tabela Pessoa, Contato INT Foreign Key Tabela Contato, Assunto VARCHAR 1000, MensagemEnviada VARCHAR MAX, RetornoSite VARCHAR MAX).
- Popule todas as colunas das tabelas Pessoa e Contato com pelo menos 1 registro.
- Automatizar o preenchimento do formulário no site: http://seguralta.com.br/site/contato
- Preencher os campos do formulário com os dados do banco, mais assunto, e mensagem.
- Obter o retorno do status da mensagem enviada pelo formulario (Mensagem que o site mostra ao enviar o formulário, como, "Obrigado...")
- Salvar no banco de dados na tabela StatusMensagemEnviada os dados enviados no formulario (Pessoa, Contato, Assunto, Mensagem Enviada e retorno do site)
- Salvar script do banco de dados no Projeto no arquivo Script


### Escopo do desafio
- Instruções básicas de uso dos métodos.
- Documentar todas suposições realizadas.
- O desenvolvimento deve ser feito em C# .
- Preferencialmente utilizar Selenium.
- Preferencialmente utilizar EntityFramework.
- É aceitável utilizar algumas respostas estáticas em determinadas porções da aplicação.
- Não é necessário submeter uma aplicação que cumpra cada um dos requisitos descritos, mas o que for submetido deve funcionar.


### O que será avaliado
- O código será avaliado seguindo os seguintes critérios: manutenabilidade, clareza e limpeza de código, resultado funcional, entre outros fatores. 
- O histórico no `git` também está avaliado.
- Se necessário explique as decisões técnicas tomadas, as escolhas por bibliotecas e ferrramentas, o uso de patterns etc.


### Diferenciais
- Criar uma validações de erros, caso o dado não exista ou campo do formulário não existir.
- Validações se os campos foram preenchidos corretamente.
- Boa documentação de código e de serviços.

---
Em caso de dúvidas, envie um email para [caio.yonashiro@grupozanon.com.br](mailto:caio.yonashiro@grupozanon.com.br).


**Um dos nossos pilares é a valorização das pessoas e temos orgulho de dizer que somos uma empresa que apoia a diversidade e inclusão. Sendo assim, consideramos todos os candidatos para as nossas oportunidades, independente de raça, cor, religião, gênero, identidade de gênero, nacionalidade, deficiência, ascendência ou idade.**


**Até breve**
