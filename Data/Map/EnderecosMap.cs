using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoImoveis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoImoveis.Data.Map
{
    public class EnderecosMap : IEntityTypeConfiguration<EnderecosModel>
    {

        public void Configure(EntityTypeBuilder<EnderecosModel> builder)
        {
            builder.ToTable("ENDERECOS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("integer").ValueGeneratedOnAdd();
            builder.Property(x => x.Cep).HasColumnName("cep");
            builder.Property(x => x.Logradouro).HasColumnName("logradouro");
            builder.Property(x => x.Bairro).HasColumnName("bairro");
            builder.Property(x => x.Localidade).HasColumnName("localidade");
            builder.Property(x => x.Uf).HasColumnName("uf");

        }
    }
}