using MantisBase2Saycao.PageObjects;
using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.Tests
{
    public class PlanejamentoTests : WebDriver
    {
        [Test, Category("Planejamento")]
        public void AcessarMenuPlanejamento()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            PlanejamentoPageObjects planejamento = new PlanejamentoPageObjects();

            Relatorio.iniciarTeste("Acessar Menu Planejamento");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            planejamento.acessarMenuPlanejamento();
            planejamento.verificaAcessoTelaPlanejamento();
            Assert.AreEqual("Nenhum planejamento disponível. Apenas tarefas com a versão indicada aparecerão no planejamento.", planejamento.TituloPlanejamento.Text);
        }//fim void
    }
}
