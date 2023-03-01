using LocacaoImoveis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocacaoImoveis.Data.Map
{
    public class ImoveisMap : IEntityTypeConfiguration<ImoveisModel>
    {

        public void Configure(EntityTypeBuilder<ImoveisModel> builder)
        {
            builder.ToTable("IMOVEIS");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Endereco);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("integer").ValueGeneratedOnAdd();
            builder.Property(x => x.NumeroCasa).HasColumnName("numeroCasa");
            builder.Property(x => x.Locado).HasColumnName("locado");
            builder.Property(x => x.EnderecoCep).HasColumnName("enderecoCep");
            builder.Property(x => x.Ativo).HasColumnName("ativo");

        }
    }
}