﻿using Funcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
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
        const int gridManifestoDocumentoEletronico_TipoEmissao = 4;
        const int gridManifestoDocumentoEletronico_Condutor_Nome = 5;
        const int gridManifestoDocumentoEletronico_Condutor_CNPJ_CPF = 6;

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
            Grid_DataGridView.User_ColunaAdicionar(gridManifestoDocumentoEletronico, "TipoEmissao", "Tipo de Emissão", Tamanho: 100);
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

        }
        private void botaoTransmitir_Click(object sender, EventArgs e)
        {
            if (gridManifestoDocumentoEletronico.CurrentRow != null)
            {
                Transmitir(Guid.Parse(gridManifestoDocumentoEletronico.CurrentRow.Cells[gridManifestoDocumentoEletronico_Id].Value.ToString()));
            }
        }
        async void Transmitir(Guid id)
        {
            EmpresaViewModel empresa;
            ManifestoEletronicoDocumentoViewModel manifestoEletronicoDocumento;

            using (EmpresaController empresaController = new EmpresaController(this.MeuDbContext(), this._notifier))
            {
                empresa = await empresaController.GetById(Declaracoes.dados_Empresa_Id);
            }
            using (ManifestoEletronicoDocumentoController manifestoEletronicoDocumentoController = new ManifestoEletronicoDocumentoController(this.MeuDbContext(), this._notifier))
            {
                manifestoEletronicoDocumento = await manifestoEletronicoDocumentoController.PesquisarId(id);
            }

            Fiscal.Fiscal_ManifestoEletronicoDocumento_Transmitir(empresa, manifestoEletronicoDocumento);
        }
        private void botaoCancelar_Click(object sender, EventArgs e)
        {

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
            using (ManifestoEletronicoDocumentoController manifestoEletronicoDocumentoController = new ManifestoEletronicoDocumentoController(this.MeuDbContext(), this._notifier))
            {
                await manifestoEletronicoDocumentoController.ObterTodos(order: o => o.DataHoraEmissao, predicate: p => p.DataHoraEmissao.Date >= dateDataEmissaoInicial.Value.Date &&
                                                                                                                       p.DataHoraEmissao.Date <= dateDataEmissaoFinal.Value.Date);
            }

            return true;
        }

        private void botaoAplicarFiltros_Click(object sender, EventArgs e)
        {
            Carregar(dateDataEmissaoInicial.Value, dateDataEmissaoFinal.Value);
        }
    }
}
