using Funcoes._Classes;
using Funcoes.Enum;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Controllers;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmComprasConsulta : FormMain
    {
        const int gridNotaFiscalEntradaDataEntrada = 0;
        const int gridNotaFiscalEntradaDataEmissao = 1;
        const int gridNotaFiscalEntradaNotaFiscal = 2;
        const int gridNotaFiscalEntradaFornecedor = 3;
        const int gridNotaFiscalEntradaCFOP = 4;
        const int gridNotaFiscalEntradaUF = 5;
        const int gridNotaFiscalEntradaModelo = 6;
        const int gridNotaFiscalEntradaEmpresa = 7;
        const int gridNotaFiscalEntradaValor = 8;
        const int gridNotaFiscalEntradaId = 9;

        public frmComprasConsulta(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
        }
        private void frmComprasConsulta_Load(object sender, EventArgs e)
        {
            Inicializar();
        }
        private async Task Inicializar()
        {
            Data_DateTimePicker.DateTimePicker_Formatar(dateFiltro_DataInicial);
            Data_DateTimePicker.DateTimePicker_Formatar(dateFiltro_DataFinal);
            Combo_ComboBox.Formatar(comboFiltroTipoData, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_TipoData));
            Combo_ComboBox.Formatar(comboFiltro_Modelo, "", "", ComboBoxStyle.DropDownList, null, typeof(NF_Modelo));
            await Assincrono.TaskAsyncAndAwaitAsync(comboFiltroCFOP_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboFiltroEstado_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboFiltroFornecedor_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboFiltroEmpresa_Carregar());

            Grid_DataGridView.DataGridView_Formatar(gridNotaFiscalEntrada);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "","Data da Entrada");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "","Data de Emissão");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "","Nota Fiscal");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "","Fornecedor");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "","CFOP");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "","UF");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "","Modelo");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "","Empresa");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "","Valor");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNotaFiscalEntrada, "", "Id", Grid_DataGridView.TipoColuna.Texto, 0);

            LimparFiltros();
        }
        private async Task<bool> comboFiltroCFOP_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFiltro_CFOP,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCFOPController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboFiltroFornecedor_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFiltro_Fornecedor,
                                        "ID", "Nome",
                                        ComboBoxStyle.DropDownList,
                                        await (new PessoaController(meuDbContext, this._notifier)).ComboFornecedor(p => p.Nome));
            }

            return true;
        }
        private async Task<bool> comboFiltroEstado_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFiltro_Estado,
                                        "ID", "Codigo",
                                        ComboBoxStyle.DropDownList,
                                        await (new EstadoController(meuDbContext, this._notifier)).Combo(p => p.Codigo));
            }

            return true;
        }
        private async Task<bool> comboFiltroEmpresa_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboFiltro_Empresa,
                                        "ID", "Unidade",
                                        ComboBoxStyle.DropDownList,
                                        await (new EmpresaController(meuDbContext, this._notifier)).Combo(p => p.Unidade));
            }

            return true;
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmComprasInclusao>();
            form.ShowDialog(this);
        }

        private void botaoAplicarFiltros_Click(object sender, EventArgs e)
        {
            Carregar();
       }

        private void botaoLimparFiltros_Click(object sender, EventArgs e)
        {
            LimparFiltros();
        }

        private void LimparFiltros()
        {
            comboFiltroTipoData.SelectedValue = NF_TipoData.Emissao;
            dateFiltro_DataInicial.Value = dateFiltro_DataInicial.MinDate;
            dateFiltro_DataFinal.Value = dateFiltro_DataFinal.MaxDate;
            textFiltro_NotaFiscal.Text = "";
            comboFiltro_Fornecedor.SelectedIndex = -1;
            comboFiltro_Empresa.SelectedIndex = -1;
            comboFiltro_CFOP.SelectedIndex = -1;
            comboFiltro_Estado.SelectedIndex = -1;
            comboFiltro_Modelo.SelectedIndex = -1;
            textFiltro_ChaveAcesso.Text = "";
        }

        private async void Carregar()
        {
            bool valido;

            var notaFiscalentradamercadoriaController = new NotaFiscalEntradaMercadoriaController(this.MeuDbContext(), this._notifier);
            var notaFiscalentradamercadorias = await notaFiscalentradamercadoriaController.ObterTodos();

            foreach (var notaFiscalentradamercadoria in notaFiscalentradamercadorias)
            {
                valido = true;

                if (valido) valido = (((int)comboFiltroTipoData.SelectedValue == NF_TipoData.Emissao.GetHashCode()) && (notaFiscalentradamercadoria.NotaFiscalEntrada.DataEmissao >= dateFiltro_DataInicial.Value) ||
                                      ((int)comboFiltroTipoData.SelectedValue == NF_TipoData.Entrada.GetHashCode()) && (notaFiscalentradamercadoria.NotaFiscalEntrada.DataEntrada >= dateFiltro_DataInicial.Value));
                if (valido) valido = (((int)comboFiltroTipoData.SelectedValue == NF_TipoData.Emissao.GetHashCode()) && (notaFiscalentradamercadoria.NotaFiscalEntrada.DataEmissao <= dateFiltro_DataFinal.Value) ||
                                      ((int)comboFiltroTipoData.SelectedValue == NF_TipoData.Entrada.GetHashCode()) && (notaFiscalentradamercadoria.NotaFiscalEntrada.DataEntrada <= dateFiltro_DataFinal.Value));
                if ((valido) && (textFiltro_NotaFiscal.Text.Trim() != "")) valido = (notaFiscalentradamercadoria.NotaFiscalEntrada.NotaFiscal == textFiltro_NotaFiscal.Text);
                if ((valido) && (comboFiltro_Fornecedor.SelectedIndex != -1)) valido = (notaFiscalentradamercadoria.NotaFiscalEntrada.FornecedorId == (Guid)comboFiltro_Fornecedor.SelectedValue);
                if ((valido) && (comboFiltro_Empresa.SelectedIndex != -1)) valido = (notaFiscalentradamercadoria.NotaFiscalEntrada.EmpresaId == (Guid)comboFiltro_Empresa.SelectedValue);
                if ((valido) && (comboFiltro_CFOP.SelectedIndex != -1)) valido = (notaFiscalentradamercadoria.CFOPId == (Guid)comboFiltro_CFOP.SelectedValue);
                if ((valido) && (comboFiltro_Estado.SelectedIndex != -1)) valido = (notaFiscalentradamercadoria.NotaFiscalEntrada.Fornecedor.Endereco.End_Cidade.EstadoId == (Guid)comboFiltro_Estado.SelectedValue);
                //if ((valido) && (comboFiltro_Modelo.SelectedIndex != -1)) valido = (notaFiscalentradamercadoria.NotaFiscalEntrada.Modelo == (Guid)comboFiltro_Modelo.SelectedValue);
                if ((valido) && (textFiltro_ChaveAcesso.Text.Trim() != "")) valido = (notaFiscalentradamercadoria.NotaFiscalEntrada.CodigoChaveAcesso == textFiltro_ChaveAcesso.Text);

                if (valido)
                {
                    string Estado_Codigo = "";

                    if (notaFiscalentradamercadoria.NotaFiscalEntrada.Fornecedor.Endereco != null)
                        Estado_Codigo = notaFiscalentradamercadoria.NotaFiscalEntrada.Fornecedor.Endereco.End_Cidade.Estado.Codigo;

                    Grid_DataGridView.DataGridView_LinhaAdicionar(gridNotaFiscalEntrada,
                                                                  new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridNotaFiscalEntradaDataEntrada,
                                                                                                                                  Valor = notaFiscalentradamercadoria.NotaFiscalEntrada.DataEntrada },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridNotaFiscalEntradaDataEmissao,
                                                                                                                                  Valor = notaFiscalentradamercadoria.NotaFiscalEntrada.DataEmissao },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridNotaFiscalEntradaNotaFiscal,
                                                                                                                                  Valor = notaFiscalentradamercadoria.NotaFiscalEntrada.NotaFiscal },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridNotaFiscalEntradaFornecedor,
                                                                                                                                  Valor = notaFiscalentradamercadoria.NotaFiscalEntrada.Fornecedor.Nome },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridNotaFiscalEntradaCFOP,
                                                                                                                                  Valor = notaFiscalentradamercadoria.CFOP.Codigo },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridNotaFiscalEntradaUF,
                                                                                                                                  Valor = Estado_Codigo },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridNotaFiscalEntradaModelo,
                                                                                                                                  Valor = "NF-e" },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridNotaFiscalEntradaEmpresa,
                                                                                                                                  Valor = notaFiscalentradamercadoria.NotaFiscalEntrada.Empresa.NomeFantasia },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridNotaFiscalEntradaValor,
                                                                                                                                  Valor = notaFiscalentradamercadoria.NotaFiscalEntrada.ValorNota },
                                                                                                   new Grid_DataGridView.Coluna { Indice = gridNotaFiscalEntradaId,
                                                                                                                                  Valor = notaFiscalentradamercadoria.NotaFiscalEntrada.Id }});
                }
            }
        }

        private void gridNotaFiscalEntrada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                using (frmComprasInclusao form = this.ServiceProvider().GetRequiredService<frmComprasInclusao>())
                {
                    form.ShowDialog(this);
                }

                Close();
            }
        }
    }
}
