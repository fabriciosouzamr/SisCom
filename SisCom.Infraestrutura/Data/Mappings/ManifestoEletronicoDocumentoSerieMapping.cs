﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class ManifestoEletronicoDocumentoSerieMapping : IEntityTypeConfiguration<ManifestoEletronicoDocumentoSerie>
    {
        public void Configure(EntityTypeBuilder<ManifestoEletronicoDocumentoSerie> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UltimoNumeroManifestoEletronicoDocumento).IsRequired().HasColumnType("varchar(10)");

            builder.Property(p => p.Serie).IsRequired().HasColumnType("varchar(3)");

            builder.ToTable("ManifestoEletronicoDocumentoSeries");
        }
    }
}