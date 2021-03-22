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
        ContextDB dataBase = new ContextDB("connectionString");

       
        private static void AutomatizarGrid()
        {
            //Inicia uma nova instância do Google Chrome com o Selenium
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            ChromeOptions chromeOption = new ChromeOptions();

            //Desativando a mensagem de que o software está sendo automatizado por um framework de testes
            chromeOption.AddArguments("disable-infobars");

            //Iniciando o Chrome
            ChromeDriver driver = new ChromeDriver(service, chromeOption);

            //Maximizando a janela
            driver.Manage().Window.Maximize();
            ContextDB dataBase = new ContextDB("connectionString");
            //Navegando para o site
            driver.Navigate().GoToUrl("https://seguralta.com.br/site/contato");
            //Trocando o contexto para o IFrame dos elementos para interação, no exemplo do formulário da Seguralta não será necessário
            var mensagem = dataBase.StatusMensagemEnviada.Include("Pessoa").Include("Contato");

            foreach (var msg in mensagem)
            {
                var pessoa = msg.Pessoa1;

                var contato = msg.Contato1;

                if (pessoa != null && contato != null)
                {
                    driver.FindElement(By.Id("name")).Click();
                    driver.FindElement(By.Id("email")).Click();
                    driver.FindElement(By.Id("cep")).Click();
                    driver.FindElement(By.Id("estado")).Click();
                    new SelectElement(driver.FindElement(By.Id("estado"))).SelectByText("Tocantins");
                    driver.FindElement(By.Id("estado")).Click();
                    driver.FindElement(By.Id("cidade")).Click();
                    driver.FindElement(By.Id("estado")).Click();
                    new SelectElement(driver.FindElement(By.Id("estado"))).SelectByText("São Paulo");
                    driver.FindElement(By.Id("estado")).Click();
                    driver.FindElement(By.Id("cidade")).Click();
                    new SelectElement(driver.FindElement(By.Id("cidade"))).SelectByText("São José do Rio Preto");
                    driver.FindElement(By.Id("cidade")).Click();
                    driver.FindElement(By.Id("assunto")).Click();
                    driver.FindElement(By.Id("assunto")).Clear();
                    driver.FindElement(By.Id("assunto")).SendKeys("Teste1");
                    driver.FindElement(By.Id("telefone")).Click();
                    driver.FindElement(By.Id("mensagem")).Click();
                    driver.FindElement(By.Id("mensagem")).Clear();
                    driver.FindElement(By.Id("mensagem")).SendKeys("Teste de automação");
                    driver.FindElement(By.Id("telefone")).Click();

                    var status = new StatusMensagemEnviada();


                    driver.Quit();
                    dataBase.SaveChanges();
                }
            }
             private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        }

    }
}
