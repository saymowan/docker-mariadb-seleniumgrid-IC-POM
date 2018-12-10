using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.Uteis
{
    public class Relatorio
    {

        public static ExtentReports report;
        public static ExtentTest test;

        public string descrTeste;
        public string image;


        
        /// <summary>
        /// Método que inicia a captura de informações do teste
        /// </summary>
        /// <param name="descricaoTeste"></param>
        public void iniciarTeste(string descricaoTeste)
        {
            test = report.CreateTest(descricaoTeste);
            descrTeste = descricaoTeste;
            test.Info("Link utilizado no teste: " + ConfigurationManager.AppSettings["urlBase"].ToString());
            test.Info("Navegador utilizado no teste: " + ConfigurationManager.AppSettings["NavegadorDefault"].ToString());
        }

        /// <summary>
        /// Arquivo que realiza a criação do arquivo de Log
        /// </summary>
        public void criarArquivoLog()
        {
            if (report == null)
            {
                string filepath = ConfigurationManager.AppSettings["DiretorioFolderLog"].ToString() + ConfigurationManager.AppSettings["NomeRelatorio"].ToString();
                var htmlReporter = new ExtentHtmlReporter(filepath);
                report = new ExtentReports();
                report.AttachReporter(htmlReporter);

                gravarRelatorioKlov(ConfigurationManager.AppSettings["IndExecutaKlov"].ToString());
            }
        }//fim void


        public void gravarRelatorioKlov(string aux)
        {
            if (aux.Equals("true"))
            {
                //Objeto Klov
                var klovReporter = new KlovReporter();

                //Conexão DB Mongo
                klovReporter.InitMongoDbConnection(ConfigurationManager.AppSettings["servidorMongoDB"].ToString(), 27017);

                // Nome Projeto
                klovReporter.ProjectName = ConfigurationManager.AppSettings["nomeProjeto"].ToString();

                // Nome Report - pode indicar a branch e horário
                klovReporter.ReportName = ConfigurationManager.AppSettings["urlBranch"].ToString() + " " + DateTime.Now.ToString();

                // URL do servidor
                klovReporter.KlovUrl = "http://" + ConfigurationManager.AppSettings["servidorMongoDB"].ToString();

                report.AttachReporter(klovReporter);
            }//fim if

        }//fim void


        public void gravarLogPass(string mensagem)
        {
            test.Pass(mensagem);
        }


        public void gravarLogFail(string mensagem)
        {
            test.Fail(mensagem);
        }


        public void gravarLogInfo(string mensagem)
        {
            test.Info(mensagem);
        }



    }//fim class
}//fim namespace
