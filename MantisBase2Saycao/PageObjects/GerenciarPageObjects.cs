using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using MantisBase2Saycao.Uteis.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.PageObjects
{
    public class GerenciarPageObjects : DriverFactory
    {

        public GerenciarPageObjects()
        {
            PageFactory.InitElements(DriverFactory.INSTANCE, this);
        }

        Uteis.Uteis uteis = new Uteis.Uteis();
        WaitUntil wait = new WaitUntil(DriverFactory.INSTANCE);


        #region Mapeamento boladão
        [FindsBy(How = How.XPath, Using = "//div[@id='sidebar']/ul/li[7]/a/i")]
        public IWebElement MenuGerenciar { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div/h4")]
        public IWebElement TituloGerenciar { get; set; }
        #endregion


        #region SubMenuUsuarios
        [FindsBy(How = How.LinkText, Using = "Gerenciar Usuários")]
        public IWebElement SubMenuGerenciarUsuarios { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[4]/div/h4")]
        public IWebElement TituloGerenciarUsuarios { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement BotaoCriarNovoUsuario { get; set; }

        [FindsBy(How = How.Id, Using = "user-username")]
        public IWebElement TextoNomeUsuario { get; set; }

        [FindsBy(How = How.Id, Using = "user-realname")]
        public IWebElement TextoNomeVerdadeiroUsuario { get; set; }

        [FindsBy(How = How.Id, Using = "email-field")]
        public IWebElement TextoEmailUsuario { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Criar Usuário']")]
        public IWebElement BotaoCriarUsuario { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='edit-user-form']/div/div/h4")]
        public IWebElement TituloAlterarUsuario { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Atualizar Usuário']")]
        public IWebElement BotaoAtualizarrUsuario { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Apagar Usuário']")]
        public IWebElement BotaoApagarUsuario { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/p")]
        public IWebElement MensagemApagarUsuario { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Apagar Conta']")]
        public IWebElement BotaoConfirmarExclusaoUsuario { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='manage-user-create-form']/div/div/h4")]
        public IWebElement TituloCriarNovoUsuario { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/p[2]")]
        public IWebElement MensagemValidacaoNovoUsuario { get; set; }

        #endregion


        #region SubMenuProjetos
        [FindsBy(How = How.LinkText, Using = "Gerenciar Projetos")]
        public IWebElement SubMenuGerenciarProjetos { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div/h4")]
        public IWebElement TituloGerenciarProjetos { get; set; }

        [FindsBy(How = How.Id, Using = "project-name")]
        public IWebElement TextoNomeProjeto { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement BotaoCriarNovoProjeto { get; set; }

        [FindsBy(How = How.Id, Using = "project-description")]
        public IWebElement TextoDescricaoProjeto { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Adicionar projeto']")]
        public IWebElement BotaoAdicionarProjeto { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='manage-proj-update-form']/div/div/h4")]
        public IWebElement TituloEditarProjeto { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Atualizar Projeto']")]
        public IWebElement BotaoAtualizarProjeto { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Apagar Projeto']")]
        public IWebElement BotaoApagarProjeto { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/p")]
        public IWebElement MensagemApagarProjeto { get; set; }

        #endregion


        #region SubMenuMarcadores
        [FindsBy(How = How.LinkText, Using = "Gerenciar Marcadores")]
        public IWebElement SubMenuGerenciarMarcadores { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[4]/div/h4")]
        public IWebElement TituloGerenciarMarcadores { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Criar Marcador')]")]
        public IWebElement BotaoCriarMarcador { get; set; }

        [FindsBy(How = How.Id, Using = "tag-name")]
        public IWebElement TextoNomeMarcador { get; set; }

        [FindsBy(How = How.Id, Using = "tag-description")]
        public IWebElement TextoDescricaoMarcador { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='config_set']")]
        public IWebElement BotaoConfirmarNovoMarcador { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div/h4")]
        public IWebElement TituloDetalhesMarcador { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Apagar Marcador']")]
        public IWebElement BotaoApagarMarcador { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Atualizar Marcador']")]
        public IWebElement BotaoAtualizarMarcador { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/p")]
        public IWebElement TituloConfirmarApagarMarcador { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr[2]/td[2]")]
        public IWebElement TextoDetalhes_NomeMarcador { get; set; }
        #endregion

        #region SubMenu Gerenciar Configuração
        [FindsBy(How = How.LinkText, Using = "Gerenciar Configuração")]
        public IWebElement SubMenuGerenciarConfiguracao { get; set; }


        [FindsBy(How = How.LinkText, Using = "Relatório de Permissões")]
        public IWebElement SubMenuRelatorioDePermissoes { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div[3]/div[2]/div/h4")]
        public IWebElement TituloRelatorioDePermissoes { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='config_set_form']/div/div/h4")]
        public IWebElement TituloRelatorioDeConfiguracao { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='mail_config_action']/div[2]/div/h4")]
        public IWebElement TituloLimiaresFluxoTrabalho { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='workflow_config_action']/div/div[3]/div/h4")]
        public IWebElement TituloTransicoesFluxoTrabalho { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='mail_config_action']/div[3]/div/h4")]
        public IWebElement TituloNotificacaoEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div[3]/div[2]/div/h4")]
        public IWebElement TituloGerenciarColunas { get; set; }


        [FindsBy(How = How.LinkText, Using = "Relatório de Configuração")]
        public IWebElement SubMenuRelatorioDeConfiguração { get; set; }

        [FindsBy(How = How.LinkText, Using = "Limiares do Fluxo de Trabalho")]
        public IWebElement SubMenuLimiaresFluxoTrabalho { get; set; }

        [FindsBy(How = How.LinkText, Using = "Transições de Fluxo de Trabalho")]
        public IWebElement SubMenuTransicoesFluxoTrabalho { get; set; }

        [FindsBy(How = How.LinkText, Using = "Notificações por E-Mail")]
        public IWebElement SubMenuNotificaoEmail { get; set; }

        [FindsBy(How = How.LinkText, Using = "Gerenciar Colunas")]
        public IWebElement SubMenuGerenicarColunas { get; set; }








        #endregion





        #region
        [FindsBy(How= How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div/h4")]
        public IWebElement TituloCamposPersonalizados { get; set; }

        [FindsBy(How = How.LinkText, Using = "Gerenciar Campos Personalizados")]
        public IWebElement BotaoCamposPersonalizados { get; set; }

        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement TextoNomeCampoPersonalizado { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Novo Campo Personalizado']")]
        public IWebElement BotaoNovoCampoPersonalizado { get; set; }

        #endregion



        #region Ações Métodos
        public void clicarMenuGerenciar() { uteis.clicaBotao(MenuGerenciar, uteis.RetornaNomeVariavel(() => MenuGerenciar)); }
        public void clicarSubMenuGerenciarUsuarios() { uteis.clicaBotao(SubMenuGerenciarUsuarios, uteis.RetornaNomeVariavel(() => SubMenuGerenciarUsuarios)); }
        public void clicarSubMenuGerenciarProjetos() { uteis.clicaBotao(SubMenuGerenciarProjetos, uteis.RetornaNomeVariavel(() => SubMenuGerenciarProjetos)); }
        public void clicarSubMenuGerenciarMarcadores() { uteis.clicaBotao(SubMenuGerenciarMarcadores, uteis.RetornaNomeVariavel(() => SubMenuGerenciarMarcadores)); }
        public void clicarSubMenuGerenciarConfiguracoes() { uteis.clicaBotao(SubMenuGerenciarConfiguracao, uteis.RetornaNomeVariavel(() => SubMenuGerenciarConfiguracao)); }
        
        //Projetos
        public void preencherNomeProjetoAleatorio() { uteis.preencheCampoInput(TextoNomeProjeto, "Projeto - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoNomeProjeto)); }
        public void preencherNomeProjeto(string valor) { uteis.preencheCampoInput(TextoNomeProjeto, valor, uteis.RetornaNomeVariavel(() => TextoNomeProjeto)); }

        public void preencherDescricaoProjetoAleatorio() { uteis.preencheCampoInput(TextoDescricaoProjeto, "Descrição Projeto - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoDescricaoProjeto)); }
        public void preencherDescricaoProjeto(string valor) { uteis.preencheCampoInput(TextoDescricaoProjeto, valor, uteis.RetornaNomeVariavel(() => TextoDescricaoProjeto)); }

        public void clicarBotaoAdicionarProjeto() { uteis.clicaBotao(BotaoAdicionarProjeto, uteis.RetornaNomeVariavel(() => BotaoAdicionarProjeto)); }
        public void clicarBotaoCriarNovoProjeto() { uteis.clicaBotao(BotaoCriarNovoProjeto, uteis.RetornaNomeVariavel(() => BotaoCriarNovoProjeto)); }
        public void clicarAtualizarProjeto() { uteis.clicaBotao(BotaoAtualizarProjeto, uteis.RetornaNomeVariavel(() => BotaoAtualizarProjeto)); }
        public void clicarApagarProjeto() { uteis.clicaBotao(BotaoApagarProjeto, uteis.RetornaNomeVariavel(() => BotaoApagarProjeto)); }

        //Marcadores
        public void clicarBotaoAtualizarMarcador() { uteis.clicaBotao(BotaoAtualizarMarcador, uteis.RetornaNomeVariavel(() => BotaoAtualizarMarcador)); }
        public void clicarBotaoApagarMarcador() { uteis.clicaBotao(BotaoApagarMarcador, uteis.RetornaNomeVariavel(() => BotaoApagarMarcador)); }
        public void clicarBotaoCriarMarcador() { uteis.clicaBotao(BotaoCriarMarcador, uteis.RetornaNomeVariavel(() => BotaoCriarMarcador)); }
        public void preencherNomeMarcador(string valor) { uteis.preencheCampoInput(TextoNomeMarcador, valor, uteis.RetornaNomeVariavel(() => TextoNomeMarcador)); }
        public void preencherNomeMarcadorAleatorio() { uteis.preencheCampoInput(TextoNomeMarcador, "Marcador - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoNomeMarcador)); }
        public void preencherDescricaoMarcadorAleatorio() { uteis.preencheCampoInput(TextoDescricaoMarcador, "Descrição Marcador - "+uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoDescricaoMarcador)); }
        public void clicarBotaoConfirmarNovoMarcador() { uteis.clicaBotao(BotaoConfirmarNovoMarcador, uteis.RetornaNomeVariavel(() => BotaoConfirmarNovoMarcador)); }

        //Campos Personalizados
        public void clicarBotaoNovoCampoPersonalizado() { uteis.clicaBotao(BotaoNovoCampoPersonalizado, uteis.RetornaNomeVariavel(() => BotaoNovoCampoPersonalizado)); }
        public void clicarSubMenuCamposPersonalizados() { uteis.clicaBotao(BotaoCamposPersonalizados, uteis.RetornaNomeVariavel(() => BotaoCamposPersonalizados)); }
        public void preencherNomePersonalizado(string valor) { uteis.preencheCampoInput(TextoNomeCampoPersonalizado, valor, uteis.RetornaNomeVariavel(() => TextoNomeCampoPersonalizado)); }
        public void preencherNomePersonalizadoAleatorio() { uteis.preencheCampoInput(TextoNomeCampoPersonalizado, "Nome Campo Personalizado - "+uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoNomeCampoPersonalizado)); }

        //Usuarios
        public void clicarBotaoNovoUsuario() { uteis.clicaBotao(BotaoCriarNovoUsuario, uteis.RetornaNomeVariavel(() => BotaoCriarNovoUsuario)); }
        public void preencherNomeUsuarioAleatorio() { uteis.preencheCampoInput(TextoNomeUsuario, "Usuário - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoNomeUsuario)); }
        public void preencherNomeUsuario(string valor) { uteis.preencheCampoInput(TextoNomeUsuario, valor, uteis.RetornaNomeVariavel(() => TextoNomeUsuario)); }

        public void preencherNomeVerdadeiroUsuarioAleatorio() { uteis.preencheCampoInput(TextoNomeVerdadeiroUsuario, "Nome Verdadeiro - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoNomeVerdadeiroUsuario)); }
        public void preencherNomeVerdadeiro(string valor) { uteis.preencheCampoInput(TextoNomeVerdadeiroUsuario, valor, uteis.RetornaNomeVariavel(() => TextoNomeVerdadeiroUsuario)); }

        public void preencherEmailUsuarioAleatorio() { uteis.preencheCampoInput(TextoEmailUsuario, "teste_" + uteis.gerarNumerosAleatorios()+"@gmail.com", uteis.RetornaNomeVariavel(() => TextoEmailUsuario)); }
        public void preencherEmailUsuario(string valor) { uteis.preencheCampoInput(TextoEmailUsuario, valor, uteis.RetornaNomeVariavel(() => TextoEmailUsuario)); }

        public void clicarBotaoCriarUsuario() { uteis.clicaBotao(BotaoCriarUsuario, uteis.RetornaNomeVariavel(() => BotaoCriarUsuario)); }

        public void clicarBotaoApagarUsuario() { uteis.clicaBotao(BotaoApagarUsuario, uteis.RetornaNomeVariavel(() => BotaoApagarUsuario)); }
        public void clicarBotaoConfirmarExclusaoUsuario() { uteis.clicaBotao(BotaoConfirmarExclusaoUsuario, uteis.RetornaNomeVariavel(() => BotaoConfirmarExclusaoUsuario)); }

        //SubMenu Gerenciar Configuração
        public void clicarSubMenuGerenciarConfiguracao() { uteis.clicaBotao(SubMenuGerenciarConfiguracao, uteis.RetornaNomeVariavel(() => SubMenuGerenciarConfiguracao)); }
        public void clicarSubMenuRelatorioPermissoes() { uteis.clicaBotao(SubMenuRelatorioDePermissoes, uteis.RetornaNomeVariavel(() => SubMenuRelatorioDePermissoes)); }
        public void clicarSubMenuRelatorioDeConfiguracao() { uteis.clicaBotao(SubMenuRelatorioDeConfiguração, uteis.RetornaNomeVariavel(() => SubMenuRelatorioDeConfiguração)); }
        public void clicarSubLimiaresFluxoTrabalho() { uteis.clicaBotao(SubMenuLimiaresFluxoTrabalho, uteis.RetornaNomeVariavel(() => SubMenuLimiaresFluxoTrabalho)); }
        public void clicarSubMenuTransicoesFluxoTrabalho() { uteis.clicaBotao(SubMenuTransicoesFluxoTrabalho, uteis.RetornaNomeVariavel(() => SubMenuTransicoesFluxoTrabalho)); }
        public void clicarSubMenuNotificacoesEmail() { uteis.clicaBotao(SubMenuNotificaoEmail, uteis.RetornaNomeVariavel(() => SubMenuNotificaoEmail)); }
        public void clicarSubMenuGerenciarColunas() { uteis.clicaBotao(SubMenuGerenicarColunas, uteis.RetornaNomeVariavel(() => SubMenuGerenicarColunas)); }


        #endregion


        #region Verifica Métodos
        public void verificaAcessoTelaGerenciar()
        {
            wait.ElementToBeClickable(By.XPath("//div[@id='sidebar']/ul/li[7]/a/i"));
            Relatorio.test.Info("Menu Gerenciar acessado.");
        }

        public void verificaAcessoSubMenuGerenciarUsuarios()
        {
            wait.ElementToBeClickable(TituloGerenciarUsuarios);
            Relatorio.test.Info("SubMenu Gerenciar Usuários acessado.");
        }

        public void verificaAcessoSubMenuGerenciarProjetos()
        {
            wait.ElementToBeClickable(TituloGerenciarProjetos);
            Relatorio.test.Info("SubMenu Gerenciar Projetos acessado.");
        }

        public void verificaAcessoSubMenuGerenciarMarcadores()
        {
            wait.ElementToBeClickable(TituloGerenciarMarcadores);
            Relatorio.test.Info("SubMenu Gerenciar Marcadores acessado.");
        }

        public void verificaAcessoEditarProjeto()
        {
            wait.ElementToBeClickable(TextoNomeProjeto);
            Relatorio.test.Info("Página Editar Projeto acessada.");

        }

        public void verificaMensagemApagarprojeto()
        {
            wait.ElementToBeClickable(BotaoApagarProjeto);
            Assert.IsTrue(MensagemApagarProjeto.Text.Contains(" apagar este projeto e todas as tarefas "));
            Relatorio.test.Info("Mensagem Apagar Projeto exibida.");
        }

        public void verificaMensagemApagarMarcador()
        {
            wait.ElementToBeClickable(TituloConfirmarApagarMarcador);
            Assert.IsTrue(TituloConfirmarApagarMarcador.Text.Contains("Você tem certeza que quer apagar esse "));
            Relatorio.test.Info("Mensagem Apagar Marcador exibida.");
        }

        public void verificaAcessoDetalhesMarcador()
        {
            wait.ElementToBeClickable(TituloDetalhesMarcador);
            Assert.IsTrue(TituloDetalhesMarcador.Text.Contains("Detalhes do marcador: "));
            Relatorio.test.Info("Página Detalhes Marcador acessada.");
        }

        public void verificaAcessoCamposPersonalizados()
        {
            wait.ElementToBeClickable(TextoNomeCampoPersonalizado);
            Assert.AreEqual(TituloCamposPersonalizados.Text, "Campos Personalizados");
            Relatorio.test.Info("SubMenu Gerenciar Campos Personalizados acessado.");
        }

        public void verificaAcessoAlterarUsuario()
        {
            wait.ElementToBeClickable(BotaoAtualizarrUsuario);
            Assert.AreEqual(TituloAlterarUsuario.Text, "Alterar Usuário");
            Relatorio.test.Info("Página Alterar Usuário acessada.");
        }


        public void verificaMensagemApagarUsuario()
        {
            wait.ElementToBeClickable(BotaoConfirmarExclusaoUsuario);
            Assert.IsTrue(MensagemApagarUsuario.Text.Contains("Você tem certeza que deseja apagar esta "));
            Relatorio.test.Info("Mensagem Apagar Usuário exibida.");
        }

        public void verificaAcessoTelaCriarNovoUsuario()
        {
            wait.ElementToBeClickable(TextoNomeUsuario);
            Assert.IsTrue(TituloCriarNovoUsuario.Text.Contains("Criar nova "));
            Relatorio.test.Info("Página Criar Novo Usuário acessada.");
        }

        public bool verificaMensagemCampoNomeObrigatorio()
        {
            wait.ElementToBeClickable(MensagemValidacaoNovoUsuario);
            if (MensagemValidacaoNovoUsuario.Text.Contains("O nome de usuário não é inválido. Nomes de usuário podem conter apenas letras, números, espaços, hífens, pontos, sinais de mais e sublinhados."))
                return true;
            else
                return false;   
        }

        public bool verificaMensagemCampoEmailInvalido()
        {
            wait.ElementToBeClickable(MensagemValidacaoNovoUsuario);
            if (MensagemValidacaoNovoUsuario.Text.Contains("E-mail inválido."))
                return true;
            else
                return false;
        }

        public void verificaAcessoSubMenuRelatorioPermissoes()
        {
            wait.ElementToBeClickable(TituloRelatorioDePermissoes);
            Assert.IsTrue(TituloRelatorioDePermissoes.Text.Contains("anexo(s) "));
            Relatorio.test.Info("SubMenu Relatório De Permissões acessado.");
        }





        #endregion



        public void acessarMenuGerenciar()
        {
            clicarMenuGerenciar();
            verificaAcessoTelaGerenciar();
            
        }

        public void acessarSubMenuGerenciarUsuarios()
        {
            clicarSubMenuGerenciarUsuarios();
            verificaAcessoSubMenuGerenciarUsuarios();
            
        }

        public void acessarSubMenuGerenciarProjetos()
        {
            clicarSubMenuGerenciarProjetos();
            verificaAcessoSubMenuGerenciarProjetos();
            
        }

        public void acessarSubMenuGerenciarMarcadores()
        {
            clicarSubMenuGerenciarMarcadores();
            verificaAcessoSubMenuGerenciarMarcadores();
            
        }

        public void acessarSubMenuCamposPersonalizados()
        {
            clicarSubMenuCamposPersonalizados();
            
        }

        public void acessarSubMenuGerenciarConfiguracao()
        {
            clicarSubMenuGerenciarConfiguracao();
        }



        #region Projeto

        public string criarNovoProjetoAleatorio()
        {
            clicarBotaoCriarNovoProjeto();

            string projeto = "Projeto - " + uteis.gerarNumerosAleatorios();
            preencherNomeProjeto(projeto);
            preencherDescricaoProjetoAleatorio();

            clicarBotaoAdicionarProjeto();
            return projeto;
        }


        public bool verificarListagemProjeto(string projeto)
        {
            wait.ElementExists(By.TagName("table"));
            var tabela = INSTANCE.FindElement(By.TagName("table"));

            wait.ElementExists(By.TagName("tbody"));
            var subtabela = tabela.FindElement(By.TagName("tbody"));

            wait.ElementExists(By.TagName("tr"));
            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[0].Text.Equals(projeto))
                    return true;
            }//fim foreach
            return false;
        }


        public void selecionarProjetoCriado(string projeto)
        {
            uteis.clicaBotao(INSTANCE.FindElement(By.XPath("(//a[contains(text(),'"+projeto+"')])[2]")));
        }


        public string atualizarNomeProjeto()
        {
            string projeto = "Projeto - " + uteis.gerarNumerosAleatorios();
            preencherNomeProjeto(projeto);
            clicarAtualizarProjeto();
            return projeto;
        }

        public void apagarProjeto()
        {
            clicarApagarProjeto();
            verificaMensagemApagarprojeto();
            clicarApagarProjeto();
        }

        #endregion


        #region Marcadores
        public string criarNovoMarcadorAleatorio()
        {
            clicarBotaoCriarMarcador();

            string marcador = "Marcador - " + uteis.gerarNumerosAleatorios();
            preencherNomeMarcador(marcador);
            preencherDescricaoMarcadorAleatorio();

            clicarBotaoConfirmarNovoMarcador();
            return marcador;
        }



        public bool verificarListagemMarcador(string marcador)
        {
            wait.ElementExists(By.TagName("table"));
            var tabela = INSTANCE.FindElement(By.TagName("table"));

            wait.ElementExists(By.TagName("tbody"));
            var subtabela = tabela.FindElement(By.TagName("tbody"));

            wait.ElementExists(By.TagName("tr"));
            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[0].Text.Equals(marcador))
                    return true;
            }//fim foreach
            return false;
        }

        public void selecionarMarcadorCriado(string NomeMarcador)
        {
            uteis.clicaBotao(INSTANCE.FindElement(By.LinkText(NomeMarcador)));
            wait.ElementToBeClickable(TituloDetalhesMarcador);
            Assert.IsTrue(TituloDetalhesMarcador.Text.Contains(NomeMarcador));
        }

        public void apagarMarcador()
        {
            clicarBotaoApagarMarcador();
            verificaMensagemApagarMarcador();
            clicarBotaoApagarMarcador();
        }

        public string atualizarNomeMarcador()
        {
            clicarBotaoAtualizarMarcador();
            string marcador = "Marcador - " + uteis.gerarNumerosAleatorios();
            preencherNomeMarcador(marcador);
            clicarBotaoAtualizarMarcador();
            return marcador;
        }

        #endregion


        #region Campos Personalizados
        public string criarNovoCampoPersonalizado()
        {
            string campo = "Nome Campo - " + uteis.gerarNumerosAleatorios();
            preencherNomePersonalizado(campo);
            clicarBotaoNovoCampoPersonalizado();
            return campo;
        }

        public bool verificarListagemCampoPersonalizado(string marcador)
        {
            wait.ElementExists(By.TagName("table"));
            var tabela = INSTANCE.FindElement(By.TagName("table"));

            wait.ElementExists(By.TagName("tbody"));
            var subtabela = tabela.FindElement(By.TagName("tbody"));

            wait.ElementExists(By.TagName("tr"));
            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[0].Text.Equals(marcador))
                    return true;
            }//fim foreach
            return false;
        }


        #endregion



        #region Usuarios

        public string criarNovoUsuarioAleatorio()
        {
            clicarBotaoNovoUsuario();

            string usuario = "Usuario - " + uteis.gerarNumerosAleatorios();
            preencherNomeUsuario(usuario);
            preencherNomeVerdadeiroUsuarioAleatorio();
            preencherEmailUsuario("teste_" + uteis.gerarNumerosAleatorios()+"@gmail.com");
            clicarBotaoCriarUsuario();
            return usuario;
        }


        public bool verificarListagemUsuario(string usuario)
        {
            wait.ElementExists(By.TagName("table"));
            var tabela = INSTANCE.FindElement(By.TagName("table"));

            wait.ElementExists(By.TagName("tbody"));
            var subtabela = tabela.FindElement(By.TagName("tbody"));

            wait.ElementExists(By.TagName("tr"));
            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[0].Text.Equals(usuario))
                    return true;
            }//fim foreach
            return false;
        }

        public void selecionarUsuarioCriado(string NomeUsuario)
        {
            uteis.clicaBotao(INSTANCE.FindElement(By.LinkText(NomeUsuario)));
            wait.ElementToBeClickable(TituloAlterarUsuario);
            Relatorio.test.Pass("O usuário '" + NomeUsuario + "' foi selecionado.");
        }

        public void apagarUsuario()
        {
            clicarBotaoApagarUsuario();
            verificaMensagemApagarUsuario();
            clicarBotaoConfirmarExclusaoUsuario();
        }

        #endregion

    }//fim class mae
}//fim namespace
