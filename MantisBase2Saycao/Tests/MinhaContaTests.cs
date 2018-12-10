using MantisBase2Saycao.PageObjects;
using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using NUnit.Framework;
using System;

namespace MantisBase2Saycao.Tests
{
    public class MinhaContaTests : WebDriver
    {


        [Test, Category("Minha Conta")]
        public void AcessarMinhaConta()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            MinhaContaPageObjects conta = new MinhaContaPageObjects();

            Relatorio.iniciarTeste("Acessar Página Minha Conta");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            conta.acessarMinhaConta();
            conta.verificaAcessoTelaMinhaConta();

            Assert.IsTrue(conta.TituloMinhaConta.Text.Contains("Alterar Conta"));
        }//fim void


        [Test, Category("Minha Conta")]
        public void AlterarEmailMinhaConta()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            MinhaContaPageObjects conta = new MinhaContaPageObjects();
            
            Relatorio.iniciarTeste("Acessar Página Minha Conta");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            conta.acessarMinhaConta();
            string novoEmail = conta.AtualizarEmailAleatorio();

            home.verificaAcessoTelaHome();
        }//fim void



    }//fim class
}//fim namespace
