using DataFarm.Api.Domain.Animais;
using DataFarm.Api.Domain.MeatPrice;
using DataFarm.Api.Domain.Purchase;
using DataFarm.Api.Domain.Purchase.Aggregates;
using DataFarm.Api.Domain.Sales;
using DataFarm.Api.Domain.Sales.Aggregates;
using DataFarm.Api.Domain.Shared; // para o Insumo
using DataFarm.Api.Domain.Stock;
using Microsoft.EntityFrameworkCore;

namespace DataFarm.Api.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // ====================================================================
    // DB SETS (TABELAS PRINCIPAIS)
    // ====================================================================
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<Estoque> Estoques { get; set; }
    public DbSet<Comprador> Compradores { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; } // Fornecedor é um agregado
    public DbSet<PrecoCarne> PrecosCarne { get; set; }
    public DbSet<Insumo> Insumos { get; set; } // Insumo é uma entidade compartilhada

    // ====================================================================

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Mapeamento de Objetos de Valor da Entidade Animal
        modelBuilder.Entity<Animal>().OwnsMany(a => a.HistoricoPeso, p => p.ToJson());
        modelBuilder.Entity<Animal>().OwnsMany(a => a.HistoricoVacina, v => v.ToJson());

        // NOVO/CORRIGIDO: Mapeamento da Relação 1:N (Estoque -> Insumos)
        modelBuilder.Entity<Estoque>()
            .HasMany(e => e.Itens)
            .WithOne(i => i.Estoque)
            .HasForeignKey(i => i.EstoqueId);

        // 3. Mapeamento de Objetos de Valor da Entidade Venda
        modelBuilder.Entity<Venda>().OwnsOne(v => v.Frete, f => f.ToJson());

        // 4. Mapeamento de Objetos de Valor da Entidade PrecoCarne
        modelBuilder.Entity<PrecoCarne>().OwnsMany(p => p.HistoricoPreco, h => h.ToJson());

    }
}