using MantisBase2Saycao.PageObjects;
using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.Tests
{
    public class CriarTarefaTests : WebDriver
    {



        [Test, Category("CriarTarefas")]
        public void CriarNovaTarefa()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();

            Relatorio.iniciarTeste("Criar tarefa");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            criar.acessarCriarTarefa();
            criar.criarNovaTarefaAleatoria();

            Assert.AreEqual("Operação realizada com sucesso.", criar.MensagemOperacao.Text);
        }//fim void

        [Test, Category("CriarTarefas")]
        public void VerificaCampoResumoObrigatorio()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();

            Relatorio.iniciarTeste("Verifica campo Resumo obrigatório.");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            criar.acessarCriarTarefa();
            criar.preencherDescricaoAleatoria();
            criar.clicarCriarNovaTarefa();

            Assert.AreEqual("Preencha este campo.", criar.TextoResumo.GetAttribute("validationMessage"));       
        }//fim void

        [Test, Category("CriarTarefas")]
        public void VerificaCampoDescricaoObrigatorio()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();

            Relatorio.iniciarTeste("Verifica campo Descrição obrigatório.");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            criar.acessarCriarTarefa();
            criar.preencherResumoAleatoria();
            criar.clicarCriarNovaTarefa();

            Assert.AreEqual("Preencha este campo.", criar.TextoDescricao.GetAttribute("validationMessage"));
        }//fim void


    }//fim class
}//fim namespace
