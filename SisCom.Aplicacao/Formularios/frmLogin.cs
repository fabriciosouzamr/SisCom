using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Entidade.Enum;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmLogin : FormMain
    {
        public frmLogin(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier notifier) : base(serviceProvider, dbCtxFactory, notifier)
        {
            InitializeComponent();
            Inicializar();
        }
        async void Inicializar()
        {
            Combo_ComboBox.Formatar(comboUsuario,
                                    "Id", "Nome",
                                    ComboBoxStyle.DropDownList,
                                    await (new FuncionarioController(this.MeuDbContext(), this._notifier)).ComboUsuario(p => p.Nome));
            Combo_ComboBox.Formatar(comboEmpresa,
                                    "Id", "RazaoSocial",
                                    ComboBoxStyle.DropDownList,
                                    await (new EmpresaController(this.MeuDbContext(), this._notifier)).Combo(p => p.RazaoSocial));

            if (comboEmpresa.Items.Count > 0) comboEmpresa.SelectedIndex = 0;
            comboEmpresa.Visible = false;
            labelEmpresa.Visible = false;
        }
        async void ValidarUsuario(Guid funcionario, string senha)
        {
            bool valido;
            using (FuncionarioController funcionarioController = new FuncionarioController(this.MeuDbContext(), this._notifier))
            {
                valido = (await funcionarioController.ValidarSenha(funcionario, senha));
            }

            if (valido)
            {
                if  (Combo_ComboBox.Selecionado(comboEmpresa))
                {
                    using (EmpresaController empresaController = new EmpresaController(this.MeuDbContext(), this._notifier))
                    {
                        var empresa = (await empresaController.GetById((Guid)comboEmpresa.SelectedValue));

                        if (empresa != null)
                        {
                            if ((empresa.Endereco != null) && (empresa.Endereco.End_Cidade != null))
                            {
                                Declaracoes.dados_Empresa_CodigoEstado = empresa.Endereco.End_Cidade.Estado.Codigo;
                                Declaracoes.dados_Empresa_EstadoId = empresa.Endereco.End_Cidade.Estado.Id;
                            }
                            Declaracoes.dados_Empresa_Id = empresa.Id;
                            Declaracoes.dados_Empresa_SerialNumber = empresa.NuvemFiscal_SerialNumber;
                            Declaracoes.dados_Empresa_CNPJ = empresa.CNPJ;
                            if (empresa.RegimeTributario != null)
                                Declaracoes.dados_Empresa_RegimeTributario = (RegimeTributario)empresa.RegimeTributario;
                            if (!String.IsNullOrEmpty(empresa.PathDocumentoFiscal))
                                Declaracoes.dados_Path_DocumentoFiscal = empresa.PathDocumentoFiscal;
                        }
                    }
                }

                Declaracoes.login_Valido = true;
                Close();
            }
            else
            {
                CaixaMensagem.Informacao("Senha inválida");
            }
        }
        private void cmdSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            pnlLogin.Left = (this.Width - pnlLogin.Width) / 2;
            pnlLogin.Top = (this.Height - pnlLogin.Height) / 2;
        }

        private void cmdEntrar_Click(object sender, EventArgs e)
        {
            if (!Combo_ComboBox.Selecionado(comboUsuario))
            {
                CaixaMensagem.Informacao("Selecione o usuário");
                return;
            }
            if (textSenha.Text.Trim() == "")
            {
                CaixaMensagem.Informacao("Informe a senha");
                return;
            }

            ValidarUsuario((Guid)comboUsuario.SelectedValue, textSenha.Text.Trim());
        }
    }
}
