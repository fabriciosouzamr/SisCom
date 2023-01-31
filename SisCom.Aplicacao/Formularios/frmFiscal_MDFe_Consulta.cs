using Funcoes._Classes;
using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_MDFe_Consulta : FormMain
    {
        const int gridManifestoDocumentoEletronico_Id = 0;
        const int gridManifestoDocumentoEletronico_Chk = 1;
        const int gridManifestoDocumentoEletronico_DataHoraEmissao = 2;
        const int gridManifestoDocumentoEletronico_Numero = 3;
        const int gridManifestoDocumentoEletronico_Status = 4;
        const int gridManifestoDocumentoEletronico_RetornoSefaz = 5;
        const int gridManifestoDocumentoEletronico_Condutor_Nome = 6;
        const int gridManifestoDocumentoEletronico_Condutor_CNPJ_CPF = 7;

        public frmFiscal_MDFe_Consulta(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializa(); 
            
            labelValidade.Text = labelValidade.Text + " " + Fiscal.Certificado_DataExpiracao();
        }
        async Task Inicializa()
        {
            Grid_DataGridView.User_Formatar(gridManifestoDocumentoEletronico, true);
            Grid_DataGridView.User_ColunaAdicionar(gridManifestoDocumentoEletronico, "ID", "ID", Tamanho: 0);
            Grid_DataGridView.User_ColunaAdicionar(gridManifestoDocumentoEletronico, "", "...", Grid_DataGridView.TipoColuna.CheckBox, Tamanho: 30, readOnly: false);
            Grid_DataGridView.User_ColunaAdicionar(gridManifestoDocumentoEletronico, "DataEmissao", "Data Emissão", Tamanho: 150);
            Grid_DataGridView.User_ColunaAdicionar(gridManifestoDocumentoEletronico, "Numero", "Número", Tamanho: 100);
            Grid_DataGridView.User_ColunaAdicionar(gridManifestoDocumentoEletronico, "Status", "Status", Tamanho: 100);
            Grid_DataGridView.User_ColunaAdicionar(gridManifestoDocumentoEletronico, "Retorno Sefaz", "RetornoSefaz", Tamanho: 100);
            Grid_DataGridView.User_ColunaAdicionar(gridManifestoDocumentoEletronico, "NomeCondutor", "Nome Condutor", Tamanho: 150);
            Grid_DataGridView.User_ColunaAdicionar(gridManifestoDocumentoEletronico, "CPFCondutor", "C.P.F. Condutor", Tamanho: 100);

            Carregar(dateDataEmissaoInicial.Value, dateDataEmissaoFinal.Value);
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void botaoEditar_Click(object sender, EventArgs e)
        {
            if (gridManifestoDocumentoEletronico.CurrentRow != null)
            {
                var form = this.ServiceProvider().GetRequiredService<frmFiscal_MDFe>();
                form.manifestoEletronicoDocumentoId = Guid.Parse(gridManifestoDocumentoEletronico.CurrentRow.Cells[gridManifestoDocumentoEletronico_Id].Value.ToString());
                form.ShowDialog(this);
            }
            else
            {
                CaixaMensagem.Informacao("Selecione o manifesto a ser alterado");
            }
        }
        private void botaoTransmitir_Click(object sender, EventArgs e)
        {
            Transmitir();
        }
        async void Transmitir()
        {
            if (gridManifestoDocumentoEletronico.CurrentRow != null)
            {
                ViewModels.EmpresaViewModel empresa;

                using (EmpresaController empresaController = new EmpresaController(this.MeuDbContext(), this._notifier))
                {
                    empresa = await empresaController.GetById(Declaracoes.dados_Empresa_Id);
                }

                await Fiscal.MDFe_Transmitir(Guid.Parse(gridManifestoDocumentoEletronico.CurrentRow.Cells[gridManifestoDocumentoEletronico_Id].Value.ToString()), 
                                             this.MeuDbContext(), this._notifier, empresa);

                gridManifestoDocumentoEletronico.CurrentRow.Cells[gridManifestoDocumentoEletronico_Status].Value = MDFe_Status.Transmitido.GetDescription();
            }
            else
            {
                CaixaMensagem.Informacao("Selecione o manifesto a ser transmitido");
            }
        }
        private async void botaoCancelar_Click(object sender, EventArgs e)
        {
            await Cancelar();
        }
        async Task Cancelar()
        {
            if (gridManifestoDocumentoEletronico.CurrentRow != null)
            {
                string justificativa;
                using (frmTexto frmTexto = new frmTexto())
                {
                    frmTexto.ShowDialog();
                    justificativa = frmTexto.Texto;
                }

                using (ManifestoEletronicoDocumentoController manifestoEletronicoDocumentoController = new ManifestoEletronicoDocumentoController(this.MeuDbContext(), this._notifier))
                {
                    var manifestoEletronicoDocumento = await manifestoEletronicoDocumentoController.PesquisarId(Guid.Parse(gridManifestoDocumentoEletronico.CurrentRow.Cells[gridManifestoDocumentoEletronico_Id].Value.ToString()));

                    Fiscal.Fiscal_ManifestoEletronicoDocumento_Cancelar(manifestoEletronicoDocumento, justificativa);
                    
                    await manifestoEletronicoDocumentoController.Atualizar(manifestoEletronicoDocumento.Id, manifestoEletronicoDocumento);
                }
            }
            else
            {
                CaixaMensagem.Informacao("Selecione o manifesto a ser cancelado");
            }
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
            var form = this.ServiceProvider().GetRequiredService<frmFiscal_MDFe>();
            form.ShowDialog(this);
        }
        private void botaoLimparFiltros_Click(object sender, EventArgs e)
        {
            dateDataEmissaoInicial.Value = DateTime.Now;
            dateDataEmissaoFinal.Value = DateTime.Now;
        }
        private void botaoDesmarcarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridManifestoDocumentoEletronico.Rows)
            {
                row.Cells[gridManifestoDocumentoEletronico_Chk].Value = false;
            }
        }
        private void botaoMarcarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridManifestoDocumentoEletronico.Rows)
            {
                if (row.Cells[gridManifestoDocumentoEletronico_Id].Value != null)
                    row.Cells[gridManifestoDocumentoEletronico_Chk].Value = true;
            }
        }
        async Task<bool> Carregar(DateTime? dataInicial, DateTime? dataFinal)
        {
            IEnumerable<ManifestoEletronicoDocumentoViewModel> manifestoEletronicoDocumentos = new List<ManifestoEletronicoDocumentoViewModel>();

            using (ManifestoEletronicoDocumentoController manifestoEletronicoDocumentoController = new ManifestoEletronicoDocumentoController(this.MeuDbContext(), this._notifier))
            {
                manifestoEletronicoDocumentos = await manifestoEletronicoDocumentoController.ObterTodos(order: o => o.DataHoraEmissao, predicate: p => p.DataHoraEmissao.Date >= dateDataEmissaoInicial.Value.Date &&
                                                                                                                       p.DataHoraEmissao.Date <= dateDataEmissaoFinal.Value.Date);
            }

            Grid_DataGridView.User_LinhaLimpar(gridManifestoDocumentoEletronico);

            foreach (ManifestoEletronicoDocumentoViewModel item in manifestoEletronicoDocumentos)
            {
                Grid_DataGridView.User_LinhaAdicionar(gridManifestoDocumentoEletronico,
                                                                      new Grid_DataGridView.Coluna[] { new Grid_DataGridView.Coluna { Indice = gridManifestoDocumentoEletronico_Id,
                                                                                                                                              Valor = item.Id },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridManifestoDocumentoEletronico_DataHoraEmissao,
                                                                                                                                              Valor = item.DataHoraEmissao },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridManifestoDocumentoEletronico_Numero,
                                                                                                                                              Valor = item.Numero },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridManifestoDocumentoEletronico_Status,
                                                                                                                                              Valor = item.Status.GetDescription() },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridManifestoDocumentoEletronico_RetornoSefaz,
                                                                                                                                              Valor = item.RetornoSefaz },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridManifestoDocumentoEletronico_Condutor_Nome,
                                                                                                                                              Valor = item.Condutor_Nome },
                                                                                                               new Grid_DataGridView.Coluna { Indice = gridManifestoDocumentoEletronico_Condutor_CNPJ_CPF,
                                                                                                                                              Valor = item.Condutor_CPF }});
            }

            return true;
        }

        private void botaoAplicarFiltros_Click(object sender, EventArgs e)
        {
            Carregar(dateDataEmissaoInicial.Value, dateDataEmissaoFinal.Value);
        }

        private async void botaoEncerramento_Click(object sender, EventArgs e)
        {
            if (gridManifestoDocumentoEletronico.CurrentRow != null)
            {
                string justificativa;
                using (frmTexto frmTexto = new frmTexto())
                {
                    frmTexto.ShowDialog();
                    justificativa = frmTexto.Texto;
                }

                using (ManifestoEletronicoDocumentoController manifestoEletronicoDocumentoController = new ManifestoEletronicoDocumentoController(this.MeuDbContext(), this._notifier))
                {
                    var manifestoEletronicoDocumento = await manifestoEletronicoDocumentoController.PesquisarId(Guid.Parse(gridManifestoDocumentoEletronico.CurrentRow.Cells[gridManifestoDocumentoEletronico_Id].Value.ToString()));

                    Fiscal.Fiscal_ManifestoEletronicoDocumento_Encerrar(manifestoEletronicoDocumento);

                    await manifestoEletronicoDocumentoController.Atualizar(manifestoEletronicoDocumento.Id, manifestoEletronicoDocumento);
                }
            }
            else
            {
                CaixaMensagem.Informacao("Selecione o manifesto a ser cancelado");
            }
        }
    }
}
