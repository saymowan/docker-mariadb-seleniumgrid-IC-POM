using MantisBase2Saycao.PageObjects;
using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using MantisBase2Saycao.Uteis.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;

namespace MantisBase2Saycao.Tests
{
    public class DataDrivenTests : WebDriver
    {

        [Category("Data Driven Testing"),
          TestCaseSource("ConfiguracaoTarefa")
        ]
        public void CriarTarefasDinamicas(string frequencia,
                                          string gravidade
                                          )
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();

            Relatorio.iniciarTeste("Criar tarefa dinâmica (frequência: "+ frequencia + ", gravidade: " + gravidade + ")");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            criar.acessarCriarTarefa();
            string resumo = criar.criarNovaTarefaAleatoria(frequencia, gravidade);

            tarefas.verificarAcessoVerTarefas();
            tarefas.resetarFiltro();

            Assert.IsTrue(tarefas.verificarListagemResumo(resumo));
        }//fim void



        public static List<TestCaseData> ConfiguracaoTarefa
        {
            get
            {
                var testCases = new List<TestCaseData>();
                string[] split = { "" };
                using (var fs = File.OpenRead(@"C:\Repositorio de Projetos\MantisBase2Saycao\tarefasDinamicas.csv"))
                //using (var fs = File.OpenRead(SeleniumComum.SeleniumUteis.getPathDataDrivenFiles()))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;

                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            split = line.Split(new char[] { ',' }, StringSplitOptions.None);
                            string frequencia = split[0].Trim();
                            string gravidade = split[1].Trim();

                            if(!frequencia.Equals("Frequência"))
                            {
                                var testCase = new TestCaseData(frequencia, gravidade);
                                testCases.Add(testCase);
                            }


                        }
                    }
                }
                return testCases;
            }
        }



    }//fim class
}//fim namespace
