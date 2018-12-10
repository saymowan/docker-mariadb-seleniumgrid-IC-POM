using AventStack.ExtentReports;
using MantisBase2Saycao.Uteis.Helper;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.Uteis.Driver
{
    public class WebDriver
    {

        public static Relatorio Relatorio { get; protected set; }
                
        public WebDriver()
        {
            Relatorio = new Relatorio();
        }

        Uteis uteis = new Uteis();

        [SetUp]
        public void SetUp()
        {
            ConexaoBD conexao = new ConexaoBD();
            conexao.criarProjetoCarga();
            Relatorio.criarArquivoLog();
            DriverFactory.CreateInstance();
        }


        [TearDown]
        public void TearDown()
        {
            VerificaStatusTeste();
            DriverFactory.QuitInstance();
        }


        [OneTimeSetUp]
        public void SetUpOneTime()
        {
            DriverFactory.VerifyAndCreatePatchReport();
        }




        public void VerificaStatusTeste()
        {

            if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Success))
            {
                logSucessoEAddPrint(true);
            }

            else if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Failure))
            {
                logSucessoEAddPrint(false);
            }

            else if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Error))
            {
                Relatorio.test.Fail("Não foi possível finalizar o teste.");
                logSucessoEAddPrint(false);
            }

            else if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Inconclusive))
            {
                Relatorio.test.Pass("Não foi possível finalizar o teste.");
            }



        }




        public void logSucessoEAddPrint(bool aux) { 

            if (aux == true)
            {
                var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(uteis.gerarPrintScreen()).Build();
                Relatorio.test.Pass("Teste executado com sucesso!", mediaModel);
            }

            else
            {
                var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(uteis.gerarPrintScreen()).Build();
                Relatorio.test.Fail("Teste executado com falha!", mediaModel);
                Relatorio.test.Fail("Teste com falha, favor verificar o resultado NUnit: ");
                Relatorio.test.Fail(NUnit.Framework.TestContext.CurrentContext.Result.Message.ToString());
                Relatorio.test.Fail("Teste com falha, favor verificar o stacktrace: ");
                Relatorio.test.Fail(NUnit.Framework.TestContext.CurrentContext.Result.StackTrace.ToString());
            } // fim else
        }//fim void


        


    }//fim class
}//fim namespace
