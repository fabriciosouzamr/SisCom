using Funcoes._Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmFiscal_NotaFiscal_Impostos : FormMain
    {
        public NotaFiscalMercadoriaDetalhamentoImposto notaFiscalMercadoriaDetalhamentoImposto;
        public string Produto = "";
        public decimal ValorTotal = 0;

        public frmFiscal_NotaFiscal_Impostos(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            if (notaFiscalMercadoriaDetalhamentoImposto == null)
                notaFiscalMercadoriaDetalhamentoImposto = new NotaFiscalMercadoriaDetalhamentoImposto();

            notaFiscalMercadoriaDetalhamentoImposto.Preco = numericPreco.Value;
            notaFiscalMercadoriaDetalhamentoImposto.ValorBaseCalculo = numericValorBaseCalculo.Value;
            notaFiscalMercadoriaDetalhamentoImposto.AliquotaICMS = numericAliquotaICMS.Value;
            notaFiscalMercadoriaDetalhamentoImposto.ValorICMS = numericValorICMS.Value;
            notaFiscalMercadoriaDetalhamentoImposto.AliquotaReducao = numericAliquotaReducao.Value;
            notaFiscalMercadoriaDetalhamentoImposto.ValorBaseSubstituicaoTributaria = numericValorBaseSubstituicaoTributaria.Value;
            notaFiscalMercadoriaDetalhamentoImposto.ValorSubstituicaoTributaria = numericValorSubstituicaoTributaria.Value;
            notaFiscalMercadoriaDetalhamentoImposto.ValorAdicional = numericValorAdicional.Value;
            notaFiscalMercadoriaDetalhamentoImposto.AliquotaAdicional = numericAliquotaAdicional.Value;
            notaFiscalMercadoriaDetalhamentoImposto.CSTIPI = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboCSTIPI);
            notaFiscalMercadoriaDetalhamentoImposto.ValorBaseIPI = numericValorBaseIPI.Value;
            notaFiscalMercadoriaDetalhamentoImposto.AliquotaIPI = numericAliquotaIPI.Value;
            notaFiscalMercadoriaDetalhamentoImposto.ValorIPI = numericValorIPI.Value;
            notaFiscalMercadoriaDetalhamentoImposto.CSTPIS = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboCSTPIS);
            if (Combo_ComboBox.Selecionado(comboAliquotaPIS)) { notaFiscalMercadoriaDetalhamentoImposto.AliquotaPIS = (decimal)comboAliquotaPIS.SelectedValue; }
            else { notaFiscalMercadoriaDetalhamentoImposto.AliquotaPIS = 0; }
            notaFiscalMercadoriaDetalhamentoImposto.CSTCOFINS = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboCSTCOFINS);
            if (Combo_ComboBox.Selecionado(comboAliquotaCOFINS)) { notaFiscalMercadoriaDetalhamentoImposto.AliquotaCOFINS = (decimal)comboAliquotaCOFINS.SelectedValue; }
            else { notaFiscalMercadoriaDetalhamentoImposto.AliquotaCOFINS = 0; }
            notaFiscalMercadoriaDetalhamentoImposto.BaseCalculoFCP = numericBaseCalculoFCP.Value;
            notaFiscalMercadoriaDetalhamentoImposto.AliquotaFCP = numericAliquotaFCP.Value;
            notaFiscalMercadoriaDetalhamentoImposto.ValorFCP = numericValorFCP.Value;
            notaFiscalMercadoriaDetalhamentoImposto.NumeroPedidoCompra = textNumeroPedidoCompra.Text;
            notaFiscalMercadoriaDetalhamentoImposto.ItemPedidoCompra = textItemPedidoCompra.Text;

            Close();
        }
        private void numericAliquotaICMS_ValueChanged(object sender, EventArgs e)
        {
            CalcularValorICMS();
        }
        void CalcularValorICMS()
        {
            if (numericValorBaseCalculo.Value == 0)
            { numericValorICMS.Value = 0; }
            else
            { numericValorICMS.Value = Valor.Percentagem(numericValorBaseCalculo.Value, numericAliquotaICMS.Value); }
        }
        private void numericValorICMS_ValueChanged(object sender, EventArgs e)
        {
            if (numericValorBaseCalculo.Value == 0)
            { numericAliquotaICMS.Value = 0; }
            else
            { numericAliquotaICMS.Value = numericValorICMS.Value / numericValorBaseCalculo.Value * 100 ; }
        }
        async Task Inicializa()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(InicializarCombos());
        }
        public async Task FormatarAsync()
        {
            labelProduto.Text = Produto;
            numericPreco.Value = ValorTotal;

            await Inicializa();

            if (notaFiscalMercadoriaDetalhamentoImposto != null)
            {
                numericPreco.Value = notaFiscalMercadoriaDetalhamentoImposto.Preco;
                numericValorBaseCalculo.Value = notaFiscalMercadoriaDetalhamentoImposto.ValorBaseCalculo;
                numericAliquotaICMS.Value = notaFiscalMercadoriaDetalhamentoImposto.AliquotaICMS;
                numericValorICMS.Value = notaFiscalMercadoriaDetalhamentoImposto.ValorICMS; 
                numericAliquotaReducao.Value = notaFiscalMercadoriaDetalhamentoImposto.AliquotaReducao; 
                numericValorBaseSubstituicaoTributaria.Value = notaFiscalMercadoriaDetalhamentoImposto.ValorBaseSubstituicaoTributaria;
                numericValorSubstituicaoTributaria.Value = notaFiscalMercadoriaDetalhamentoImposto.ValorSubstituicaoTributaria;
                numericValorAdicional.Value = notaFiscalMercadoriaDetalhamentoImposto.ValorAdicional; 
                numericAliquotaAdicional.Value = notaFiscalMercadoriaDetalhamentoImposto.AliquotaAdicional;
                if (!Funcao.Nulo(notaFiscalMercadoriaDetalhamentoImposto.CSTIPI)) comboCSTIPI.SelectedValue = notaFiscalMercadoriaDetalhamentoImposto.CSTIPI;
                numericValorBaseIPI.Value = notaFiscalMercadoriaDetalhamentoImposto.ValorBaseIPI;
                numericAliquotaIPI.Value = notaFiscalMercadoriaDetalhamentoImposto.AliquotaIPI;
                numericValorIPI.Value = notaFiscalMercadoriaDetalhamentoImposto.ValorIPI;
                if (!Funcao.Nulo(notaFiscalMercadoriaDetalhamentoImposto.CSTPIS)) comboCSTIPI.SelectedValue = notaFiscalMercadoriaDetalhamentoImposto.CSTPIS;
                comboAliquotaPIS.Text = notaFiscalMercadoriaDetalhamentoImposto.AliquotaPIS.ToString();
                if (!Funcao.Nulo(notaFiscalMercadoriaDetalhamentoImposto.CSTCOFINS)) comboCSTCOFINS.SelectedValue = notaFiscalMercadoriaDetalhamentoImposto.CSTCOFINS;
                comboAliquotaCOFINS.Text = notaFiscalMercadoriaDetalhamentoImposto.AliquotaCOFINS.ToString();
                numericBaseCalculoFCP.Value = notaFiscalMercadoriaDetalhamentoImposto.BaseCalculoFCP;
                numericAliquotaFCP.Value = notaFiscalMercadoriaDetalhamentoImposto.AliquotaFCP;
                numericValorFCP.Value = notaFiscalMercadoriaDetalhamentoImposto.ValorFCP;
                textNumeroPedidoCompra.Text = notaFiscalMercadoriaDetalhamentoImposto.NumeroPedidoCompra;
                textItemPedidoCompra.Text = notaFiscalMercadoriaDetalhamentoImposto.ItemPedidoCompra;
            }
        }
        private async Task<bool> InicializarCombos()
        {
            await Assincrono.TaskAsyncAndAwaitAsync(comboCSTIPI_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboCSTPIS_Carregar());
            await Assincrono.TaskAsyncAndAwaitAsync(comboCSTCOFINS_Carregar());

            return true;
        }
        private async Task<bool> comboCSTIPI_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboCSTIPI,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCST_IPIController(this.MeuDbContext(), this._notifier)).ComboCodigo(Funcoes._Enum.EntradaSaida.Saida));
            }

            return true;
        }
        private async Task<bool> comboCSTPIS_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboCSTPIS,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCST_PIS_COFINSController(this.MeuDbContext(), this._notifier)).ComboCodigoUsaSaida());
            }

            return true;
        }
        private async Task<bool> comboCSTCOFINS_Carregar()
        {
            using (MeuDbContext meuDbContext = this.MeuDbContext())
            {
                Combo_ComboBox.Formatar(comboCSTCOFINS,
                                        "ID", "Descricao",
                                        ComboBoxStyle.DropDownList,
                                        await (new TabelaCST_PIS_COFINSController(this.MeuDbContext(), this._notifier)).ComboCodigoUsaSaida());
            }

            return true;
        }
        private void numericValorBaseCalculo_ValueChanged(object sender, EventArgs e)
        {
            CalcularValorICMS();
        }
    }
}
