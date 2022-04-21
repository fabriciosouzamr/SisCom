using Funcoes._Classes;
using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class frmCadastroFuncionarios : FormMain
    {
        ViewModels.FuncionarioViewModel funcionario = null;

        public frmCadastroFuncionarios(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();
            Limpar();

            funcionario = new ViewModels.FuncionarioViewModel();
            Navegar(Declaracoes.Navegar.Primeiro);
        }
        #region Funcoes
        void Limpar()
        {
            textNomeFuncionario.Text = "";
            textSenhaFuncionario.Text = "";
            checkAcessoFinanceiro.Checked = false;
            checkAcessoFiscal.Checked = false;
            checkDesativado.Checked = false;
        }
        bool TentarGravar()
        {
            bool tentarGravar = false;

            if ((funcionario.Id == Guid.Empty) && (textNomeFuncionario.Text.Trim() == ""))
            {
                tentarGravar = true;
            }
            else
            {
                if (textNomeFuncionario.Text == "")
                {
                    CaixaMensagem.Informacao("Informe o nome do funcionário");
                    goto Sair;
                }
                if (textSenhaFuncionario.Text == "")
                {
                    CaixaMensagem.Informacao("Informe a senha do funcionário");
                    goto Sair;
                }

                GravarFuncionario();

                tentarGravar = true;
            }


Sair:
            return tentarGravar;
        }
        private async Task GravarFuncionario()
        {

            funcionario.Nome = textNomeFuncionario.Text;
            funcionario.Senha = textSenhaFuncionario.Text;
            funcionario.AcessoFinanceiro = checkAcessoFinanceiro.Checked;
            funcionario.AcessoFiscal = checkAcessoFiscal.Checked;
            funcionario.Desativado = checkDesativado.Checked;

            using (FuncionarioController funcionarioController = new FuncionarioController(this.MeuDbContext(), this._notifier))
            {
                if (funcionario.Id != Guid.Empty)
                {
                    await funcionarioController.Atualizar(funcionario.Id, funcionario);
                }
                else
                {
                    funcionario = (await funcionarioController.Adicionar(funcionario));
                }
                this.MeuDbContextDispose();
            }
        }
        private async void Excluir()
        {
            using (FuncionarioController funcionarioController = new FuncionarioController(this.MeuDbContext(), this._notifier))
            {
                await funcionarioController.Excluir(funcionario.Id);
                this.MeuDbContextDispose();
            }

            Limpar();
        }
        void CarregarDados()
        {
            if (funcionario != null)
            {
                Limpar();

                textNomeFuncionario.Text = Funcao.NuloParaString(funcionario.Nome);
                textSenhaFuncionario.Text = Funcao.NuloParaString(funcionario.Senha);
                checkAcessoFinanceiro.Checked = funcionario.AcessoFinanceiro;
                checkAcessoFiscal.Checked = funcionario.AcessoFiscal;
                checkDesativado.Checked = funcionario.Desativado;
            }
        }

        private async Task Navegar(Declaracoes.Navegar Posicao)
        {
            if (TentarGravar())
            {
                await Navegar_PegarTodos(funcionario.Id, Posicao);

                CarregarDados();
            }
        }

        private async Task Navegar_PegarTodos(Guid? Id, Declaracoes.Navegar Posicao)
        {
            using (FuncionarioController funcionarioController = new FuncionarioController(this.MeuDbContext(), this._notifier))
            {
                IEnumerable<FuncionarioViewModel> Data = await funcionarioController.ObterTodos();

                FuncionarioViewModel ItemAnterior = null;
                FuncionarioViewModel ItemRetorno = null;
                bool Proximo = false;

                foreach (FuncionarioViewModel Item in Data)
                {
                    if (Posicao == Declaracoes.Navegar.Primeiro)
                    {
                        ItemRetorno = Item;
                        break;
                    }
                    else if (Proximo)
                    {
                        ItemRetorno = Item;
                        break;
                    }
                    else if (Item.Id == Id)
                    {
                        switch (Posicao)
                        {
                            case Declaracoes.Navegar.Anterior:
                                ItemRetorno = ItemAnterior;
                                break;
                            case Declaracoes.Navegar.Atual:
                                ItemRetorno = Item;
                                break;
                            case Declaracoes.Navegar.Proximo:
                                Proximo = true;
                                break;
                        }
                    }

                    ItemAnterior = Item;
                }

                if (Posicao == Declaracoes.Navegar.Ultimo)
                {
                    ItemRetorno = ItemAnterior;
                }

                if (ItemRetorno != null) { funcionario = ItemRetorno; }

                this.MeuDbContextDispose();
            }
        }
        #endregion

        #region Botoes
        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void botaoAnterior_Click(object sender, EventArgs e)
        {
            Navegar(funcionario.Id == Guid.Empty ? Declaracoes.Navegar.Primeiro : Declaracoes.Navegar.Anterior);
        }

        private void botaoPosterior_Click(object sender, EventArgs e)
        {
            Navegar(funcionario.Id == Guid.Empty ? Declaracoes.Navegar.Primeiro : Declaracoes.Navegar.Proximo);
        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {
            funcionario = new ViewModels.FuncionarioViewModel();
            Limpar();
        }
        #endregion

        private void frmCadastroFuncionarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!TentarGravar())
            {
                e.Cancel = (!CaixaMensagem.Perguntar("Cadastro em edição! Deseja sair assim mesmo?"));
            }
        }
    }
}
