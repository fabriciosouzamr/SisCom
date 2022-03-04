using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisCom.Entidade.Modelos
{
    public class Endereco
    {
        [Column("End_CEP"), StringLength(8)]
        public string End_CEP { get; set; }
        [Column("End_Logradouro"), StringLength(60)]
        public string End_Logradouro { get; set; }
        [Column("End_Numero"), StringLength(8)]
        public string End_Numero { get; set; }
        [Column("End_Bairro"), StringLength(60)]
        public string End_Bairro { get; set; }
        [Column("End_PontoReferencia"), StringLength(200)]
        public string End_PontoReferencia { get; set; }
        [Column("End_CidadeId")]
        public Nullable<Guid> End_CidadeId { get; set; }
        /* EF Relation */
        public Cidade End_Cidade { get; set; }

    }
}
