using System;
using MantisBase2Saycao.PageObjects;
using MantisBase2Saycao.Uteis.Driver;
using NUnit.Framework;

namespace MantisBase2Saycao
{

    public class LoginTests : WebDriver
    {

        [Test, Category("Login")]
        public void LoginSucesso()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();

            Relatorio.iniciarTeste("Realiza login sucesso");

            login.acessarLogin();
            login.realizaLogin();
            Assert.AreEqual("MantisBT",home.TituloHome.Text);
        }//fim void


        [Test, Category("Login")]
        public void LoginFalha()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();

            Relatorio.iniciarTeste("Realiza login falha");

            login.acessarLogin();
            login.realizaLoginFalha();
            Assert.AreEqual("Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.", login.MensagemErroLogin.Text);
        }//fim void


        [Test, Category("Login")]
        public void RecuperarSenha()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();

            Relatorio.iniciarTeste("Recupera senha");

            login.acessarLogin();
            login.acessarPerdeuSenha();
            Assert.AreEqual("Reajuste de Senha", login.TituloPagina.Text);
        }//fim void



    }
}
