using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using MantisBase2Saycao.Uteis.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.PageObjects
{
    public class LoginPageObjects
    {

        [FindsBy(How= How.Id, Using = "username")]
        public IWebElement InputLogin { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement InputSenha { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Entrar']")]
        public IWebElement BotaoEntrar { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='login-box']/div/div/h4")]
        public IWebElement TituloPagina { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div/div/div/div/div[4]/p")]
        public IWebElement MensagemErroLogin { get; set; }

        [FindsBy(How = How.Id, Using = "email-field")]
        public IWebElement InputEmail { get; set; }

        [FindsBy(How = How.LinkText, Using = "Perdeu a sua senha?")]
        public IWebElement BotaoPerdeuSenha { get; set; }


        Uteis.Uteis uteis= new Uteis.Uteis();
        WaitUntil wait = new WaitUntil(DriverFactory.INSTANCE);


        public LoginPageObjects()
        {
            PageFactory.InitElements(DriverFactory.INSTANCE, this);
                
        }


        #region Ações Métodos
        public void preencheLogin(string login) { uteis.preencheCampoInput(InputLogin, login, uteis.RetornaNomeVariavel(() => InputLogin)); }

        public void preencheSenha(string senha) { uteis.preencheCampoInput(InputSenha, senha, uteis.RetornaNomeVariavel(() => InputSenha)); }

        public void clicaBotaoEntrar() { uteis.clicaBotao(BotaoEntrar, uteis.RetornaNomeVariavel(() => BotaoEntrar)); }

        public void clicaBotaoPerdeuSenha() { uteis.clicaBotao(BotaoPerdeuSenha, uteis.RetornaNomeVariavel(() => BotaoPerdeuSenha)); }
        #endregion


        #region Verifica Métodos
        public void verificaAcessoLogin() { Assert.AreEqual("Entrar", TituloPagina.Text); }

        public void verificaAcessoSenha() { Assert.IsTrue(wait.ElementExists(By.Id("password"))); }
        
        public void verificaAcessoPerdeuSenha() { Assert.IsTrue(wait.ElementExists(By.Id("email-field"))); }
        #endregion


        public void acessarLogin()
        {
            acessarUrlLogin();
            verificaAcessoLogin();
            Relatorio.test.Info("Página Login acessada.");
        }

        public void acessarPerdeuSenha()
        {
            preencheLogin(ConfigurationManager.AppSettings["login"].ToString());
            clicaBotaoEntrar();

            verificaAcessoSenha();
            clicaBotaoPerdeuSenha();
            verificaAcessoPerdeuSenha();
            Relatorio.test.Info("Página Perdeu a Senha foi acessada.");
        }

        public void acessarUrlLogin(){DriverFactory.INSTANCE.Navigate().GoToUrl(ConfigurationManager.AppSettings["urlBase"].ToString());}

        public void realizaLogin()
        {
            preencheLogin(ConfigurationManager.AppSettings["login"].ToString());
            clicaBotaoEntrar();

            verificaAcessoSenha();
            preencheSenha(ConfigurationManager.AppSettings["senha"].ToString());
            clicaBotaoEntrar();
        }

        public void realizaLoginFalha()
        {
            preencheLogin(ConfigurationManager.AppSettings["login"].ToString());
            clicaBotaoEntrar();

            verificaAcessoSenha();
            preencheSenha("senha inválida");
            clicaBotaoEntrar();
        }

        


        public void preencheLoginViaJavaScript()
        {
            wait.ElementToBeClickable(InputLogin);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)DriverFactory.INSTANCE;
            jse.ExecuteScript("arguments[0].value='"+ ConfigurationManager.AppSettings["login"].ToString()+"';", InputLogin);
        }


        public void preencheSenhaViaJavaScript()
        {
            wait.ElementToBeClickable(InputSenha);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)DriverFactory.INSTANCE;
            jse.ExecuteScript("arguments[0].value='" + ConfigurationManager.AppSettings["senha"].ToString() + "';", InputSenha);
        }

        public void clicaBotaoEntrarViaJavaScript()
        {
            wait.ElementToBeClickable(BotaoEntrar);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)DriverFactory.INSTANCE;
            jse.ExecuteScript("arguments[0].click();", BotaoEntrar);

        }


    }//fim class
}//fim namespace
