using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using MantisBase2Saycao.Uteis.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.PageObjects
{
    public class RegistroMudancaPageObjects : DriverFactory
    {
        public RegistroMudancaPageObjects()
        {
            PageFactory.InitElements(DriverFactory.INSTANCE, this);
        }

        Uteis.Uteis uteis = new Uteis.Uteis();
        WaitUntil wait = new WaitUntil(DriverFactory.INSTANCE);


        [FindsBy(How = How.XPath, Using = "//div[@id='sidebar']/ul/li[4]/a/i")]
        public IWebElement MenuRegistroMudanças { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/p")]
        public IWebElement TituloRegistroMudanças { get; set; }


        #region Ações Métodos

        public void clicarMenuRegistroMudanças() { uteis.clicaBotao(MenuRegistroMudanças, uteis.RetornaNomeVariavel(() => MenuRegistroMudanças)); }

        #endregion

        #region Verifica Métodos
        public void verificaAcessoTelaRegistroMudanças()
        {
            wait.ElementToBeClickable(TituloRegistroMudanças);
            Relatorio.test.Info("Menu Registro de Mudanças acessado.");
        }

        #endregion


        public void acessarMenuRegistroMudanças()
        {
            clicarMenuRegistroMudanças();
            verificaAcessoTelaRegistroMudanças();
        }

    }//fim class
}//fim namespace
