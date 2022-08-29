using Funcoes._Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroObservacao : FormMain
    {
        const int gridObservacao_ID = 0;
        const int gridObservacao_Codigo = 1;
        const int gridObservacao_Descricao = 2;
        const int gridObservacao_Tipo = 3;

        public frmCadastroObservacao(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializar();
        }

        async void Inicializar()
        {
            var row = EnumUtil.ToDataTable(typeof(TipoObservacao));

            Grid_DataGridView.DataGridView_Formatar(gridObservacao);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridObservacao, "", "ID", Tamanho: 0);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridObservacao, "", "Código");
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridObservacao, "", "Descrição", readOnly: false, Tamanho: 200, wordWrap: true);
            Grid_DataGridView.DataGridView_ColunaAdicionar(gridObservacao, "", "Tipo", Tipo: Grid_DataGridView.TipoColuna.ComboBox,
                                                                                       dataSource: EnumUtil.ToDataTable(typeof(TipoObservacao)), 
                                                                                       dataSource_Valor: "Value", 
                                                                                       dataSource_Descricao: "Description", 
                                                                                       readOnly: false, 
                                                                                       Tamanho: 200);

            using (ObservacaoController observacaoController = new ObservacaoController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<ObservacaoViewModel> ret = await observacaoController.ObterTodos();

                foreach (var item in ret)
                {
                    Grid_DataGridView.DataGridView_LinhaAdicionar(gridObservacao,
                                                                  new Grid_DataGridView.Coluna[] {new Grid_DataGridView.Coluna { Indice = gridObservacao_ID,
                                                                                                                                 Valor = item.Id },
                                                                                                  new Grid_DataGridView.Coluna { Indice = gridObservacao_Codigo,
                                                                                                                                 Valor = item.Codigo.ToString() },
                                                                                                  new Grid_DataGridView.Coluna { Indice = gridObservacao_Descricao,
                                                                                                                                 Valor = item.Descricao },
                                                                                                  new Grid_DataGridView.Coluna { Indice = gridObservacao_Tipo,
                                                                                                                                 Valor = item.TipoObservacao }});
                }
            }
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {
            gridObservacao.Rows.Add();
        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            if ((gridObservacao.CurrentRow != null) && (gridObservacao.CurrentRow.Index > -1))
            {
                Excluir(Guid.Parse(gridObservacao.CurrentRow.Cells[gridObservacao_ID].Value.ToString()));
            }
            else
            {
                CaixaMensagem.Informacao("Selecione a linha a ser excluída");
            }
        }

        async void Excluir(Guid id)
        {
            using (ObservacaoController observacaoController = new ObservacaoController(this.MeuDbContext(), this._notifier))
            {
                await observacaoController.Excluir(id);
            }
        }

        async Task<bool> Gravar()
        {
            using (ObservacaoController observacaoController = new ObservacaoController(this.MeuDbContext(), this._notifier))
            {
                foreach (DataGridViewRow row in gridObservacao.Rows)
                {
                    ObservacaoViewModel observacao = new ObservacaoViewModel();
                    observacao.Descricao = row.Cells[gridObservacao_Descricao].Value.ToString();
                    observacao.TipoObservacao = ((TipoObservacao)row.Cells[gridObservacao_Tipo].Value);

                    if (row.Cells[gridObservacao_ID].Value == null)
                    {
                        observacao = await observacaoController.Adicionar(observacao);
                        row.Cells[gridObservacao_ID].Value = observacao.Id.ToString();
                        row.Cells[gridObservacao_Codigo].Value = observacao.Codigo.ToString();
                    }
                    else
                    {
                        observacao.Id = Guid.Parse(row.Cells[gridObservacao_ID].Value.ToString());
                        await observacaoController.Atualizar(observacao.Id, observacao);
                    }
                }
            }

            return true;
        }            

        async void Fechar()
        {
            await Gravar();
        }

        private void frmCadastroObservacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool Valido = true;

            foreach (DataGridViewRow row in gridObservacao.Rows)
            {
                if ((Texto.NuloString(row.Cells[gridObservacao_Descricao].Value) == "") || (Texto.NuloString(row.Cells[gridObservacao_Tipo].Value) == ""))
                {
                    CaixaMensagem.Informacao("Informe a descrição de todas as observações");
                    Valido = false;
                    break;
                }
                if ((row.Cells[gridObservacao_Tipo].Value.ToString() == ""))
                {
                    CaixaMensagem.Informacao("Selecione o tipo de todas as observações");
                    Valido = false;
                    break;
                }
            }

            if (Valido)
            { Fechar(); }
            else
            { e.Cancel = true; }
        }
    }
}