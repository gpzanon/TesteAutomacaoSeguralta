using Context;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutomacaoSeguralta
{
    class Program
    {

        static void Main(string[] args)
        {
            string nomeCompleto = "Alexandre Videschi Marques";
            string email = "alexandre.ti@seguralta.com.br";
            int CEP = 15015700;
            string estado = "São Paulo";
            string cidade = "São José do Rio Preto";
            string assunto = "Teste projeto Seguralta";
            string telefone = "17997777777";
            string mensagem = "Teste do projeto da Seguralta";
            AutomatizarGrid(nomeCompleto, email, CEP, estado, cidade, assunto, telefone, mensagem);
        }

        private static void AutomatizarGrid(string nomeCompleto, string email, int CEP, string estado, string cidade, string assunto, string telefone, string mensagem)
        {
            var dB = new ContextDB();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            ChromeOptions chromeOption = new ChromeOptions();
            if (!dB.VerificarConflito(nomeCompleto))
            {
                chromeOption.AddArguments("disable-infobars");
                ChromeDriver driver = new ChromeDriver(service, chromeOption);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://seguralta.com.br/site/contato");
                driver.FindElement(By.Id("name")).SendKeys(nomeCompleto);
                driver.FindElement(By.Id("email")).SendKeys(email);
                driver.FindElement(By.Id("cep")).Click();
                driver.FindElement(By.Id("cep")).SendKeys(Convert.ToString(CEP));
                driver.FindElement(By.Id("estado")).SendKeys(estado);
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.Id("cidade")).SendKeys(cidade);
                driver.FindElement(By.Id("assunto")).SendKeys(assunto);
                driver.FindElement(By.Id("mensagem")).SendKeys(mensagem);
                driver.FindElement(By.Id("telefone")).Click();
                driver.FindElement(By.Id("telefone")).SendKeys(telefone);
                driver.FindElement(By.CssSelector("input[type = 'submit']")).Click();
                

                var pessoa = new Pessoa();
                pessoa.Nome = nomeCompleto;
                pessoa.Cidade = cidade;
                pessoa.Estado = estado;
                pessoa.CEP = Convert.ToString(CEP);
                

                var contato = new Contato();
                contato.Email = email;
                contato.DDD = telefone.Substring(0, 2);
                contato.Telefone = telefone.Substring(2, 9);
                contato.Pessoa = pessoa;

                var status = new StatusMensagemEnviada();
                status.Assunto = assunto;
                status.MensagemEnviada = mensagem;
                status.RetornoSite = driver.FindElement(By.ClassName("col-md-8")).Text;
                status.Pessoa = pessoa;
                status.Contato = contato;


                dB.StatusMensagemEnviada.Add(status);
                dB.SaveChanges();
                driver.Quit();
            }
            else
            {
                Console.WriteLine("Pessoa ja cadastrada no banco de dados! Ja foi enviado o formulario de contato.");
            }
        }
    }
}
