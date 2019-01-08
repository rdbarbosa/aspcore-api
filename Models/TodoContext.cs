using Microsoft.EntityFrameworkCore;

namespace aspcore_api.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Defeito> Defeito { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<ItemMovimentacao> ItemMovimentacao { get; set; }
        public DbSet<Local> Local { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<TipoEquipamento> TipoEquipamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<TipoEquipamento>()
            //     .HasMany(c => c.Equipamento)
            //     .WithOne(e => e.TipoEquipamento);
                
            modelBuilder.Entity<Equipamento>()
                .HasOne(e => e.TipoEquipamento);
            
        }
    }
}