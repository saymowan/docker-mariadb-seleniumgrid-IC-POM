using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using MantisBase2Saycao.Uteis.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisBase2Saycao.PageObjects
{
    public class VerTarefasPageObjects : DriverFactory
    {

        [FindsBy(How= How.XPath, Using = "//div[@id='navbar-container']/div/a/span")]
        public IWebElement TituloHome { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='assigned']/div/div[2]/div/a")]
        public IWebElement BotaoAtribuidosMim { get; set; }

        [FindsBy(How = How.Id, Using = "handler_id_filter_target")]
        public IWebElement TextoAtribuidoA { get; set; }

        [FindsBy(How = How.Id, Using = "reporter_id_filter_target")]
        public IWebElement TextoRelator { get; set; }

        [FindsBy(How = How.Id, Using = "bug_action")]
        public IWebElement PaginaVerTarefas { get; set; }

        [FindsBy(How = How.Id, Using = "show_status_filter_target")]
        public IWebElement TextoStatus { get; set; }

        [FindsBy(How = How.Id, Using = "do_filter_by_last_updated_date_filter_target")]
        public IWebElement TextoFiltrarDataUltimaAtualizacao { get; set; }

        [FindsBy(How = How.Id, Using = "reporter_id_filter_target")]
        public IWebElement TextoMonitoradoPor { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='sidebar']/ul/li[2]/a/i")]
        public IWebElement MenuVerTarefas { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='bug_action']/div/div/h4")]
        public IWebElement TituloVerTarefas { get; set; }

        [FindsBy(How = How.Id, Using = "handler_id_filter")]
        public IWebElement TextoAtribuir { get; set; }

        [FindsBy(How = How.Name, Using = "handler_id[]")]
        public IWebElement DropDownAtribuir { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='filter_submit']")]
        public IWebElement BotaoFiltrar { get; set; }

        [FindsBy(How = How.Name, Using = "save_query_button")]
        public IWebElement BotaoSalvarFiltroAtual { get; set; }

        [FindsBy(How = How.Name, Using = "query_name")]
        public IWebElement TextoNovoFiltro { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='save-filter']/div/h4")]
        public IWebElement TituloSalvarFiltroAtual { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='save-filter']/div[2]/div/form/input[3]")]
        public IWebElement BotaoSalvarNovoFiltro { get; set; }

        [FindsBy(How = How.Name, Using = "source_query_id")]
        public IWebElement DropDownFiltros { get; set; }

        [FindsBy(How = How.Name, Using = "action")]
        public IWebElement DropDownAcao { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='OK']")]
        public IWebElement BotaoAcaoOK { get; set; }

        [FindsBy(How = How.Name, Using = "project_id")]
        public IWebElement DropDownProjeto { get; set; }

        [FindsBy(How = How.Name, Using = "assign")]
        public IWebElement DropDownUsuario { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='action-group-div']/form/div/div/h4")]
        public IWebElement TituloAcao { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Mover Tarefas']")]
        public IWebElement BotaoMoverTarefas { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Copiar Tarefas']")]
        public IWebElement BotaoCopiarTarefas { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Apagar Tarefas']")]
        public IWebElement BotaoApagarTarefas { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Atribuir Tarefas']")]
        public IWebElement BotaoAtribuirTarefas { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Resolver Tarefas']")]
        public IWebElement BotaoResolverTarefas { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Atualizar Prioridade']")]
        public IWebElement BotaoAtualizarPrioridadeTarefas { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@id='dropdown_projects_menu']/a")]
        public IWebElement ProjetoCabecalho { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='navbar-container']/div[2]/ul/li[3]/a/span")]
        public IWebElement UsuarioCabecalho { get; set; }

        [FindsBy(How = How.Name, Using = "resolution")]
        public IWebElement DropDownResolucao { get; set; }

        [FindsBy(How = How.Name, Using = "priority")]
        public IWebElement DropDownPrioridade { get; set; }

        [FindsBy(How = How.LinkText, Using = "Núm")]
        public IWebElement FiltroAtualizado { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div/div/h4")]
        public IWebElement TituloDetalhesTarefa { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/div[2]/div/table/tbody/tr[6]/td")]
        public IWebElement TextoPrioridadeDetalhe { get; set; }



        Uteis.Uteis uteis= new Uteis.Uteis();
        WaitUntil wait = new WaitUntil(DriverFactory.INSTANCE);


        public VerTarefasPageObjects()
        {
            PageFactory.InitElements(DriverFactory.INSTANCE, this);
        }


        #region Ações Métodos
        public void acessarVerTarefas() { uteis.clicaBotao(MenuVerTarefas); }
        public void clicarAtribuir() { uteis.clicaBotao(TextoAtribuir, uteis.RetornaNomeVariavel(() => TextoAtribuir)); }
        public void selecionarAtribuido(string valor) { uteis.escolherElementoDropDown(DropDownAtribuir, valor, uteis.RetornaNomeVariavel(() => DropDownAtribuir)); }
        public void clicarFiltrar() { uteis.clicaBotao(BotaoFiltrar, uteis.RetornaNomeVariavel(() => BotaoFiltrar)); }
        public void clicarSalvarFiltroAtual() { uteis.clicaBotao(BotaoSalvarFiltroAtual, uteis.RetornaNomeVariavel(() => BotaoSalvarFiltroAtual)); }
        public void preencherNovoFiltro(string valor) { uteis.preencheCampoInput(TextoNovoFiltro, valor, uteis.RetornaNomeVariavel(() => TextoNovoFiltro)); }
        public void clicarSalvarNovoFiltro() { uteis.clicaBotao(BotaoSalvarNovoFiltro, uteis.RetornaNomeVariavel(() => BotaoSalvarNovoFiltro)); }

        public void selecionarAcaoMover() { uteis.escolherElementoDropDown(DropDownAcao, "Mover", uteis.RetornaNomeVariavel(() => DropDownAcao)); clicarAcao(); }
        public void selecionarAcaoCopiar() { uteis.escolherElementoDropDown(DropDownAcao, "Copiar", uteis.RetornaNomeVariavel(() => DropDownAcao)); clicarAcao(); }
        public void selecionarAcaoApagar() { uteis.escolherElementoDropDown(DropDownAcao, "Apagar", uteis.RetornaNomeVariavel(() => DropDownAcao)); clicarAcao(); }
        public void selecionarAcaoAtribuir() { uteis.escolherElementoDropDown(DropDownAcao, "Atribuir", uteis.RetornaNomeVariavel(() => DropDownAcao)); clicarAcao(); }
        public void selecionarAcaoResolver() { uteis.escolherElementoDropDown(DropDownAcao, "Resolver", uteis.RetornaNomeVariavel(() => DropDownAcao)); clicarAcao(); }
        public void selecionarAcaoAtualizarPrioridade() { uteis.escolherElementoDropDown(DropDownAcao, "Atualizar Prioridade", uteis.RetornaNomeVariavel(() => DropDownAcao)); clicarAcao(); }

        public void clicarFiltroAtualizado() { uteis.clicaBotao(FiltroAtualizado, uteis.RetornaNomeVariavel(() => FiltroAtualizado)); }


        public void clicarAcao() { uteis.clicaBotao(BotaoAcaoOK, uteis.RetornaNomeVariavel(() => BotaoAcaoOK)); }
        public void clicarMoverTarefas() { uteis.clicaBotao(BotaoMoverTarefas, uteis.RetornaNomeVariavel(() => BotaoMoverTarefas)); }
        public void clicarCopiarTarefas() { uteis.clicaBotao(BotaoCopiarTarefas, uteis.RetornaNomeVariavel(() => BotaoCopiarTarefas)); }
        public void clicarApagarTarefas() { uteis.clicaBotao(BotaoApagarTarefas, uteis.RetornaNomeVariavel(() => BotaoApagarTarefas)); }
        public void clicarAtribuirTarefas() { uteis.clicaBotao(BotaoAtribuirTarefas, uteis.RetornaNomeVariavel(() => BotaoAtribuirTarefas)); }
        public void clicarResolverTarefas() { uteis.clicaBotao(BotaoResolverTarefas, uteis.RetornaNomeVariavel(() => BotaoResolverTarefas)); }
        public void clicarAtualizarPrioridadeTarefas() { uteis.clicaBotao(BotaoAtualizarPrioridadeTarefas, uteis.RetornaNomeVariavel(() => BotaoAtualizarPrioridadeTarefas)); }
        #endregion


        #region Verifica Métodos

        public void verificarAcessoSalvarFiltroAtual()
        {
            Assert.AreEqual(ConfigurationManager.AppSettings["login"].ToString(), TextoAtribuidoA.Text);
            Relatorio.test.Info("Página Salvar Filtro Atual acessada.");
        }

        public void verificarAcessoVerTarefas()
        {
            wait.ElementToBeClickable(PaginaVerTarefas);
            Relatorio.test.Info("Página Ver Tarefas acessada.");
        }

        public void verificarAcessoTelaSalvarFiltroAtual()
        {
            Assert.AreEqual("Salvar Filtro Atual", TituloSalvarFiltroAtual.Text);
            Relatorio.test.Info("Página Salvar Filtro Atual acessada.");
        }

        public void verificarAcesoTelaMover()
        {
            wait.ElementToBeClickable(BotaoMoverTarefas);
            Assert.AreEqual("Mover tarefas para", TituloAcao.Text);
            Relatorio.test.Info("Página Mover acessada.");
        }

        public void verificarAcesoTelaCopiar()
        {
            wait.ElementToBeClickable(BotaoCopiarTarefas);
            Assert.AreEqual("Copiar tarefas para", TituloAcao.Text);
            Relatorio.test.Info("Página Copiar acessada.");
        }

        public void verificarAcessoTelaApagar()
        {
            wait.ElementToBeClickable(BotaoApagarTarefas);
            Assert.AreEqual("Você tem certeza que deseja apagar estas tarefas?", TituloAcao.Text);
            Relatorio.test.Info("Página Apagar acessada.");
        }


        public void verificarAcessoTelaMover()
        {
            wait.ElementToBeClickable(BotaoApagarTarefas);
            Assert.AreEqual("Você tem certeza que deseja apagar estas tarefas?", TituloAcao.Text);
            Relatorio.test.Info("Página Mover acessada.");
        }

        public void verificarAcessoTelaAtribuir()
        {
            wait.ElementToBeClickable(BotaoAtribuirTarefas);
            Assert.AreEqual("Atribuir tarefas a", TituloAcao.Text);
            Relatorio.test.Info("Página Atribuir acessada.");
        }

        public void verificarAcessoTelaResolver()
        {
            wait.ElementToBeClickable(BotaoResolverTarefas);
            Assert.AreEqual("Escolher resolução das tarefas", TituloAcao.Text);
            Relatorio.test.Info("Página Resolver acessada.");
        }

        public void verificarAcessoTelaAtualizarPrioridades()
        {
            wait.ElementToBeClickable(BotaoAtualizarPrioridadeTarefas);
            Assert.AreEqual("Escolher prioridade das tarefas", TituloAcao.Text);
            Relatorio.test.Info("Página Atualizar Prioridades acessada.");
        }

        public void verificarAcessoDetalhesTarefas()
        {
            wait.ElementToBeClickable(TituloDetalhesTarefa);
            Assert.AreEqual("Ver Detalhes da Tarefa", TituloDetalhesTarefa.Text);
            Relatorio.test.Info("Página Detalhes Tarefa acessada.");
        }

        #endregion


        public void filtrarAtribuido(string usuario)
        {
            clicarAtribuir();
            selecionarAtribuido(usuario);
            clicarFiltrar();
        }


        public void gerarNovoFiltro()
        {
            clicarSalvarFiltroAtual();
            verificarAcessoTelaSalvarFiltroAtual();
            preencherNovoFiltro("Filtro - "+ uteis.gerarNumerosAleatorios());
            clicarSalvarNovoFiltro();            
        }

        public string gerarERetornarNovoFiltro()
        {
            string NovoFiltro = "Filtro - " + uteis.gerarNumerosAleatorios();
            clicarSalvarFiltroAtual();
            verificarAcessoTelaSalvarFiltroAtual();
            preencherNovoFiltro(NovoFiltro);
            clicarSalvarNovoFiltro();
            return NovoFiltro;
        }


        public bool verificarNovoFiltroCriado(string valor)
        {
            return uteis.verificarValorNaLista(DropDownFiltros, valor);
        }

        public void resetarFiltro()
        {
            try
            {
                uteis.escolherElementoDropDown(DropDownFiltros, "[Redefinir Filtro]");
            }
            catch
            {
            }
        }


        public void selecionarTarefaCriada(string resumo)
        {
            wait.ElementExists(By.Id("buglist"));
            var tabela = INSTANCE.FindElement(By.Id("buglist"));

            wait.ElementExists(By.TagName("tbody"));
            var subtabela = tabela.FindElement(By.TagName("tbody"));

            wait.ElementExists(By.TagName("tr"));
            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[10].Text.Equals(resumo))
                    uteis.clicaBotao(tds[0]);
                break;
            }//fim foreach

        }//fim void


        public void moverTarefa()
        {
            verificarAcesoTelaMover();
            selecionarProjetoRandomico();
            clicarMoverTarefas();
        }

        public void apagarTarefa()
        {
            verificarAcessoTelaApagar();
            clicarApagarTarefas();
        }

        public string atribuirTarefa()
        {
             
            verificarAcessoTelaAtribuir();
            string usuario = selecionarUsuarioRandomico();
            clicarAtribuirTarefas();
            return usuario;
        }


        public void resolverTarefa()
        {
            verificarAcessoTelaResolver();
            uteis.escolherElementoDropDown(DropDownResolucao,"corrigido");
            clicarResolverTarefas();
        }

        public void copiarTarefa()
        {
            clicarCopiarTarefas();
        }


        public void atualizarPrioridade_Normal()
        {
            verificarAcessoTelaAtualizarPrioridades();
            uteis.escolherElementoDropDown(DropDownPrioridade, "normal");
            clicarAtualizarPrioridadeTarefas();
        }







        public string selecionarUsuarioRandomico()
        {
            string usuarioAtual = UsuarioCabecalho.Text.Trim();
            SelectElement selector = new SelectElement(DropDownUsuario);

            IList<IWebElement> allOptions = selector.Options;
            int aux = allOptions.Count();

            for (int i = 1; i < aux; i++)
            {
                if (allOptions[i].Text.Trim().Contains(usuarioAtual))
                {
                    //faz nada não
                }
                else
                {
                    new SelectElement(DropDownUsuario).SelectByText(allOptions[i].Text.Trim());
                    return allOptions[i].Text.Trim();
                }
            }//fim for

            return null;
        }




        public string selecionarProjetoRandomico()
        {
            string projetoAtual = ProjetoCabecalho.Text.Trim();
            SelectElement selector = new SelectElement(DropDownProjeto);

            IList<IWebElement> allOptions = selector.Options;
            int aux = allOptions.Count();

            for (int i = 1; i < aux; i++)
            {
                if (allOptions[i].Text.Trim().Contains(projetoAtual))
                {
                    //faz nada não
                }
                else
                {
                    new SelectElement(DropDownProjeto).SelectByText(allOptions[i].Text.Trim());
                    return allOptions[i].Text.Trim();
                }
            }//fim for

            return null;
        }


        public bool verificarListagemResumo(string resumo)
        {
            wait.ElementExists(By.Id("buglist"));
            var tabela = INSTANCE.FindElement(By.Id("buglist"));

            wait.ElementExists(By.TagName("tbody"));
            var subtabela = tabela.FindElement(By.TagName("tbody"));

            wait.ElementExists(By.TagName("tr"));
            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[10].Text.Equals(resumo))
                    return true;              
            }//fim foreach
            return false;
        }



        public bool verificarListagemTarefaAtribuicao(string colunaResumo, string colunaUsuario)
        {
            wait.ElementExists(By.Id("buglist"));
            var tabela = INSTANCE.FindElement(By.Id("buglist"));

            wait.ElementExists(By.TagName("tbody"));
            var subtabela = tabela.FindElement(By.TagName("tbody"));

            wait.ElementExists(By.TagName("tr"));
            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[10].Text.Equals(colunaResumo) && (tds[8].Text.Contains(colunaUsuario)))
                    return true;
            }//fim foreach
            return false;
        }



        public bool acessarTarefaListagem(string colunaResumo)
        {
            wait.ElementExists(By.Id("buglist"));
            var tabela = INSTANCE.FindElement(By.Id("buglist"));

            wait.ElementExists(By.TagName("tbody"));
            var subtabela = tabela.FindElement(By.TagName("tbody"));

            wait.ElementExists(By.TagName("tr"));
            foreach (var tr in subtabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[10].Text.Equals(colunaResumo))
                {
                    tds[3].Click();
                    return true;
                }
                   
            }//fim foreach
            return false;
        }


        public void acessarProjeto(string projeto)
        {
            ProjetoCabecalho.Click();
            INSTANCE.FindElement(By.LinkText(projeto)).Click();
        }

    }//fim class
}//fim namespace
