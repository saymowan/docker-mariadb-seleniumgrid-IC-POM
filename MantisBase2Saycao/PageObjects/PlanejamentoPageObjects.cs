using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using MantisBase2Saycao.Uteis.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MantisBase2Saycao.PageObjects
{
    public class PlanejamentoPageObjects : DriverFactory
    {

        public PlanejamentoPageObjects()
        {
            PageFactory.InitElements(DriverFactory.INSTANCE, this);
        }

        Uteis.Uteis uteis = new Uteis.Uteis();
        WaitUntil wait = new WaitUntil(DriverFactory.INSTANCE);


        [FindsBy(How = How.XPath, Using = "//div[@id='sidebar']/ul/li[5]/a/i")]
        public IWebElement MenuPlanejamento { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/p")]
        public IWebElement TituloPlanejamento { get; set; }


        #region Ações Métodos

        public void clicarMenuPlanejamento() { uteis.clicaBotao(MenuPlanejamento, uteis.RetornaNomeVariavel(() => MenuPlanejamento)); }

        #endregion

        #region Verifica Métodos
        public void verificaAcessoTelaPlanejamento()
        {
            wait.ElementToBeClickable(TituloPlanejamento);
            Relatorio.test.Info("Menu Planejamento acessado.");
        }

        #endregion


        public void acessarMenuPlanejamento()
        {
            clicarMenuPlanejamento();
            verificaAcessoTelaPlanejamento();
        }
    }
}
