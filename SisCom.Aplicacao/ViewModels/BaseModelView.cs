using System;
using System.ComponentModel.DataAnnotations;

namespace SisCom.Aplicacao.ViewModels
{
    public class BaseModelView
    {
        [Key]
        public Guid Id { get; set; }
    }
    public class CodigoNomeComboViewModel : BaseModelView
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
    public class CodigoDescricaoComboViewModel : BaseModelView
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
    public class CodigoComboViewModel : BaseModelView
    {
        public string Codigo { get; set; }
    }
    public class NomeComboViewModel : BaseModelView
    {
        public string Nome { get; set; }
    }
    public class DescricaoComboViewModel : BaseModelView
    {
        public string Descricao { get; set; }
    }
}
