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

            if (comboEmpresa.Items.Count == 1)
            {
                comboEmpresa.SelectedIndex = 0;
                comboEmpresa.Visible = false;
            }
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
                using (EmpresaController empresaController = new EmpresaController(this.MeuDbContext(), this._notifier))
                {
                    var empresa = (await empresaController.GetById((Guid)comboEmpresa.SelectedValue));

                    if (empresa != null)
                    {
                        Declaracoes.dados_Empresa_CodigoEstado = empresa.Endereco.End_Cidade.Estado.Codigo;
                        Declaracoes.dados_Empresa_Id = empresa.Id;
                        Declaracoes.dados_Empresa_EstadoId = empresa.Endereco.End_Cidade.Estado.Id;
                        Declaracoes.dados_Empresa_SerialNumber = empresa.NuvemFiscal_SerialNumber;
                        Declaracoes.dados_Empresa_CNPJ = empresa.CNPJ;
                        if (empresa.RegimeTributario != null)
                            Declaracoes.dados_Empresa_RegimeTributario = (RegimeTributario)empresa.RegimeTributario;
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
            pnlLogin.Left = (int)(this.Width * 0.1);
            pnlLogin.Top = (int)((this.Height - pnlLogin.Height) * 0.8);
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
            if (!Combo_ComboBox.Selecionado(comboEmpresa))
            {
                CaixaMensagem.Informacao("Selecione a empresa");
                return;
            }

            ValidarUsuario((Guid)comboUsuario.SelectedValue, textSenha.Text.Trim());
        }
    }
}
