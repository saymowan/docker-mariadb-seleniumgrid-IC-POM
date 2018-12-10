using MantisBase2Saycao.PageObjects;
using MantisBase2Saycao.Uteis.Driver;
using NUnit.Framework;


namespace MantisBase2Saycao.Tests
{
    class JavaScriptTests : WebDriver
    {

        [Test, Category("JavaScript")]
        public void LoginViaJavaScript()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            VerTarefasPageObjects tarefas = new VerTarefasPageObjects();
            CriarTarefaPageObjects criar = new CriarTarefaPageObjects();

            Relatorio.iniciarTeste("Realizar login via javascript");

            login.acessarLogin();
            login.preencheLoginViaJavaScript();
            login.clicaBotaoEntrarViaJavaScript();

            login.verificaAcessoSenha();
            login.preencheSenhaViaJavaScript();
            login.clicaBotaoEntrarViaJavaScript();

            home.verificaAcessoTelaHome();
            Assert.AreEqual("MantisBT", home.TituloHome.Text);
        }//fim void



    }
}
