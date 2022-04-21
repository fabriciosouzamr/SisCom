using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.Formularios;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Classes
{
    public class formBuscarCNPJDados
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public DateTime DateAbertura { get; set; }
        public Guid Estado { get; set; }
        public Guid Cidade { get; set; }
    }

    public static class Forms
    {
        public static void formBuscarCNPJCarregar(IServiceProvider serviceProvider,
                                                  IServiceScopeFactory<MeuDbContext> dbCtxFactory,
                                                  INotifier _notifier,
                                                  MaskedTextBox maskedCPFCNPJ,
                                                  TextBox textRazaoSocial,
                                                  TextBox textNome,
                                                  MaskedTextBox maskedEnderecoCEP,
                                                  TextBox textEndrecoLogradouro,
                                                  TextBox textEndrecoNumero,
                                                  TextBox textEndrecoComplmento,
                                                  TextBox textEndrecoBairro,
                                                  ComboBox comboEndrecoUF,
                                                  ComboBox comboEndrecoCidade)
        {
            using (frmCadastroBuscarCNPJ form = new frmCadastroBuscarCNPJ(serviceProvider, dbCtxFactory, _notifier))
            {
                form.ShowDialog();

                if (form.formBuscarCNPJDados != null)
                {
                    maskedCPFCNPJ.Text = form.formBuscarCNPJDados.CNPJ;
                    if (textRazaoSocial != null) textRazaoSocial.Text = form.formBuscarCNPJDados.RazaoSocial;
                    textNome.Text = form.formBuscarCNPJDados.NomeFantasia;
                    maskedEnderecoCEP.Text = form.formBuscarCNPJDados.CEP;
                    textEndrecoLogradouro.Text = form.formBuscarCNPJDados.Logradouro;
                    textEndrecoNumero.Text = form.formBuscarCNPJDados.Numero;
                    if (textEndrecoComplmento != null) { textEndrecoComplmento.Text = form.formBuscarCNPJDados.Complemento; }
                    textEndrecoBairro.Text = form.formBuscarCNPJDados.Bairro;
                    comboEndrecoUF.SelectedValue = form.formBuscarCNPJDados.Estado;
                    comboEndrecoCidade.SelectedValue = form.formBuscarCNPJDados.Cidade;
                }
            }
        }

        public static async Task formBuscarCEPCarregar(IServiceProvider serviceProvider,
                                                       IServiceScopeFactory<MeuDbContext> dbCtxFactory,
                                                       INotifier _notifier,
                                                       string CEP,
                                                       TextBox textLogradouro,
                                                       TextBox textBairro,
                                                       ComboBox comboUF,
                                                       ComboBox comboCidade,
                                                       TextBox textComplmento)
        {
            if (CaixaMensagem.Perguntar("Atualizar endereço?"))
            {
                formBuscarCEPCarregar_EdicaoControle(false, textLogradouro, textBairro, comboUF, comboCidade, textComplmento);

                API_Consultas.AcoesAPI.CEPRetorno CEPRetorno = API_Consultas.AcoesAPI.ConsultaCEP(Funcoes._Classes.Texto.SomenteNumero(CEP));

                if (CEPRetorno != null)
                {
                    textLogradouro.Text = CEPRetorno.xLgr;
                    textBairro.Text = CEPRetorno.xBairro;
                    Combo_ComboBox.Selecionar(comboUF, CEPRetorno.uf);

                    await comboCidade_Carregar(serviceProvider,
                                               dbCtxFactory,
                                               _notifier,
                                               (Guid)comboUF.SelectedValue,
                                               CEPRetorno.xMun,
                                               CEPRetorno.cMun,
                                               comboUF,
                                               comboCidade);

                    if (textComplmento != null) textComplmento.Text = CEPRetorno.xCpl;
                }

                formBuscarCEPCarregar_EdicaoControle(true, textLogradouro, textBairro, comboUF, comboCidade, textComplmento);
            }
        }

        private static void formBuscarCEPCarregar_EdicaoControle(bool Habilitar,
                                                                 TextBox textLogradouro,
                                                                 TextBox textBairro,
                                                                 ComboBox comboUF,
                                                                 ComboBox comboCidade,
                                                                 TextBox textComplmento)
        {
            textLogradouro.Enabled = Habilitar;
            textBairro.Enabled = Habilitar;
            comboUF.Enabled = Habilitar;
            comboCidade.Enabled = Habilitar;
            if (textComplmento != null) textComplmento.Enabled = Habilitar;
        }

        private static async Task Cidade_Adicionar(MeuDbContext MeuDbContext,
                                                   INotifier _notifier,
                                                   Guid EstadoId,
                                                   string CodigoIBGE,
                                                   string nome)
        {
            CidadeViewModel cidade = new();
            cidade.Nome = nome;
            cidade.CodigoIBGE = CodigoIBGE;
            cidade.EstadoId = EstadoId;
            await (new CidadeController(MeuDbContext, _notifier).Adicionar(cidade));
        }

        public static async Task comboCidade_Carregar(IServiceProvider serviceProvider,
                                                      IServiceScopeFactory<MeuDbContext> dbCtxFactory,
                                                      INotifier _notifier,
                                                      Guid EstadoId,
                                                      string NomeCidade,
                                                      string CodigoIBGE,
                                                      ComboBox comboUF,
                                                      ComboBox comboCidade)
        {
            FormMain FormMain;

            FormMain = new FormMain(serviceProvider, dbCtxFactory, _notifier);

            await comboCidade_CarregarCombo(FormMain.MeuDbContext(),
                                            _notifier,
                                            (Guid)comboUF.SelectedValue,
                                            comboCidade);
            comboCidade.SelectedIndex = -1;
            FuncaoInterna.comboCidade_Posicionar(comboCidade, NomeCidade);

            if ((comboCidade.SelectedIndex == -1) && (comboUF.SelectedIndex != -1))
            {
                await Cidade_Adicionar(FormMain.MeuDbContext(),
                                       FormMain._notifier,
                                       (Guid)comboUF.SelectedValue,
                                       CodigoIBGE,
                                       Funcoes._Classes.Texto.PrimeiraMaiusculaTodasPalavras(NomeCidade));
                await comboCidade_CarregarCombo(FormMain.MeuDbContext(),
                                                _notifier,
                                                (Guid)comboUF.SelectedValue,
                                                comboCidade);
                comboCidade.Text = NomeCidade;
            }

            FormMain.MeuDbContextDispose();
        }

        private static async Task comboCidade_CarregarCombo(MeuDbContext MeuDbContext,
                                                            INotifier _notifier,
                                                            Guid EstadoId,
                                                            ComboBox comboCidade)
        {
            Combo_ComboBox.Formatar(comboCidade,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new CidadeController(MeuDbContext, _notifier).ComboEstado(EstadoId, p => p.Nome)));
        }

    }
}
