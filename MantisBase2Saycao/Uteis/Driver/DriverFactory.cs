using OpenQA.Selenium;
using System.Configuration;
using System.IO;

namespace MantisBase2Saycao.Uteis.Driver
{
    public class DriverFactory
    {

        public static IWebDriver INSTANCE { get; set; } = null;

        public static void CreateInstance()
        {

            string navegador = ConfigurationManager.AppSettings["NavegadorDefault"].ToString();
            string local = ConfigurationManager.AppSettings["Local"].ToString();

            if (INSTANCE == null)
            {
                switch (local)
                {
                    case ("true"): //Execução Local
                        INSTANCE = Browser.ChromeLocal();
                        INSTANCE.Manage().Window.Maximize();
                        break;

                    case ("false"): //Execução Grid
                        Browser.Remote(navegador);
                        //INSTANCE.Manage().Window.Maximize();
                        break;
                }



            }
        }

        public static void QuitInstance()
        {
            Relatorio.report.Flush();
            INSTANCE.Quit();
            INSTANCE = null;
        }

        /// <summary>
        /// Método que realiza a criação do diretório do relatório e caso exista, exclui os arquivos
        /// </summary>
        public static void VerifyAndCreatePatchReport()
        {
            bool exists = System.IO.Directory.Exists(ConfigurationManager.AppSettings["DiretorioFolderLog"].ToString());

            if (!exists)
                System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["DiretorioFolderLog"].ToString());


            //Exclui arquivos do diretório
            //System.IO.DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["DiretorioFolderLog"].ToString());

            //foreach (FileInfo file in di.GetFiles())
            //{
            //    file.Delete();
            //}
            //foreach (DirectoryInfo dir in di.GetDirectories())
            //{
            //    dir.Delete(true);
            //}




        }



    }//fim class
}//fim namespace
