using System;
using System.Configuration;
using MantisBase2Saycao.PageObjects;
using MantisBase2Saycao.Uteis.Driver;
using NUnit.Framework;

namespace MantisBase2Saycao
{

    public class HomeTests : WebDriver
    {

        [Test, Category("Home")]
        public void AcessarAtribuidosMim()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();

            Relatorio.iniciarTeste("Acessar Atribuidos a Mim");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();
            home.acessarAtribuidosMim();

            tarefas.verificarAcessoVerTarefas();

            Assert.AreEqual(ConfigurationManager.AppSettings["login"].ToString(), 
                            tarefas.TextoAtribuidoA.Text);
        }//fim void


        [Test, Category("Home")]
        public void AcessarNaoAtribuidos()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();

            Relatorio.iniciarTeste("Acessar Não Atribuidos");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();
            home.acessarNaoAtribuidos();

            tarefas.verificarAcessoVerTarefas();

            Assert.AreEqual("nenhum", tarefas.TextoAtribuidoA.Text);
        }//fim void


        [Test, Category("Home")]
        public void AcessarRelatadosPorMim()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();

            Relatorio.iniciarTeste("Acessar Relatados por Mim");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();
            home.acessarRelatadosPorMim();

            tarefas.verificarAcessoVerTarefas();

            Assert.AreEqual(ConfigurationManager.AppSettings["login"].ToString(), 
                            tarefas.TextoRelator.Text);
        }//fim void


        [Test, Category("Home")]
        public void AcessarResolvidos()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();

            Relatorio.iniciarTeste("Acessar Resolvidos");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();
            home.acessarResolvidos();

            tarefas.verificarAcessoVerTarefas();

            Assert.AreEqual("resolvido",
                            tarefas.TextoStatus.Text);
        }//fim void


        [Test, Category("Home")]
        public void AcessarModificadosRecentemente()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();

            Relatorio.iniciarTeste("Acessar Modificados Recentemente");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();
            home.acessarModificadosRecentemente();

            tarefas.verificarAcessoVerTarefas();

            Assert.AreNotEqual("Não",
                            tarefas.TextoFiltrarDataUltimaAtualizacao.Text);
        }//fim void


        [Test, Category("Home")]
        public void AcessarMonitoradosPorMim()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();

            Relatorio.iniciarTeste("Acessar Monitorados por Mim");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();
            home.acessarMonitoradosPorMim();

            tarefas.verificarAcessoVerTarefas();

            Assert.AreNotEqual(ConfigurationManager.AppSettings["login"].ToString(),
                            tarefas.TextoMonitoradoPor.Text);
        }//fim void



    }
}
