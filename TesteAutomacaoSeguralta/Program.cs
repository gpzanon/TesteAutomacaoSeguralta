﻿using Context;
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
        ContextDB dataBase = new ContextDB("Data Source=(local);Initial Catalog=seguralta;Integrated Security=True");

        static void Main(string[] args)
        {
            /*
             string nomeCompleto = "Alexandre Videschi Marques";
             string email = "alexandre.ti@seguralta.com.br";
             int CEP = 15015700;
             string estado = "São Paulo";
             string cidade = "São José do Rio Preto";
             string assunto = "Teste projeto Seguralta";
             string telefone = "017997777777";
             string mensagem = "Teste do projeto da Seguralta";*/

             //Codificar aqui e excluir essa linha para não interferir no teste.
            AutomatizarGrid(); //Linha de exemplo
        }

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

            //Navegando para o site
            driver.Navigate().GoToUrl("http://seguralta.com.br/site/contato");

            //Trocando o contexto para o IFrame dos elementos para interação, no exemplo do formulário da Seguralta não será necessário
            //driver.SwitchTo().Frame(0);

            //Definindo os valores

            driver.FindElement(By.Id("name")).SendKeys("Alexandre Videschi Marques");
            driver.FindElement(By.Id("email")).SendKeys("alexandre.ti@seguralta.com.br");
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.Id("cep")).SendKeys("15015700");
            driver.FindElement(By.Id("estado")).SendKeys("São Paulo");
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.Id("cidade")).SendKeys("São José do Rio Preto");
            driver.FindElement(By.Id("assunto")).SendKeys("Teste projeto Seguralta");
            driver.FindElement(By.Id("mensagem")).SendKeys("y gybyybuyg ygygygyig gyyiuf y ");
            driver.FindElement(By.Id("telefone")).SendKeys("017997777777");
            //driver.FindElement(By.ClassName("btn btn-success btn-orange btn-md pull-right")).Click();
            //new SelectElement(driver.FindElement(By.CssSelector("#demo > thead > tr.fltrow > td:nth-child(4) > select"))).SelectByValue(">0 && <=25000");
            // driver.FindElement(By.Id("flt5_demo")).SendKeys("190");
            //driver.FindElement(By.Id("flt5_demo")).SendKeys(Keys.Enter);

            //Obtendo valor
            //string year = driver.FindElement(By.CssSelector("#demo > tbody > tr.odd > td:nth-child(3)")).Text;

            //Printando valor
            // Console.WriteLine("O ano é: " + year);
        }
    }
}
