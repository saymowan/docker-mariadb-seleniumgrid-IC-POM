using System;
using System.Collections.Generic;
using System.Configuration;
using MantisBase2Saycao.PageObjects;
using MantisBase2Saycao.Uteis.Driver;
using MantisBase2Saycao.Uteis.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MantisBase2Saycao
{

    public class VerTarefasTests : WebDriver
    {

        WaitUntil wait = new WaitUntil(DriverFactory.INSTANCE);

        [Test, Category("VerTarefas")]
        public void AcessarVerTarefas()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();

            Relatorio.iniciarTeste("Acessar Ver Tarefas");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            tarefas.acessarVerTarefas();
            tarefas.verificarAcessoVerTarefas();

            Assert.IsTrue(tarefas.TituloVerTarefas.Text.Contains("Visualizando Tarefas"));
        }//fim void



        [Test, Category("VerTarefas")]
        public void UtilizarFiltroAtribuido()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();

            Relatorio.iniciarTeste("Utilizar filtro atribuído");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            tarefas.acessarVerTarefas();
            tarefas.verificarAcessoVerTarefas();
            tarefas.filtrarAtribuido(ConfigurationManager.AppSettings["login"].ToString());

            Assert.AreEqual(ConfigurationManager.AppSettings["login"].ToString(),
                            tarefas.TextoAtribuidoA.Text);
        }//fim void


        [Test, Category("VerTarefas")]
        public void SalvarNovoFiltro()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();

            Relatorio.iniciarTeste("Salvar Novo Filtro");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            tarefas.acessarVerTarefas();
            tarefas.verificarAcessoVerTarefas();
            tarefas.filtrarAtribuido(ConfigurationManager.AppSettings["login"].ToString());

            string NovoFiltro = tarefas.gerarERetornarNovoFiltro();
            Assert.IsTrue(tarefas.verificarNovoFiltroCriado(NovoFiltro));
        }//fim void


        
        [Test, Category("CriarTarefas")]
        public void MoverTarefa()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();

            Relatorio.iniciarTeste("Mover tarefa");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            criar.acessarCriarTarefa();
            string resumo = criar.criarNovaTarefaAleatoriaRetornaResumo();

            tarefas.verificarAcessoVerTarefas();
            tarefas.resetarFiltro();

            tarefas.selecionarTarefaCriada(resumo);
            tarefas.selecionarAcaoMover();
            tarefas.moverTarefa();

            Assert.IsFalse(tarefas.verificarListagemResumo(resumo));
        }//fim void




        [Test, Category("CriarTarefas")]
        public void CopiarTarefa()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();

            Relatorio.iniciarTeste("Copiar tarefa");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            criar.acessarCriarTarefa();
            string resumo = criar.criarNovaTarefaAleatoriaRetornaResumo();

            tarefas.verificarAcessoVerTarefas();
            tarefas.resetarFiltro();

            tarefas.selecionarTarefaCriada(resumo);
            tarefas.selecionarAcaoCopiar();
            tarefas.verificarAcesoTelaCopiar();
            string novoProjeto = tarefas.selecionarProjetoRandomico();
            tarefas.copiarTarefa();

            tarefas.verificarAcessoVerTarefas();
            tarefas.acessarProjeto(novoProjeto);


            Assert.IsTrue(tarefas.verificarListagemResumo(resumo));
        }//fim void


        [Test, Category("CriarTarefas")]
        public void ApagarTarefa()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();

            Relatorio.iniciarTeste("Apagar tarefa");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            criar.acessarCriarTarefa();
            string resumo = criar.criarNovaTarefaAleatoriaRetornaResumo();

            tarefas.verificarAcessoVerTarefas();
            tarefas.resetarFiltro();

            tarefas.selecionarTarefaCriada(resumo);
            tarefas.selecionarAcaoApagar();
            tarefas.apagarTarefa();

            tarefas.verificarAcessoVerTarefas();
            Assert.IsFalse(tarefas.verificarListagemResumo(resumo));
        }//fim void



        [Test, Category("CriarTarefas")]
        public void AtribuirTarefa()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();

            Relatorio.iniciarTeste("Atribuir tarefa");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            criar.acessarCriarTarefa();
            string resumo = criar.criarNovaTarefaAleatoriaRetornaResumo();

            tarefas.verificarAcessoVerTarefas();
            tarefas.resetarFiltro();

            tarefas.selecionarTarefaCriada(resumo);
            tarefas.selecionarAcaoAtribuir();
            string usuario = tarefas.atribuirTarefa();

            tarefas.verificarAcessoVerTarefas();
            tarefas.resetarFiltro();

            Assert.IsTrue(tarefas.verificarListagemTarefaAtribuicao(resumo,usuario));
        }//fim void


        [Test, Category("CriarTarefas")]
        public void ResolverTarefa()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();

            Relatorio.iniciarTeste("Resolver tarefa");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            criar.acessarCriarTarefa();
            string resumo = criar.criarNovaTarefaAleatoriaRetornaResumo();

            tarefas.verificarAcessoVerTarefas();
            tarefas.resetarFiltro();

            tarefas.selecionarTarefaCriada(resumo);
            tarefas.selecionarAcaoResolver();
            tarefas.resolverTarefa();

            tarefas.verificarAcessoVerTarefas();
            tarefas.resetarFiltro();

            Assert.IsTrue(tarefas.verificarListagemTarefaAtribuicao(resumo, "resolvido "));
        }//fim void



        [Test, Category("CriarTarefas")]
        public void AtualizarPrioridadeTarefa()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();

            Relatorio.iniciarTeste("Atualizar prioridade tarefa");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            criar.acessarCriarTarefa();
            string resumo = criar.criarNovaTarefaAleatoriaRetornaResumo();

            tarefas.verificarAcessoVerTarefas();
            tarefas.resetarFiltro();

            tarefas.selecionarTarefaCriada(resumo);
            tarefas.selecionarAcaoAtualizarPrioridade();
            tarefas.atualizarPrioridade_Normal();

            tarefas.verificarAcessoVerTarefas();
            tarefas.resetarFiltro();

            tarefas.acessarTarefaListagem(resumo);
            tarefas.verificarAcessoDetalhesTarefas();

            Assert.AreEqual("normal", tarefas.TextoPrioridadeDetalhe.Text);
        }//fim void


    }
}
