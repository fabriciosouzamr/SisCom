using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class GrupoNaturezaReceita_CTS_PIS_COFINSMapping : IEntityTypeConfiguration<GrupoNaturezaReceita_CTS_PIS_COFINS>
    {
        public void Configure(EntityTypeBuilder<GrupoNaturezaReceita_CTS_PIS_COFINS> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(3)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.ToTable("GrupoNaturezaReceita_CTS_PIS_COFINSs");
        }
    }
}
