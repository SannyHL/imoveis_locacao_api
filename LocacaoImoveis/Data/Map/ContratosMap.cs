using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoImoveis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoImoveis.Data.Map
{
    public class ContratosMap : IEntityTypeConfiguration<ContratosModel>
    {
        public void Configure(EntityTypeBuilder<ContratosModel> builder)
        {
            builder.ToTable("CONTRATOS");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Clientes);
            builder.HasOne(x => x.Imovel);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("integer").ValueGeneratedOnAdd();
            builder.Property(x => x.ValorLocacao).HasColumnName("ValorLocacao");
            builder.Property(x => x.DataInicio).HasColumnName("dataInicio");
            builder.Property(x => x.DataFim).HasColumnName("dataFim");
            builder.Property(x => x.Ativo).HasColumnName("ativo");
            builder.Property(x => x.ClientesId).HasColumnName("clienteId");
            builder.Property(x => x.ImovelId).HasColumnName("imovelId");

        }
    }
}