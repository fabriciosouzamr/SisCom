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
    public partial class frmCadastroGrupo : FormMain
    {
        GrupoMercadoriaController grupoController; //= new GrupoMercadoriaController();
        GrupoMercadoriaViewModel grupo; //= new GrupoMercadoriaViewModel();

        public frmCadastroGrupo(IServiceProvider serviceProvider, IServiceScopeFactory<MeuDbContext> dbCtxFactory, INotifier _notifier) : base(serviceProvider, dbCtxFactory, _notifier)
        {
            InitializeComponent();

            Navegar(Declaracoes.eNavegar.Primeiro);
        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {
            grupo = new GrupoMercadoriaViewModel();

            textNomeGrupo.Text = "";
            checkNaoVender.Checked = false;
        }

        private async void Gravar()
        {
            if (textNomeGrupo.Text != "")
            {
                grupo.Codigo = "";
                grupo.Nome = textNomeGrupo.Text;
                grupo.NaoVender = checkNaoVender.Checked;

                if (grupo.Id != Guid.Empty)
                {
                    await grupoController.Atualizar(grupo);
                }
                else
                {
                    grupo.Id = Guid.NewGuid();
                    await grupoController.Adicionar(grupo);
                }
            }
        }

        private async void Remover(Guid Id)
        {
            await grupoController.Remover(Id);
        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            if (grupo != null)
            {
                if (CaixaMensagem.PerguntarTexto(Texto.Mensagem_Grupo_Remover, new string[] { grupo.Nome }))
                {
                    if (grupo.Id != Guid.Empty)
                    {
                        Remover(grupo.Id);
                    }

                    Navegar(Declaracoes.eNavegar.Primeiro);

                    //GridAtualizar();
                }
            }
            else
            {
                CaixaMensagem.Informacao(Texto.Mensagem_Grupo_NaoSelecionado);
            }
        }

        private async Task Navegar(Declaracoes.eNavegar Posicao)
        {
            textNomeGrupo.Text = "";
            checkNaoVender.Checked = false;

            await Navegar_PegarTodos(grupo.Id, Posicao);

            textNomeGrupo.Text = grupo.Nome;
            checkNaoVender.Checked = grupo.NaoVender;
        }

        private async Task Navegar_PegarTodos(Guid? Id, Declaracoes.eNavegar Posicao)
        {
            IEnumerable<GrupoMercadoriaViewModel> Data = await grupoController.ObterTodos();
            GrupoMercadoriaViewModel ItemAnterior = null;
            GrupoMercadoriaViewModel ItemRetorno = null;
            bool Proximo = false;

            foreach (GrupoMercadoriaViewModel Item in Data)
            {
                if (Posicao == Declaracoes.eNavegar.Primeiro)
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
                        case Declaracoes.eNavegar.Anterior:
                            ItemRetorno = ItemAnterior;
                            break;
                        case Declaracoes.eNavegar.Atual:
                            ItemRetorno = Item;
                            break;
                        case Declaracoes.eNavegar.Proximo:
                            Proximo = true;
                            break;
                    }
                }

                ItemAnterior = Item;
            }

            if (Posicao == Declaracoes.eNavegar.Ultimo)
            {
                ItemRetorno = ItemAnterior;
            }

            if (ItemRetorno != null) { grupo = ItemRetorno; }
        }

        private void botaoAnterior_Click(object sender, EventArgs e)
        {
            Navegar(Declaracoes.eNavegar.Anterior);
        }

        private void botaoPosterior_Click(object sender, EventArgs e)
        {
            Navegar(Declaracoes.eNavegar.Proximo);
        }

        private void textNomeGrupo_Leave(object sender, EventArgs e)
        {
            Gravar();
        }

        private void checkNaoVender_CheckedChanged(object sender, EventArgs e)
        {
            Gravar();
        }

        private void botaoFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
