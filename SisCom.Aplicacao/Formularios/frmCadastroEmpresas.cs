using Funcoes._Classes;
using Funcoes._Enum;
using Funcoes.Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Entidade.Enum;
using SisCom.Entidade.Modelos;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroEmpresas : FormMain
    {
        ViewModels.EmpresaViewModel empresa = null;
        bool editado = false;
        string serialNumber = "";

        public frmCadastroEmpresas(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        #region Funcoes
        private async Task Inicializar()
        {
            Combo_ComboBox.Formatar(comboRegimeTributario, "", "", ComboBoxStyle.DropDownList, null, typeof(RegimeTributario));
            Combo_ComboBox.Formatar(comboNFEAmbiente, "", "", ComboBoxStyle.DropDownList, null, typeof(AmbienteSistemas));
            Combo_ComboBox.Formatar(comboNFELayout, "", "", ComboBoxStyle.DropDownList, null, typeof(NFE_Layout));
            Combo_ComboBox.Formatar(comboSpedGrupoInventario, "", "", ComboBoxStyle.DropDownList, null, typeof(Sped_TipoGeracaoInventario));
            Combo_ComboBox.Formatar(comboMDFeAmbiente, "", "", ComboBoxStyle.DropDownList, null, typeof(AmbienteSistemas));
            Combo_ComboBox.Formatar(comboMDFeTipoEmissor, "", "", ComboBoxStyle.DropDownList, null, typeof(TipoEmissor));
            Combo_ComboBox.Formatar(comboNuvemFiscalAmbienteWebService, "", "", ComboBoxStyle.DropDownList, null, typeof(AmbienteSistemas));

            Limpar();

            await comboEstado_Carregar();
            await comboPesquisa_Carregar();
        }
        private void Limpar()
        {
            empresa = new ViewModels.EmpresaViewModel();
            empresa.Ativo = true;
            comboPesquisa.SelectedIndex = -1;
            labelEmpresa.Text = "";
            textUnidade.Text = "";
            textRazaoSocial.Text = "";
            textNomeFantasia.Text = "";
            maskedCPFCNPJ.Text = "";
            textInscricaoMunicipal.Text = "";
            textInscricaoEstadual.Text = "";
            textInscricaoEstadualSubTributaria.Text = "";
            textEnderecoLogradouro.Text = "";
            textNumero.Text = "";
            textEnderecoBairro.Text = "";
            maskedEnderecoCEP.Text = "";
            comboEnderecoUF.SelectedIndex = -1;
            comboEnderecoCidade.SelectedIndex = -1;
            textTelefone.Text = "";
            textEmail.Text = "";
            comboRegimeTributario.SelectedIndex = -1;
            numericCreditoSimplesNacional.Value = 0;
            comboNFEAmbiente.SelectedIndex = -1;
            comboNFELayout.SelectedIndex = -1;
            textNFESerie.Text = "";
            textNFEVersaoEmissor.Text = "";
            textCaminhoLogomarca.Text = "";
            pictureLogomarca.Image = null;
            comboSpedGrupoInventario.SelectedIndex = -1;
            textMDFeSerie.Text = "";
            comboMDFeAmbiente.SelectedIndex = -1;
            comboMDFeTipoEmissor.SelectedIndex = -1;
            textNuvemFiscalCertificado.Text = "";
            checkUtilizarNuvemFiscal.Checked = false;
            comboNuvemFiscalAmbienteWebService.SelectedIndex = -1;
            botaoUnidadeAtivo.Text = "Desativar Unidade";
            dateUnidadeDesativada.Visible = false;
            editado = false;
        }
        private async void Excluir()
        {
            var empresaController = new EmpresaController(this.MeuDbContext(), this._notifier);
            await empresaController.Excluir(empresa.Id);
            empresaController = null;
            this.MeuDbContextDispose();

            Limpar();
        }
        private async void CarregarDados()
        {
            if (empresa != null)
            {
                if (empresa.Endereco == null)
                    empresa.Endereco = new Endereco();

                labelEmpresa.Text = empresa.Unidade;
                textUnidade.Text = empresa.Unidade;
                textRazaoSocial.Text = empresa.RazaoSocial;
                textNomeFantasia.Text = empresa.NomeFantasia;
                maskedCPFCNPJ.Text = empresa.CNPJ;
                textInscricaoMunicipal.Text = Funcao.NuloParaString(empresa.InscricaoMunicipal);
                textInscricaoEstadual.Text = Funcao.NuloParaString(empresa.InscricaoEstadual);
                textInscricaoEstadualSubTributaria.Text = Funcao.NuloParaString(empresa.InscricaoEstadual_SubTributaria);
                textEnderecoLogradouro.Text = Funcao.NuloParaString(empresa.Endereco.End_Logradouro);
                textNumero.Text = Funcao.NuloParaString(empresa.Endereco.End_Numero);
                textEnderecoBairro.Text = Funcao.NuloParaString(empresa.Endereco.End_Bairro);
                maskedEnderecoCEP.Text = Funcao.NuloParaString(empresa.Endereco.End_CEP);
                textTelefone.Text = Funcao.NuloParaString(empresa.Telefone);
                textEmail.Text = Funcao.NuloParaString(empresa.EMail);
                if (!Funcao.Nulo(empresa.RegimeTributario)) comboRegimeTributario.SelectedValue = empresa.RegimeTributario;
                numericCreditoSimplesNacional.Value = Funcao.NuloParaNumero(empresa.CreditoSimplesNacional);
                if (!Funcao.Nulo(empresa.NFE_Ambiente)) comboNFEAmbiente.SelectedValue = empresa.NFE_Ambiente;
                if (!Funcao.Nulo(empresa.NFE_Layout)) comboNFELayout.SelectedValue = empresa.NFE_Layout;
                textNFESerie.Text = Funcao.NuloParaString(empresa.NFE_Serie);
                textNFEVersaoEmissor.Text = Funcao.NuloParaString(empresa.NFE_VersaoEmissor);
                textCaminhoLogomarca.Text = Funcao.NuloParaString(empresa.PathLogomarca);
                if (!Imagem.NuloImagem(empresa.ImagemLogomarca)) pictureLogomarca.Image = Imagem.ByteArrayToImage(empresa.ImagemLogomarca);
                if (!Funcao.Nulo(empresa.Sped_TipoGeracaoInventario)) comboSpedGrupoInventario.SelectedValue = empresa.Sped_TipoGeracaoInventario;
                textMDFeSerie.Text = Funcao.NuloParaString(empresa.MDFe_Serie);
                if (!Funcao.Nulo(empresa.MDFe_Ambiente)) comboMDFeAmbiente.SelectedValue = empresa.MDFe_Ambiente;
                if (!Funcao.Nulo(empresa.MDFe_TipoEmirssor)) comboMDFeTipoEmissor.SelectedValue = empresa.MDFe_TipoEmirssor;
                textNuvemFiscalCertificado.Text = Funcao.NuloParaString(empresa.NuvemFiscal_Certificado);
                checkUtilizarNuvemFiscal.Checked = empresa.NuvemFiscal_Usar;
                if (!Funcao.Nulo(empresa.MDFe_TipoEmirssor)) comboNuvemFiscalAmbienteWebService.SelectedValue = empresa.NuvemFiscal_AmbienteWebService;

                if (!Funcao.Nulo(empresa.Endereco.End_CidadeId)) Combo_ComboBox.ComboCidade_Carregar(this._serviceProvider,
                                                                                                     this._dbCtxFactory,
                                                                                                     this._notifier,
                                                                                                     empresa.Endereco.End_CidadeId,
                                                                                                     comboEnderecoCidade,
                                                                                                     comboEnderecoUF,
                                                                                                     null);
                this.MeuDbContextDispose();

                editado = false;
            }
        }
        private async void AdicionarEmpresa()
        {
            if (!Funcoes._Classes.Validacao.CNPJ_Valido(empresa.CNPJ))
            {
                CaixaMensagem.Informacao("C.N.P.J. Inválido");
                return;
            }
            if (!Combo_ComboBox.Selecionado(comboRegimeTributario))
            {
                CaixaMensagem.Informacao("Selecione o regime tributário");
                return;
            }
            var empresaController = new EmpresaController(this.MeuDbContext(), this._notifier);

            if (empresa.Id != Guid.Empty)
            {
                await empresaController.Atualizar(empresa.Id, empresa);
            }
            else
            {
                empresa = (await empresaController.Adicionar(empresa));
            }

            if (empresa.Id == Declaracoes.dados_Empresa_Id)
            {
                Declaracoes.dados_Empresa_EstadoId = empresa.Endereco.End_Cidade.EstadoId;
                Declaracoes.dados_Empresa_CodigoEstado = empresa.Endereco.End_Cidade.Estado.Codigo;
                Declaracoes.dados_Empresa_SerialNumber = empresa.NuvemFiscal_SerialNumber;
                Declaracoes.dados_Empresa_CNPJ = empresa.CNPJ;
                if (empresa.RegimeTributario != null)
                Declaracoes.dados_Empresa_RegimeTributario = (RegimeTributario)empresa.RegimeTributario;
            }

            empresaController = null;
            await comboPesquisa_Carregar();

            editado = false;

            this.MeuDbContextDispose();
        }
        private void textoTextChanged(object sender, EventArgs e)
        {
            editado = true;
        }
        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            editado = true;
        }
        private async void CarregarDados_Pesquisa()
        {
            var empresaViewModel = await (new EmpresaController(this.MeuDbContext(), this._notifier)).GetById((Guid)comboPesquisa.SelectedValue);

            if (empresaViewModel != null)
            {
                empresa = empresaViewModel;
                CarregarDados();
            }
        }
        #endregion
        #region Combos
        private async Task comboEstado_Carregar()
        {
            Combo_ComboBox.Formatar(comboEnderecoUF,
                                    "ID", "Codigo",
                                    ComboBoxStyle.DropDownList,
                                    await (new EstadoController(this.MeuDbContext(), this._notifier)).ComboCodigo(p => p.Nome));
            this.MeuDbContextDispose();
        }
        private async Task comboPesquisa_Carregar()
        {
            Combo_ComboBox.Formatar(comboPesquisa,
                                    "ID", "Unidade",
                                    ComboBoxStyle.DropDownList,
                                    await (new EmpresaController(this.MeuDbContext(), this._notifier)).Combo());
            this.MeuDbContextDispose();
        }
        private async Task comboCidade_Carregar(Guid EstadoId)
        {
            Combo_ComboBox.Formatar(comboEnderecoCidade,
                                    "ID", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new CidadeController(this.MeuDbContext(), this._notifier)).ComboEstado(EstadoId, p => p.Nome));
            this.MeuDbContextDispose();
        }
        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_ComboBox.Selecionado(comboEnderecoUF))
            {
                comboCidade_Carregar(Guid.Parse(comboEnderecoUF.SelectedValue.ToString()));
            }
        }
        private void comboEnderecoUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboEnderecoUF.SelectedIndex != -1) && (comboEnderecoUF.Tag != Declaracoes.ComboBox_Carregando))
            {
                if (Combo_ComboBox.Selecionado(comboEnderecoUF))
                {
                    comboCidade_Carregar(Guid.Parse(comboEnderecoUF.SelectedValue.ToString()));
                }
            }
        }
        private void comboPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboPesquisa.SelectedIndex != -1) && (comboPesquisa.Tag != Declaracoes.ComboBox_Carregando))
            {
                CarregarDados_Pesquisa();
            }
        }
        #endregion
        #region Botoes
        private void botaoExcluir_ClickAsync(object sender, EventArgs e)
        {
            if (!FuncaoInterna.NuloModelView(empresa))
            {
                if (CaixaMensagem.Perguntar("Deseja excluir essa empresa?"))
                {
                    Excluir();
                }
            }
            else
            {
                CaixaMensagem.Informacao("Selecione o cliente que deseja excluir;");
            }
        }
        private void botaoNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void botaotEndrecoCEP_Click(object sender, EventArgs e)
        {
            Forms.formBuscarCEPCarregar(this._serviceProvider,
                                        this._dbCtxFactory,
                                        this._notifier,
                                        maskedEnderecoCEP.Text,
                                        textEnderecoLogradouro,
                                        textEnderecoBairro,
                                        comboEnderecoUF,
                                        comboEnderecoCidade,
                                        null);
        }
        private void botaoBuscarLogomarca_Click(object sender, EventArgs e)
        {
            Imagem.CarregarFoto(pictureLogomarca);
        }
        private void botaoRetirarLogomarca_Click(object sender, EventArgs e)
        {
            textCaminhoLogomarca.Text = "";
            pictureLogomarca.Image = null;
        }
        private void botaoSelecionarCertificado_Click(object sender, EventArgs e)
        {
            string completo = "";

            NuvemFiscal.SelecionarCertificado(ref serialNumber, ref completo);

            textNuvemFiscalCertificado.Text = completo;
        }
        private void botaoGravar_Click(object sender, EventArgs e)
        {

            if (!Validacao.CPFCNPJ_Valido(TipoPessoa.Juridica, Funcoes._Classes.Texto.SomenteNumero(maskedCPFCNPJ.Text)))
            {
                CaixaMensagem.Informacao("Informe o C.N.P.J!");
                return;
            }
            if (textNomeFantasia.Text.Trim() == string.Empty)
            {
                CaixaMensagem.Informacao("Informe o nome de fantasia!");
                return;
            }
            if (!Validacao.CEP_Valido(maskedEnderecoCEP.Text) && (Funcoes._Classes.Texto.SomenteNumero(maskedEnderecoCEP.Text) != ""))
            {
                CaixaMensagem.Informacao("Infome um C.E.P. válido!");
                return;
            }

            if (empresa == null)
                empresa = new ViewModels.EmpresaViewModel();
            if (empresa.Endereco == null)
                empresa.Endereco = new Endereco();

            empresa.Unidade = Funcao.StringVazioParaNulo(textUnidade.Text);
            empresa.RazaoSocial = Funcao.StringVazioParaNulo(textRazaoSocial.Text);
            empresa.NomeFantasia = Funcao.StringVazioParaNulo(textNomeFantasia.Text);
            empresa.CNPJ = Funcao.StringVazioParaNulo(Funcoes._Classes.Texto.SomenteNumero(maskedCPFCNPJ.Text));
            empresa.InscricaoMunicipal = Funcao.StringVazioParaNulo(textInscricaoMunicipal.Text);
            empresa.InscricaoEstadual = Funcao.StringVazioParaNulo(textInscricaoEstadual.Text);
            empresa.InscricaoEstadual_SubTributaria = Funcao.StringVazioParaNulo(textInscricaoEstadualSubTributaria.Text);
            empresa.Endereco.End_Logradouro = Funcao.StringVazioParaNulo(textEnderecoLogradouro.Text);
            empresa.Endereco.End_Numero = Funcao.StringVazioParaNulo(textNumero.Text);
            empresa.Endereco.End_Bairro = Funcao.StringVazioParaNulo(textEnderecoBairro.Text);
            empresa.Endereco.End_CEP = Funcao.StringVazioParaNulo(Funcoes._Classes.Texto.SomenteNumero(maskedEnderecoCEP.Text));
            empresa.Endereco.End_CidadeId = Combo_ComboBox.NaoSelecionadoParaNuloGuid(comboEnderecoCidade);
            empresa.Telefone = Funcao.StringVazioParaNulo(textTelefone.Text);
            empresa.EMail = Funcao.StringVazioParaNulo(textEmail.Text);
            if (Combo_ComboBox.Selecionado(comboRegimeTributario)) { empresa.RegimeTributario = (RegimeTributario)comboRegimeTributario.SelectedValue; } else { empresa.RegimeTributario = null; }
            empresa.CreditoSimplesNacional = Funcao.NuloParaValor(numericCreditoSimplesNacional.Value);
            if (Combo_ComboBox.Selecionado(comboNFEAmbiente)) { empresa.NFE_Ambiente = (AmbienteSistemas)comboNFEAmbiente.SelectedValue; } else { empresa.NFE_Ambiente = null; }
            if (Combo_ComboBox.Selecionado(comboNFELayout)) { empresa.NFE_Layout = (NFE_Layout)comboNFELayout.SelectedValue; } else { empresa.NFE_Layout = null; }
            empresa.NFE_Serie = Funcao.StringVazioParaNulo(textNFESerie.Text);
            empresa.NFE_VersaoEmissor = Funcao.StringVazioParaNulo(textNFEVersaoEmissor.Text);
            empresa.PathLogomarca = Funcao.StringVazioParaNulo(textCaminhoLogomarca.Text);
            empresa.ImagemLogomarca = Imagem.ImageToByteArray(pictureLogomarca.Image);
            if (Combo_ComboBox.Selecionado(comboSpedGrupoInventario)) { empresa.Sped_TipoGeracaoInventario = (Sped_TipoGeracaoInventario)comboSpedGrupoInventario.SelectedValue; } else { empresa.Sped_TipoGeracaoInventario = null; }
            empresa.MDFe_Serie = Funcao.StringVazioParaNulo(textMDFeSerie.Text);
            if (Combo_ComboBox.Selecionado(comboMDFeAmbiente)) { empresa.MDFe_Ambiente = (AmbienteSistemas)comboMDFeAmbiente.SelectedValue; } else { empresa.MDFe_Ambiente = null; }
            if (Combo_ComboBox.Selecionado(comboMDFeTipoEmissor)) { empresa.MDFe_TipoEmirssor = (TipoEmissor)comboMDFeTipoEmissor.SelectedValue; } else { empresa.MDFe_TipoEmirssor = null; }
            empresa.NuvemFiscal_SerialNumber = serialNumber;
            empresa.NuvemFiscal_Certificado = Funcao.StringVazioParaNulo(textNuvemFiscalCertificado.Text);
            empresa.NuvemFiscal_Usar = checkUtilizarNuvemFiscal.Checked;
            if (Combo_ComboBox.Selecionado(comboNuvemFiscalAmbienteWebService)) { empresa.NuvemFiscal_AmbienteWebService = (AmbienteSistemas)comboNuvemFiscalAmbienteWebService.SelectedValue; } else { empresa.NuvemFiscal_AmbienteWebService = null; }

            AdicionarEmpresa();
        }
        private void botaoUnidadeAtivo_Click(object sender, EventArgs e)
        {
            if (botaoUnidadeAtivo.Text == "Desativar Unidade")
            {
                botaoUnidadeAtivo.Text = "Ativar Unidade";
                dateUnidadeDesativada.Value = DateTime.Now;
                dateUnidadeDesativada.Visible = true;
                empresa.Ativo = false;
                empresa.DataDesativacao = dateUnidadeDesativada.Value;
            }
            else
            {
                botaoUnidadeAtivo.Text = "Desativar Unidade";
                dateUnidadeDesativada.Visible = false;
                empresa.Ativo = true;
                empresa.DataDesativacao = null;
            }
        }
        #endregion
        private void frmCadastroEmpresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (editado)
            //{
            //    if (!CaixaMensagem.Perguntar("Existem dados não salvos, pretendem sair sem salvá-los?"))
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}
        }
    }
}
