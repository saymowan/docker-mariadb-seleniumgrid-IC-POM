using MantisBase2Saycao.PageObjects;
using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using MantisBase2Saycao.Uteis.Helper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.Tests
{
    public class DataBaseTests : WebDriver
    {

        [Test, Category("Banco de Dados")]
        public void VerificaCargaDBTarefas()
        {
            ConexaoBD conexao = new ConexaoBD();
            List<string> optionList = conexao.cargaTarefas();

            string id_project = optionList[0];
            string tarefa1 = optionList[1];
            string tarefa2 = optionList[2];
            string tarefa3 = optionList[3];

            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();


            Relatorio.iniciarTeste("Carga DB Tarefas e Projeto");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            tarefas.acessarVerTarefas();
            tarefas.verificarAcessoVerTarefas();

            tarefas.clicarFiltroAtualizado();
            tarefas.verificarAcessoVerTarefas();
            tarefas.clicarFiltroAtualizado();
            tarefas.verificarAcessoVerTarefas();

            Assert.IsTrue(tarefas.verificarListagemResumo(tarefa1));
            Assert.IsTrue(tarefas.verificarListagemResumo(tarefa2));
            Assert.IsTrue(tarefas.verificarListagemResumo(tarefa3));
        }

    }
}
