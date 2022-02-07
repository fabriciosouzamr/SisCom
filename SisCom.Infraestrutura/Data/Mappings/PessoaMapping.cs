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
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CidadeId)
                .IsRequired(false);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.CNPJ_CPF)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.InscricaoEstadual)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.InscricaoMunicipal)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.End_CEP)
                .HasColumnType("varchar(8)");

            builder.Property(p => p.End_Logradouro)
                .HasColumnType("varchar(60)");

            builder.Property(p => p.End_Numero)
                .HasColumnType("varchar(10)");

            builder.Property(p => p.End_Bairro)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.End_PontoReferencia)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.FAX)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.NomeContato)
                .HasColumnType("varchar(50)");

            builder.ToTable("Pessoas");
        }
    }
}
