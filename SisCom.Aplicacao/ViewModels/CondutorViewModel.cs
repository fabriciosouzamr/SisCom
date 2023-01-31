using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.ViewModels
{
    public class CondutorViewModel : BaseModelView
    {
        public string CNPJ_CPF { get; set; }
        public string Nome { get; set; }
    }
}