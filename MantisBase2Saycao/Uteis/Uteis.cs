using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using MantisBase2Saycao.Uteis.Helper;
using MantisBase2Saycao.Uteis.Driver;
using System;
using NUnit.Framework;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace MantisBase2Saycao.Uteis
{
    public class Uteis
    {

        WaitUntil wait = new WaitUntil(DriverFactory.INSTANCE);

        public void limpaCampoInput(IWebElement elemento, string nomePageObjects)
        {
            wait.ElementToBeClickable(elemento);
            elemento.Clear();
           
            //Relatorio.test.Pass("O elemento foi limpo: "+ nomePageObjects);
        }//fim void

        public void limpaCampoInput(IWebElement elemento)
        {
            wait.ElementToBeClickable(elemento);
            elemento.Clear();
        }//fim void


        //Variável: uteis.RetornaNomeVariavel(() => InputLogin)
        public string RetornaNomeVariavel<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }


        public void preencheCampoInput(IWebElement elemento, string valor, string nomePageObjects)
        {
            limpaCampoInput(elemento, nomePageObjects);
            wait.ElementToBeClickable(elemento).SendKeys(valor);
            Relatorio.test.Pass("O elemento '" + nomePageObjects + "' foi preenchido com o valor: "+ valor);
        }

        public void preencheCampoInput(IWebElement elemento, string valor)
        {
            limpaCampoInput(elemento, valor);
            wait.ElementToBeClickable(elemento).SendKeys(valor);
        }

        public void clicaBotao(IWebElement elemento)
        {
            wait.ElementToBeClickable(elemento);
            elemento.Click();
        }

        public void clicaBotao(IWebElement elemento, string nomePageObjects)
        {
            wait.ElementToBeClickable(elemento);
            elemento.Click();
            Relatorio.test.Pass("O elemento '" + nomePageObjects + "' foi clicado.");
            Thread.Sleep(500);
        }



        public void escolherElementoDropDown(IWebElement elemento, string valor)
        {
            wait.ElementToBeClickable(elemento);
            new SelectElement(elemento).SelectByText(valor);
        }

        public void escolherElementoDropDown(IWebElement elemento, string valor, string nomePageObjects)
        {
            wait.ElementToBeClickable(elemento);
            new SelectElement(elemento).SelectByText(valor);
            Relatorio.test.Pass("O elemento '" + nomePageObjects + "' foi preenchido com o valor: '" + valor);
        }


        public string gerarPrintScreen()
        {
            Screenshot ss = ((ITakesScreenshot)DriverFactory.INSTANCE).GetScreenshot();

            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;

            string time = DateTime.Now.ToString("HHmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string descrTeste = TestContext.CurrentContext.Test.Name;
            descrTeste = descrTeste.Replace("\"","'");
            string printAtual = descrTeste + "_" + time + ".png";
            string fullPathSS = ConfigurationManager.AppSettings["DiretorioFolderLog"].ToString() + printAtual;
            ss.SaveAsFile(fullPathSS, ScreenshotImageFormat.Png);
            ss.ToString();

            return fullPathSS;
        }

        public string gerarNumerosAleatorios()
        {

            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 8; i++)
            {
                r += random.Next(0, 9).ToString();
            }

            return r;
        }


        public bool verificarValorNaLista(IWebElement elemento, string valor)
        {
            wait.ElementToBeClickable(elemento);
            SelectElement dropdown = new SelectElement(elemento);
            IList<IWebElement> allOptions = dropdown.Options;

            bool found = false;

            foreach (IWebElement element in allOptions)
            {
                if (element.Text.Equals(valor))
                {
                    found = true;
                }
            }

            if (found.Equals(true))
                return true;

            else
                return false;

        }


        public void escolherValorAleatorioNaLista(IWebElement elemento, string nomePageObjects)
        {
            wait.ElementToBeClickable(elemento);

            Random random = new Random();
            SelectElement selector = new SelectElement(elemento);
            IList<IWebElement> options = selector.Options;
            int aux = options.Count;

            int r = random.Next(0, aux);
            new SelectElement(elemento).SelectByText(options[r].Text.Trim());
            Relatorio.test.Pass("Um valor aleatório foi escolhido para o elemento '" + nomePageObjects + "'");

        }

        public void escolherValorAleatorioNaLista(IWebElement elemento)
        {
            wait.ElementToBeClickable(elemento);

            Random random = new Random();
            SelectElement selector = new SelectElement(elemento);
            IList<IWebElement> options = selector.Options;
            int aux = options.Count;

            int r = random.Next(0, aux);
            new SelectElement(elemento).SelectByText(options[r].Text.Trim());
        }


        public string escolherERetornaValorAleatorioNaLista(IWebElement elemento)
        {
            wait.ElementToBeClickable(elemento);

            Random random = new Random();
            SelectElement selector = new SelectElement(elemento);
            IList<IWebElement> options = selector.Options;
            int aux = options.Count;

            int r = random.Next(0, aux);
            new SelectElement(elemento).SelectByText(options[r].Text.Trim());
            return options[r].Text.Trim();
        }


        public string escolherERetornaValorAleatorioNaLista(IWebElement elemento, string nomePageObjects)
        {
            wait.ElementToBeClickable(elemento);

            Random random = new Random();
            SelectElement selector = new SelectElement(elemento);
            IList<IWebElement> options = selector.Options;
            int aux = options.Count;

            int r = random.Next(0, aux);
            new SelectElement(elemento).SelectByText(options[r].Text.Trim());
            Relatorio.test.Pass("Um valor aleatório foi escolhido para o elemento '" + nomePageObjects + "'");
            return options[r].Text.Trim();
        }

    }//fim class
}//fim namespace
