using DataFarm.Api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using DataFarm.Api.Application.Repositories;
using DataFarm.Api.Application.Services;

namespace DataFarm.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var connectionString = builder.Configuration.GetConnectionString("FazendaDb");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            // --- REGISTRO DE DEPENDÊNCIAS (ADICIONE ISTO) ---

            // 1. Repositórios (Infra)
            builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
            builder.Services.AddScoped<IFarmConfigRepository, FarmConfigRepository>();
            // NOVOS:
            builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            builder.Services.AddScoped<IPurchaseRepository, CompraRepository>();
            builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();

            // 2. Serviços (Aplicação)
            builder.Services.AddScoped<IAnimalService, AnimalService>();
            // NOVOS:
            builder.Services.AddScoped<IFornecedorService, FornecedorService>();
            builder.Services.AddScoped<IPurchaseService, PurchaseService>();

            // -----------------------------------------------

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}