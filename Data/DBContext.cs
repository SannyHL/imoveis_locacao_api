using LocacaoImoveis.Data.Map;
using LocacaoImoveis.Models;
using Microsoft.EntityFrameworkCore;
namespace LocacaoImoveis.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<ClienteEndereco> ClientesEndereco { get; set; }
        public DbSet<ClientesModel> Clientes { get; set; }
        public DbSet<EnderecosModel> Enderecos { get; set; }
        public DbSet<ImoveisModel> Imoveis { get; set; }
        public DbSet<ContratosModel> Contratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContratosMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EnderecosMap());
            modelBuilder.ApplyConfiguration(new ImoveisMap());

            base.OnModelCreating(modelBuilder);
        }
    }


}