using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocacaoImoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoImoveis.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClientesModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ClientesModel> cliente)
        {

            cliente.ToTable("CLIENTES");
            cliente.HasKey(x => x.Id);
            cliente.HasOne(x => x.Endereco);
            cliente.Property(x => x.Id).HasColumnName("id").HasColumnType("integer").ValueGeneratedOnAdd();
            cliente.Property(x => x.Nome).HasColumnName("nome");
            cliente.Property(x => x.CpfCnpj).HasColumnName("cpfCnpj");
            cliente.Property(x => x.Email).HasColumnName("email");
            cliente.Property(x => x.Telefone).HasColumnName("telefone");
            cliente.Property(x => x.NumeroCasa).HasColumnName("numeroCasa");
            cliente.Property(x => x.EnderecoCep).HasColumnName("enderecoCep");
        }
    }
}