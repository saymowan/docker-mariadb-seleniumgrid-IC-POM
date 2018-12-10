using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using MantisBase2Saycao.Uteis.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;

namespace MantisBase2Saycao.PageObjects
{
    public class MinhaContaPageObjects : DriverFactory
    {

        public MinhaContaPageObjects()
        {
            PageFactory.InitElements(INSTANCE, this);
        }

        Uteis.Uteis uteis = new Uteis.Uteis();
        WaitUntil wait = new WaitUntil(INSTANCE);

        
        [FindsBy(How = How.XPath, Using = "//div[@id='navbar-container']/div[2]/ul/li[2]/a/span")]
        public IWebElement MenuSuperiorAdministarConta { get; set; }

        [FindsBy(How = How.LinkText, Using = "Minha Conta")]
        public IWebElement SubMenuMinhaConta { get; set; }


        #region Alterar POM
        [FindsBy(How = How.XPath, Using = "//form[@id='account-update-form']/div/div/h4")]
        public IWebElement TituloMinhaConta { get; set; }

        [FindsBy(How = How.Id, Using = "email-field")]
        public IWebElement TextoEmail { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@value='Atualizar Usuário']")]
        public IWebElement BotaoAtualizarUsuario { get; set; }


        #endregion


        #region Ações Métodos
        public void clicarBotaoMenuSuperiorAdministrarConta() { uteis.clicaBotao(MenuSuperiorAdministarConta, uteis.RetornaNomeVariavel(() => MenuSuperiorAdministarConta)); }
        public void clicarBotaoSubMenuMinhaConta() { uteis.clicaBotao(SubMenuMinhaConta, uteis.RetornaNomeVariavel(() => SubMenuMinhaConta)); }
        public void clicarBotaoAtualizarUsuario() { uteis.clicaBotao(BotaoAtualizarUsuario, uteis.RetornaNomeVariavel(() => BotaoAtualizarUsuario)); }


        public void preencherEmailAleatorio() { uteis.preencheCampoInput(TextoEmail, "email_" + uteis.gerarNumerosAleatorios() + "@gmail.com", uteis.RetornaNomeVariavel(() => TextoEmail)); }
        public void preencherEmail(string valor) { uteis.preencheCampoInput(TextoEmail, valor, uteis.RetornaNomeVariavel(() => TextoEmail)); }


        #endregion



        #region Verifica Métodos
        public void verificaAcessoTelaMinhaConta()
        {
            wait.ElementToBeClickable(TituloMinhaConta);
            Relatorio.test.Info("Página Minha Conta acessada.");
        }



        #endregion



        #region Acessar Métodos
        public void acessarMinhaConta()
        {
            INSTANCE.Navigate().GoToUrl(ConfigurationManager.AppSettings["urlBase"].ToString()+"/account_page.php");
        }

        public string AtualizarEmailAleatorio()
        {

            string retorno = "email_" + uteis.gerarNumerosAleatorios() + "@gmail.com";
            preencherEmail(retorno);
            clicarBotaoAtualizarUsuario();
            return retorno;
        }
        #endregion

    }//fim class
}//fim namespace
