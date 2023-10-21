using SisCom.Aplicacao.Classes;
using SisCom.Entidade.Enum;
using System;
using System.Windows.Forms;

namespace SisCom.Aplicacao.Formularios
{
    public partial class uscTipoEmissor : UserControl
    {
        public delegate void TipoEmissorEventHandler(object sender, TipoEmissor tipoEmissor);

        public event TipoEmissorEventHandler TipoEmissorSelecionado;

        bool processado = false;

        public uscTipoEmissor()
        {
            InitializeComponent();
            CarregaDados();
            processado = true;
        }

        void CarregaDados()
        {
            processado = false;
            radioNormal.Checked = (Declaracoes.dados_Empresa_TipoEmirssor == TipoEmissor.Normal);
            radioContigencia.Checked = (Declaracoes.dados_Empresa_TipoEmirssor == TipoEmissor.Contigencia);
            labelEmContigencia.Visible = (Declaracoes.dados_Empresa_TipoEmirssor == TipoEmissor.Contigencia);
            processado = true;
        }

        private void radioNormal_CheckedChanged(object sender, EventArgs e)
        {
            TipoEmissorSetar(TipoEmissor.Normal);
        }

        private void radioContigencia_CheckedChanged(object sender, EventArgs e)
        {
            TipoEmissorSetar(TipoEmissor.Contigencia);
        }

        void TipoEmissorSetar(TipoEmissor tipoEmissor)
        {
            if (!processado)
                return;

            Declaracoes.dados_Empresa_TipoEmirssor = tipoEmissor;

            CarregaDados();

            TipoEmissorSelecionado.Invoke(this, tipoEmissor);
        }
    }
}
