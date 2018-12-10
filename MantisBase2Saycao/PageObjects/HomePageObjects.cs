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
    public class HomePageObjects
    {

        [FindsBy(How= How.XPath, Using = "//div[@id='navbar-container']/div/a/span")]
        public IWebElement TituloHome { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='assigned']/div/div[2]/div/a")]
        public IWebElement BotaoAtribuidosMim { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='unassigned']/div/div[2]/div/a")]
        public IWebElement BotaoNaoAtribuidos { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='reported']/div/div[2]/div/a")]
        public IWebElement BotaoRelatadosPorMim { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='resolved']/div/div[2]/div/a")]
        public IWebElement BotaoResolvidos { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='recent_mod']/div/div[2]/div/a")]
        public IWebElement BotaoModificadosRecentemente { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='monitored']/div/div[2]/div/a")]
        public IWebElement BotaoMonitoradosPorMim { get; set; }

        
        Uteis.Uteis uteis= new Uteis.Uteis();
        WaitUntil wait = new WaitUntil(DriverFactory.INSTANCE);


        public HomePageObjects()
        {
            PageFactory.InitElements(DriverFactory.INSTANCE, this);
        }


        #region Ações Métodos
        public void clicaBotaoAtribuidoMim() { uteis.clicaBotao(BotaoAtribuidosMim, uteis.RetornaNomeVariavel(() => BotaoAtribuidosMim)); }

        public void clicaBotaoNaoAtribuidos() { uteis.clicaBotao(BotaoNaoAtribuidos, uteis.RetornaNomeVariavel(() => BotaoNaoAtribuidos)); }

        public void clicaBotaoRelatadosPorMim() { uteis.clicaBotao(BotaoRelatadosPorMim, uteis.RetornaNomeVariavel(() => BotaoRelatadosPorMim)); }

        public void clicaBotaoResolvidos() { uteis.clicaBotao(BotaoResolvidos, uteis.RetornaNomeVariavel(() => BotaoResolvidos)); }

        public void clicaBotaoModificadosRecentemente() { uteis.clicaBotao(BotaoModificadosRecentemente, uteis.RetornaNomeVariavel(() => BotaoModificadosRecentemente)); }

        public void clicaBotaoMonitoradosPorMim() { uteis.clicaBotao(BotaoMonitoradosPorMim, uteis.RetornaNomeVariavel(() => BotaoMonitoradosPorMim)); }

        #endregion


        #region Verifica Métodos
        public void verificaAcessoTelaHome()
        {
            wait.ElementToBeClickable(BotaoNaoAtribuidos);
            Relatorio.test.Info("Página Home acessada.");
        }

        #endregion


        public void acessarAtribuidosMim() { clicaBotaoAtribuidoMim(); Relatorio.test.Info("Filtro Atribuídos a Mim acessado."); }

        public void acessarNaoAtribuidos() { clicaBotaoNaoAtribuidos(); Relatorio.test.Info("Filtro Não Atribuídos acessado."); }

        public void acessarRelatadosPorMim() { clicaBotaoRelatadosPorMim(); Relatorio.test.Info("Filtro Relatados por Mim acessado."); }

        public void acessarResolvidos() { clicaBotaoResolvidos(); Relatorio.test.Info("Filtro Resolvidos acessado."); }

        public void acessarModificadosRecentemente() { clicaBotaoModificadosRecentemente(); Relatorio.test.Info("Filtro Modificados Recentemente acessado."); }

        public void acessarMonitoradosPorMim() { clicaBotaoMonitoradosPorMim(); Relatorio.test.Info("Filtro Monitorados Por Mim acessado."); }



    }//fim class
}//fim namespace
