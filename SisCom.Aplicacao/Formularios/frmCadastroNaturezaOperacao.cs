using Funcoes._Classes;
using Funcoes._Enum;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroNaturezaOperacao : FormMain
    {
        const int gridNaturezaOperacao_ID = 0;
        const int gridNaturezaOperacao_Nome = 1;
        const int gridNaturezaOperacao_Devolucao = 2;
        const int gridNaturezaOperacao_EntradaSaida = 3;
        const int gridNaturezaOperacao_CFOP = 4;
        const int gridNaturezaOperacao_ICMS = 5;

        bool carregado = false;

        public frmCadastroNaturezaOperacao(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            
        }

        private void frmCadastroNaturezaOperacao_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        async void Inicializa()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(Inicializar());
        }

        async Task<bool> Inicializar()
        {
            List<CodigoComboViewModel> tabelaCFOP;

            using (TabelaCFOPController tabelaCFOPController = new TabelaCFOPController(this.MeuDbContext(), this._notifier))
            {
                tabelaCFOP = (List<CodigoComboViewModel>)await tabelaCFOPController.Combo(null, o => o.Codigo);
            }
            
            Grid_DataGridView.DataGridView_Formatar(gridNaturezaOperacao, AllowUserToAddRows: true);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNaturezaOperacao, "Id", "Id", Tamanho: 0);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNaturezaOperacao, "Nome", "Nome", Tamanho: 300, readOnly: false);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNaturezaOperacao, "Devolucao", "Devolução", Tamanho: 80, Tipo: Grid_DataGridView.TipoColuna.CheckBox, readOnly: false);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNaturezaOperacao, "EntradaSaida", "Entrada/Saída", Tamanho: 80, Tipo: Grid_DataGridView.TipoColuna.ComboBox, dataSource: EnumUtil.ToDataTable(typeof(EntradaSaida)),
                                                                                                                                                                            dataSource_Descricao: "Description",
                                                                                                                                                                            dataSource_Valor: "value",
                                                                                                                                                                            readOnly: false);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNaturezaOperacao, "", "CFOP", Grid_DataGridView.TipoColuna.ComboBox, 80, 0, tabelaCFOP, "Codigo", "ID", readOnly: false);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridNaturezaOperacao, "ICMS", "ICMS", Grid_DataGridView.TipoColuna.Percentual, 80, readOnly: false);

            using (NaturezaOperacaoController naturezaOperacaoController = new NaturezaOperacaoController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<NaturezaOperacaoViewModel> naturezaOperacaoViewModel;

                naturezaOperacaoViewModel = await naturezaOperacaoController.ObterTodos();

                foreach (NaturezaOperacaoViewModel naturezaOperacao in naturezaOperacaoViewModel)
                {
                    try
                    {
                        if (naturezaOperacao.TabelaCFOPId != null)
                        {
                            Grid_DataGridView.DataGridView_LinhaAdicionar(gridNaturezaOperacao,
                                                                            new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_ID,
                                                                                                                                            Valor = naturezaOperacao.Id },
                                                                                                             new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_Nome,
                                                                                                                                            Valor = naturezaOperacao.Nome },
                                                                                                             new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_Devolucao,
                                                                                                                                            Valor = naturezaOperacao.Devolucao },
                                                                                                             new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_EntradaSaida,
                                                                                                                                            Valor = naturezaOperacao.EntradaSaida },
                                                                                                             new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_CFOP,
                                                                                                                                            Valor = naturezaOperacao.TabelaCFOPId },
                                                                                                             new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_ICMS,
                                                                                                                                            Valor = naturezaOperacao.PercentualICMS }});
                        }
                        else
                        {
                            Grid_DataGridView.DataGridView_LinhaAdicionar(gridNaturezaOperacao,
                                                                            new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_ID,
                                                                                                                                            Valor = naturezaOperacao.Id },
                                                                                                             new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_Nome,
                                                                                                                                            Valor = naturezaOperacao.Nome },
                                                                                                             new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_Devolucao,
                                                                                                                                            Valor = naturezaOperacao.Devolucao },
                                                                                                             new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_EntradaSaida,
                                                                                                                                            Valor = naturezaOperacao.EntradaSaida },
                                                                                                             new Grid_DataGridView.Coluna { Indice = gridNaturezaOperacao_ICMS,
                                                                                                                                            Valor = naturezaOperacao.PercentualICMS }});
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            carregado = true;

            return true;
        }

        private void gridNaturezaOperacao_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (carregado) Gravar(e.RowIndex);
        }

        async Task Gravar(int rowIndex)
        {
            if ((rowIndex > -1) && (carregado))
            {
                NaturezaOperacaoViewModel naturezaOperacaoViewModel = new NaturezaOperacaoViewModel();

                naturezaOperacaoViewModel.Nome = Texto.NuloString(gridNaturezaOperacao.Rows[rowIndex].Cells[gridNaturezaOperacao_Nome].Value);
                if (gridNaturezaOperacao.Rows[rowIndex].Cells[gridNaturezaOperacao_CFOP].Value != null)
                naturezaOperacaoViewModel.TabelaCFOPId = (Guid)gridNaturezaOperacao.Rows[rowIndex].Cells[gridNaturezaOperacao_CFOP].Value;
                if (gridNaturezaOperacao.Rows[rowIndex].Cells[gridNaturezaOperacao_EntradaSaida].Value != null)
                    naturezaOperacaoViewModel.EntradaSaida = (EntradaSaida)gridNaturezaOperacao.Rows[rowIndex].Cells[gridNaturezaOperacao_EntradaSaida].Value;
                naturezaOperacaoViewModel.PercentualICMS = Funcoes._Classes.Funcao.NuloParaValorD(gridNaturezaOperacao.Rows[rowIndex].Cells[gridNaturezaOperacao_EntradaSaida].Value);
                naturezaOperacaoViewModel.Devolucao = (bool)gridNaturezaOperacao.Rows[rowIndex].Cells[gridNaturezaOperacao_Devolucao].Value;

                using (NaturezaOperacaoController naturezaOperacaoController = new NaturezaOperacaoController(this.MeuDbContext(), this._notifier))
                {
                    if (gridNaturezaOperacao.Rows[rowIndex].Cells[gridNaturezaOperacao_ID].Value == null)
                    { 
                        naturezaOperacaoViewModel.Id = Guid.NewGuid();
                        gridNaturezaOperacao.Rows[rowIndex].Cells[gridNaturezaOperacao_ID].Value = naturezaOperacaoViewModel.Id;
                        await naturezaOperacaoController.Adicionar(naturezaOperacaoViewModel);
                    }
                    else
                    { 
                        naturezaOperacaoViewModel.Id = Guid.Parse(gridNaturezaOperacao.Rows[rowIndex].Cells[gridNaturezaOperacao_ID].Value.ToString());
                        await naturezaOperacaoController.Atualizar(naturezaOperacaoViewModel.Id, naturezaOperacaoViewModel);
                    }
                }

            }
        }
    }
}
