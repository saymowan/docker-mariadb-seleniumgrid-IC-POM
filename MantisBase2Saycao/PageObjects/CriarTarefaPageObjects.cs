using MantisBase2Saycao.Uteis;
using MantisBase2Saycao.Uteis.Driver;
using MantisBase2Saycao.Uteis.Helper;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace MantisBase2Saycao.PageObjects
{
    public class CriarTarefaPageObjects : DriverFactory
    {

        #region Mapeamento boladão
        [FindsBy(How = How.XPath, Using = "//form[@id='report_bug_form']/div/div/h4")]
        public IWebElement TituloCriarTarefa { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='sidebar']/ul/li[3]/a/i")]
        public IWebElement MenuCriarTarefa { get; set; }

        [FindsBy(How = How.Id, Using = "category_id")]
        public IWebElement DropDownCategoria { get; set; }

        [FindsBy(How = How.Id, Using = "reproducibility")]
        public IWebElement DropDownFrequencia { get; set; }

        [FindsBy(How = How.Id, Using = "severity")]
        public IWebElement DropDownGravidade { get; set; }

        [FindsBy(How = How.Id, Using = "priority")]
        public IWebElement DropDownPrioridade { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='profile_closed_link']/i")]
        public IWebElement BotaoSelecionarPerfil { get; set; }

        [FindsBy(How = How.Id, Using = "platform")]
        public IWebElement TextoPlataforma { get; set; }

        [FindsBy(How = How.Id, Using = "os")]
        public IWebElement TextoSistemaOperacional { get; set; }

        [FindsBy(How = How.Id, Using = "os_build")]
        public IWebElement TextoVersaoSistemaOperacional { get; set; }

        [FindsBy(How = How.Id, Using = "handler_id")]
        public IWebElement DropDownAtribuirA { get; set; }
        
        [FindsBy(How = How.Id, Using = "summary")]
        public IWebElement TextoResumo { get; set; }

        [FindsBy(How = How.Id, Using = "description")]
        public IWebElement TextoDescricao { get; set; }

        [FindsBy(How = How.Id, Using = "steps_to_reproduce")]
        public IWebElement TextoPassosParaReproduzir { get; set; }

        [FindsBy(How = How.Id, Using = "additional_info")]
        public IWebElement TextoInformacoesAdicionais { get; set; }

        [FindsBy(How = How.Id, Using = "tag_string")]
        public IWebElement TextoMarcadores { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[13]/td/label/span")]
        public IWebElement RadioVisibilidadePublica { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[13]/td/label[2]/span")]
        public IWebElement RadioVisibilidadePrivado { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@id='report_bug_form']/div/div[2]/div[2]/input")]
        public IWebElement BotaoCriarNovaTarefa { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p")]
        public IWebElement MensagemOperacao { get; set; }

        [FindsBy(How = How.Id, Using = "buglist")]
        public IWebElement tabelaTarefas { get; set; }

        #endregion boladão



        Uteis.Uteis uteis = new Uteis.Uteis();
        WaitUntil wait = new WaitUntil(DriverFactory.INSTANCE);


        public CriarTarefaPageObjects()
        {
            PageFactory.InitElements(DriverFactory.INSTANCE, this);
        }


        #region Ações Métodos
        public void acessarCriarTarefa() { uteis.clicaBotao(MenuCriarTarefa, uteis.RetornaNomeVariavel(() => MenuCriarTarefa)); }

        public void selecionarCategoria(string valor) { uteis.escolherElementoDropDown(DropDownCategoria, valor, uteis.RetornaNomeVariavel(() => DropDownCategoria)); }
        public void selecionarCategoriaAleatoria() { uteis.escolherValorAleatorioNaLista(DropDownCategoria, uteis.RetornaNomeVariavel(() => DropDownCategoria)); }

        public void selecionarFrequencia(string valor) { uteis.escolherElementoDropDown(DropDownFrequencia, valor, uteis.RetornaNomeVariavel(() => DropDownFrequencia)); }
        public void selecionarFrequenciaAleatoria() { uteis.escolherValorAleatorioNaLista(DropDownFrequencia, uteis.RetornaNomeVariavel(() => DropDownFrequencia));  }

        public void selecionarGravidade(string valor) { uteis.escolherElementoDropDown(DropDownGravidade, valor, uteis.RetornaNomeVariavel(() => DropDownGravidade)); }
        public void selecionarGravidadeAleatoria() { uteis.escolherValorAleatorioNaLista(DropDownGravidade, uteis.RetornaNomeVariavel(() => DropDownGravidade)); }

        public void selecionarPrioridade(string valor) { uteis.escolherElementoDropDown(DropDownPrioridade, uteis.RetornaNomeVariavel(() => DropDownPrioridade)); }
        public void selecionarPrioridadeAleatoria() { uteis.escolherValorAleatorioNaLista(DropDownPrioridade, uteis.RetornaNomeVariavel(() => DropDownPrioridade)); }

        public void selecionarPerfil() { uteis.clicaBotao(BotaoSelecionarPerfil, uteis.RetornaNomeVariavel(() => BotaoSelecionarPerfil)); }

        public void preencherPlataforma(string valor) { uteis.preencheCampoInput(TextoPlataforma, uteis.RetornaNomeVariavel(() => TextoPlataforma)); }
        public void preencherPlataformaAleatoria() { uteis.preencheCampoInput(TextoPlataforma, "Plataforma - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoPlataforma)); }

        public void preencherSistemaOperacional(string valor) { uteis.preencheCampoInput(TextoSistemaOperacional, valor, uteis.RetornaNomeVariavel(() => TextoSistemaOperacional)); }
        public void preencherSistemaOperacionalAleatoria() { uteis.preencheCampoInput(TextoSistemaOperacional, "Sistema Operacional - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoSistemaOperacional)); }

        public void preencherVersaoSistemaOperacional(string valor) { uteis.preencheCampoInput(TextoVersaoSistemaOperacional, valor, uteis.RetornaNomeVariavel(() => TextoVersaoSistemaOperacional)); }
        public void preencherVersaoSistemaOperacionalAleatoria() { uteis.preencheCampoInput(TextoVersaoSistemaOperacional, "Versão SO - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoVersaoSistemaOperacional)); }

        public void selecionarAtribuirA(string valor) { uteis.escolherElementoDropDown(DropDownAtribuirA, valor, uteis.RetornaNomeVariavel(() => DropDownAtribuirA)); }
        public void selecionarAtribuirAleatoria() { uteis.escolherValorAleatorioNaLista(DropDownAtribuirA, uteis.RetornaNomeVariavel(() => DropDownAtribuirA)); }

        public void preencherResumo(string valor) { uteis.preencheCampoInput(TextoResumo, valor, uteis.RetornaNomeVariavel(() => DropDownFrequencia)); }
        public void preencherResumoAleatoria() { uteis.preencheCampoInput(TextoResumo, "Resumo - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => DropDownFrequencia)); }

        public void preencherDescricao(string valor) { uteis.preencheCampoInput(TextoDescricao, valor, uteis.RetornaNomeVariavel(() => TextoResumo)); }
        public void preencherDescricaoAleatoria() { uteis.preencheCampoInput(TextoDescricao, "Descrição - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoResumo)); }

        public void preencherPassosParaReproduzir(string valor) { uteis.preencheCampoInput(TextoPassosParaReproduzir, valor, uteis.RetornaNomeVariavel(() => TextoPassosParaReproduzir)); }
        public void preencherPassosParaReproduzirAleatoria() { uteis.preencheCampoInput(TextoPassosParaReproduzir, "Passos para reproduzir - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoPassosParaReproduzir)); }

        public void preencherInformacoesAdicionais(string valor) { uteis.preencheCampoInput(TextoInformacoesAdicionais, valor, uteis.RetornaNomeVariavel(() => TextoInformacoesAdicionais)); }
        public void preencherInformacoesAdicionaisAleatoria() { uteis.preencheCampoInput(TextoInformacoesAdicionais, "Informações Adicionais - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoInformacoesAdicionais)); }

        public void preencherAplicarMarcadores(string valor) { uteis.preencheCampoInput(TextoMarcadores, valor, uteis.RetornaNomeVariavel(() => TextoMarcadores)); }
        public void preencherAplicarMarcadoresAleatoria() { uteis.preencheCampoInput(TextoMarcadores, "Marcador - " + uteis.gerarNumerosAleatorios(), uteis.RetornaNomeVariavel(() => TextoMarcadores)); }

        public void clicarCriarNovaTarefa() { uteis.clicaBotao(BotaoCriarNovaTarefa, uteis.RetornaNomeVariavel(() => BotaoCriarNovaTarefa)); }

        public void escolherVisibilidadePublica() { uteis.clicaBotao(RadioVisibilidadePublica, uteis.RetornaNomeVariavel(() => RadioVisibilidadePublica)); }


        #endregion


        #region Verifica Métodos
        public void verificarAcessoCriarTarefa()
        {
            Assert.AreEqual("Digite os Detalhes do Relatório", TituloCriarTarefa.Text);
            Relatorio.test.Info("Página Criar Tarefa acessada.");
        }
        #endregion

        public string criarNovaTarefaAleatoriaRetornaResumo()
        {
            string resumo = "Resumo - " + uteis.gerarNumerosAleatorios();
            selecionarCategoriaAleatoria();
            selecionarFrequenciaAleatoria();
            selecionarGravidadeAleatoria();
            selecionarPrioridadeAleatoria();

            
            //selecionarPerfil();
            //preencherPlataformaAleatoria();
            //preencherSistemaOperacionalAleatoria();
            //preencherVersaoSistemaOperacionalAleatoria();

            selecionarAtribuirAleatoria();
            preencherResumo(resumo);
            preencherDescricaoAleatoria();
            preencherPassosParaReproduzirAleatoria();
            preencherInformacoesAdicionaisAleatoria();

            escolherVisibilidadePublica();

            clicarCriarNovaTarefa();

            return resumo;
        }


        public void criarNovaTarefaAleatoria()
        {
            
            selecionarCategoriaAleatoria();
            selecionarFrequenciaAleatoria();
            selecionarGravidadeAleatoria();
            selecionarPrioridadeAleatoria();

            //selecionarPerfil();
            //preencherPlataformaAleatoria();
            //preencherSistemaOperacionalAleatoria();
            //preencherVersaoSistemaOperacionalAleatoria();

            selecionarAtribuirAleatoria();
            preencherResumoAleatoria();
            preencherDescricaoAleatoria();
            preencherPassosParaReproduzirAleatoria();
            preencherInformacoesAdicionaisAleatoria();

            escolherVisibilidadePublica();

            clicarCriarNovaTarefa();
        }

        public string criarNovaTarefaAleatoria(string frequencia, string gravidade)
        {
            string resumo = "Resumo - " + uteis.gerarNumerosAleatorios();
            selecionarCategoriaAleatoria();
            selecionarFrequencia(frequencia);
            selecionarGravidade(gravidade);
            selecionarPrioridadeAleatoria();

            //selecionarPerfil();
            //preencherPlataformaAleatoria();
            //preencherSistemaOperacionalAleatoria();
            //preencherVersaoSistemaOperacionalAleatoria();

            selecionarAtribuirAleatoria();
            preencherResumo(resumo);
            preencherDescricaoAleatoria();
            preencherPassosParaReproduzirAleatoria();
            preencherInformacoesAdicionaisAleatoria();

            escolherVisibilidadePublica();

            clicarCriarNovaTarefa();

            return resumo;
        }




    }//fim void
}//fim namespace
