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
    public class GerenciarTests : WebDriver
    {



        [Test, Category("Gerenciar")]
        public void AcessarMenuGerenciar()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Acessar Menu Gerenciar");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            Assert.AreEqual("Informação do Site", gerenciar.TituloGerenciar.Text);
        }//fim void


        [Test, Category("Gerenciar - Usuarios")]
        public void AcessarSubMenuGerenciarUsuarios()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Acessar SubMenu Gerenciar Usuários");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarUsuarios();

            Assert.IsTrue(gerenciar.TituloGerenciarUsuarios.Text.Contains("Gerenciar Contas"));
        }//fim void


        [Test, Category("Gerenciar - Projetos")]
        public void AcessarSubMenuGerenciarProjetos()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Acessar SubMenu Gerenciar Projetos");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarProjetos();

            Assert.IsTrue(gerenciar.TituloGerenciarProjetos.Text.Contains("Projetos"));
        }//fim void


        [Test, Category("Gerenciar - Marcadores")]
        public void AcessarSubMenuGerenciarMarcadores()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Acessar SubMenu Gerenciar Marcadores");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarMarcadores();

            Assert.IsTrue(gerenciar.TituloGerenciarMarcadores.Text.Contains("Gerenciar Marcadores"));
        }//fim void


        [Test, Category("Gerenciar - Projetos")]
        public void CriarNovoProjeto()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Criar Novo Projeto");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarProjetos();
            gerenciar.verificaAcessoSubMenuGerenciarProjetos();
            string projeto = gerenciar.criarNovoProjetoAleatorio();

            gerenciar.verificaAcessoSubMenuGerenciarProjetos();

            Assert.IsTrue(gerenciar.verificarListagemProjeto(projeto));
        }//fim void


        [Test, Category("Gerenciar - Projetos")]
        public void AtualizarNomeProjeto()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Atualizar Nome Projeto");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarProjetos();
            gerenciar.verificaAcessoSubMenuGerenciarProjetos();
            string projeto = gerenciar.criarNovoProjetoAleatorio();

            gerenciar.verificaAcessoSubMenuGerenciarProjetos();
            gerenciar.selecionarProjetoCriado(projeto);
            gerenciar.verificaAcessoEditarProjeto();
            gerenciar.atualizarNomeProjeto();

            gerenciar.verificaAcessoSubMenuGerenciarProjetos();

            Assert.IsFalse(gerenciar.verificarListagemProjeto(projeto));
        }//fim void


        [Test, Category("Gerenciar - Projetos")]
        public void ApagarProjeto()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Apagar Projeto");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarProjetos();
            gerenciar.verificaAcessoSubMenuGerenciarProjetos();
            string projeto = gerenciar.criarNovoProjetoAleatorio();

            gerenciar.verificaAcessoSubMenuGerenciarProjetos();
            gerenciar.selecionarProjetoCriado(projeto);
            gerenciar.verificaAcessoEditarProjeto();
            gerenciar.apagarProjeto();

            gerenciar.verificaAcessoSubMenuGerenciarProjetos();

            Assert.IsFalse(gerenciar.verificarListagemProjeto(projeto));
        }//fim void



        [Test, Category("Gerenciar - Marcadores")]
        public void CriarMarcador()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Criar Marcador");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarMarcadores();
            gerenciar.verificaAcessoSubMenuGerenciarMarcadores();
            string marcador = gerenciar.criarNovoMarcadorAleatorio();

            gerenciar.verificaAcessoSubMenuGerenciarMarcadores();

            Assert.IsTrue(gerenciar.verificarListagemMarcador(marcador));
        }//fim void

        [Test, Category("Gerenciar - Marcadores")]
        public void ApagarMarcador()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Apagar Marcador");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarMarcadores();
            gerenciar.verificaAcessoSubMenuGerenciarMarcadores();
            string marcador = gerenciar.criarNovoMarcadorAleatorio();

            gerenciar.verificaAcessoSubMenuGerenciarMarcadores();
            Assert.IsTrue(gerenciar.verificarListagemMarcador(marcador));
            gerenciar.selecionarMarcadorCriado(marcador);

            gerenciar.apagarMarcador();
            gerenciar.verificaAcessoSubMenuGerenciarMarcadores();
            Assert.IsFalse(gerenciar.verificarListagemMarcador(marcador));
        }//fim void



        [Test, Category("Gerenciar - Marcadores")]
        public void AtualizarNomeMarcador()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Atualizar Nome Marcador");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarMarcadores();
            gerenciar.verificaAcessoSubMenuGerenciarMarcadores();
            string marcador = gerenciar.criarNovoMarcadorAleatorio();

            gerenciar.verificaAcessoSubMenuGerenciarMarcadores();
            Assert.IsTrue(gerenciar.verificarListagemMarcador(marcador));
            gerenciar.selecionarMarcadorCriado(marcador);

            marcador = gerenciar.atualizarNomeMarcador();
            gerenciar.verificaAcessoDetalhesMarcador();
            Assert.IsTrue(gerenciar.TextoDetalhes_NomeMarcador.Text.Contains(marcador));
        }//fim void

        [Test, Category("Gerenciar - Campos Personalizados")]
        public void CriarCampoPersonalizado()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Criar Campo Personalizado");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuCamposPersonalizados();
            gerenciar.verificaAcessoCamposPersonalizados();
            string campo = gerenciar.criarNovoCampoPersonalizado();

            gerenciar.acessarSubMenuCamposPersonalizados();
            Assert.IsTrue(gerenciar.verificarListagemCampoPersonalizado(campo));
        }//fim void






        [Test, Category("Gerenciar - Usuarios")]
        public void CriarNovoUsuario()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Criar Novo Usuario");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarUsuarios();
            gerenciar.verificaAcessoSubMenuGerenciarUsuarios();
            string usuario = gerenciar.criarNovoUsuarioAleatorio();

            gerenciar.verificaAcessoAlterarUsuario();
            gerenciar.acessarSubMenuGerenciarUsuarios();
            gerenciar.verificaAcessoSubMenuGerenciarUsuarios();

            Assert.IsTrue(gerenciar.verificarListagemUsuario(usuario));
        }//fim void


        [Test, Category("Gerenciar - Usuarios")]
        public void ApagarUsuario()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Apagar Novo Usuario");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarUsuarios();
            gerenciar.verificaAcessoSubMenuGerenciarUsuarios();
            string usuario = gerenciar.criarNovoUsuarioAleatorio();

            gerenciar.verificaAcessoAlterarUsuario();
            gerenciar.acessarSubMenuGerenciarUsuarios();
            gerenciar.verificaAcessoSubMenuGerenciarUsuarios();

            Assert.IsTrue(gerenciar.verificarListagemUsuario(usuario));

            gerenciar.selecionarUsuarioCriado(usuario);

            gerenciar.apagarUsuario();
            gerenciar.verificaAcessoSubMenuGerenciarUsuarios();
            Assert.IsFalse(gerenciar.verificarListagemUsuario(usuario));
        }//fim void



        [Test, Category("Gerenciar - Usuarios")]
        public void VerificaCampoNomeUsuarioObrigatorio()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Verifica Campo Nome Usuário Obrigatório");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarUsuarios();
            gerenciar.verificaAcessoSubMenuGerenciarUsuarios();
            gerenciar.clicarBotaoNovoUsuario();
            gerenciar.verificaAcessoTelaCriarNovoUsuario();

            gerenciar.preencherNomeVerdadeiroUsuarioAleatorio();
            gerenciar.preencherEmailUsuarioAleatorio();
            gerenciar.clicarBotaoCriarUsuario();
            
            Assert.IsTrue(gerenciar.verificaMensagemCampoNomeObrigatorio());
        }//fim void

        [Test, Category("Gerenciar - Usuarios")]
        public void verificaCampoEmailInvalido()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Verifica Campo Email inválido");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarUsuarios();
            gerenciar.verificaAcessoSubMenuGerenciarUsuarios();
            gerenciar.clicarBotaoNovoUsuario();
            gerenciar.verificaAcessoTelaCriarNovoUsuario();

            gerenciar.preencherNomeUsuario("Usuario");
            gerenciar.preencherNomeVerdadeiroUsuarioAleatorio();
            gerenciar.preencherEmailUsuario("invalido@");
            gerenciar.clicarBotaoCriarUsuario();

            Assert.IsTrue(gerenciar.verificaMensagemCampoEmailInvalido());
        }//fim void

        [Test, Category("Gerenciar - Gerenciar Configuração")]
        public void AcessarRelatorioDePermissoes()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Acessar Relatório De Permissões");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.acessarSubMenuGerenciarConfiguracao();

            gerenciar.clicarSubMenuRelatorioPermissoes();

            Assert.IsTrue(gerenciar.TituloRelatorioDePermissoes.Text.Contains("ANEXO(S)"));
        }//fim void


        [Test, Category("Gerenciar - Gerenciar Configuração")]
        public void AcessarRelatorioDeConfiguracao()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Acessar Relatório De Configuração");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.clicarSubMenuGerenciarConfiguracao();
            gerenciar.clicarSubMenuRelatorioDeConfiguracao();

            Assert.IsTrue(gerenciar.TituloRelatorioDeConfiguracao.Text.Contains("Criar Opção de Configuração"));
        }//fim void


        [Test, Category("Gerenciar - Gerenciar Configuração")]
        public void AcessarLimiaresFluxoTrabalho()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Acessar Limiares Fluxo de Trabalho");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.clicarSubMenuGerenciarConfiguracao();
            gerenciar.clicarSubLimiaresFluxoTrabalho();

            Assert.IsTrue(gerenciar.TituloLimiaresFluxoTrabalho.Text.Contains("TAREFAS"));
        }//fim void


        [Test, Category("Gerenciar - Gerenciar Configuração")]
        public void AcessarTransicoesFluxoTrabalho()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Acessar Transições de Fluxo de Trabalho");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.clicarSubMenuGerenciarConfiguracao();
            gerenciar.clicarSubMenuTransicoesFluxoTrabalho();

            Assert.IsTrue(gerenciar.TituloTransicoesFluxoTrabalho.Text.Contains("LIMIARES QUE AFETAM O FLUXO DE TRABALHO"));
        }//fim void

        [Test, Category("Gerenciar - Gerenciar Configuração")]
        public void AcessarNotificacoesEmail()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Acessar Notificações por E-Mail");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.clicarSubMenuGerenciarConfiguracao();
            gerenciar.clicarSubMenuNotificacoesEmail();

            Assert.IsTrue(gerenciar.TituloNotificacaoEmail.Text.Contains("NOTIFICAÇÃO VIA EMAIL"));
        }//fim void

        [Test, Category("Gerenciar - Gerenciar Configuração")]
        public void AcessaGerenciarColunas()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePageObjects home = new HomePageObjects();
            GerenciarPageObjects gerenciar = new GerenciarPageObjects();

            Relatorio.iniciarTeste("Acessar Notificações por E-Mail");

            login.acessarLogin();
            login.realizaLogin();

            home.verificaAcessoTelaHome();

            gerenciar.acessarMenuGerenciar();
            gerenciar.clicarSubMenuGerenciarConfiguracao();
            gerenciar.clicarSubMenuGerenciarColunas();

            Assert.IsTrue(gerenciar.TituloGerenciarColunas.Text.Contains("Gerenciar Colunas"));
        }//fim void

    }//fim class
}//fim namespace
