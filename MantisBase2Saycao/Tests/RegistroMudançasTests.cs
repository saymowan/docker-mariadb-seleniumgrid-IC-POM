using MantisBase2Saycao.PageObjects;
using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.Tests
{
    public class RegistroMudançasTests : WebDriver
    {

        [Test, Category("Registro de Mudanças")]
        public void AcessarMenuRegistroMudanças()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            RegistroMudancaPageObjects registro = new RegistroMudancaPageObjects();

            Relatorio.iniciarTeste("Acessar Menu Registro de Mudanças");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            registro.acessarMenuRegistroMudanças();
            registro.verificaAcessoTelaRegistroMudanças();
            Assert.AreEqual("Nenhum registro de mudança disponível. Apenas tarefas que indiquem a versão na qual foi resolvida aparecerão nos registros de mudança.", registro.TituloRegistroMudanças.Text);
        }//fim void



    }//fim class
}//fim namespace
