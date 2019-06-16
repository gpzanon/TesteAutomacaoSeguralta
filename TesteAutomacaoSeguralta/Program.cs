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
        ContextDB dataBase = new ContextDB();

        static void Main(string[] args)
        {
            AutomatizarGrid();

            Console.ReadKey();
        }

        private static void AutomatizarGrid()
        {
            try
            {
                using (var dB = new ContextDB())
                {
                    var listaMensagem = dB.StatusMensagemEnviada.Include("Pessoa1").Include("Contato1");

                    foreach (var item in listaMensagem)
                    {
                        var pessoa = item.Pessoa1;

                        var contato = item.Contato1;

                        if (pessoa != null && contato != null)
                        {
                            ChromeDriverService service = ChromeDriverService.CreateDefaultService();

                            ChromeOptions chromeOption = new ChromeOptions();

                            chromeOption.AddArguments("disable-infobars");
                            ChromeDriver driver = new ChromeDriver(service, chromeOption);
                            driver.Manage().Window.Maximize();
                            driver.Navigate().GoToUrl("http://seguralta.com.br/site/contato");
                            driver.FindElement(By.Id("name")).SendKeys(pessoa.Nome);
                            driver.FindElement(By.Id("email")).SendKeys(contato.Email);
                            driver.FindElement(By.Id("cep")).Click();
                            driver.FindElement(By.Id("cep")).SendKeys(Convert.ToString(pessoa.Cep));
                            driver.FindElement(By.Id("estado")).SendKeys(pessoa.Estado);
                            System.Threading.Thread.Sleep(5000);
                            driver.FindElement(By.Id("cidade")).SendKeys(pessoa.Cidade);
                            driver.FindElement(By.Id("assunto")).SendKeys(item.Assunto);
                            driver.FindElement(By.Id("telefone")).Click();
                            driver.FindElement(By.Id("telefone")).SendKeys(contato.DDD + contato.Telefone);
                            driver.FindElement(By.Id("mensagem")).SendKeys(item.MensagemEnviada);
                            driver.FindElement(By.CssSelector("input[type = 'submit']")).Click();

                            var status = new StatusMensagemEnviada();
                            status = item;
                            status.RetornoSite = driver.FindElement(By.ClassName("col-md-8")).Text;             

                            driver.Quit();
                        }
                    }

                    dB.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
