﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisCom.Entidade.Modelos;

namespace SisCom.Infraestrutura.Data.Mappings
{
    public class VinculoFiscalMapping : IEntityTypeConfiguration<VinculoFiscal>
    {
        public void Configure(EntityTypeBuilder<VinculoFiscal> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.ToTable("VinculoFiscais");
        }
    }
}
