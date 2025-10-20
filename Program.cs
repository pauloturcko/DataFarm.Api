using DataFarm.Api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using DataFarm.Api.Application.Repositories; // Para IAnimalRepository e IFarmConfigRepository
using DataFarm.Api.Application.Services;     // Para IAnimalService

namespace DataFarm.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona serviços ao contêiner de Injeção de Dependência
            builder.Services.AddControllers();

            // PostgreSQL Configuração do DbContext
            var connectionString = builder.Configuration.GetConnectionString("FazendaDb");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            // ====================================================================
            // INJEÇÃO DE DEPENDÊNCIA (LIGANDO CONTRATOS A IMPLEMENTAÇÕES)
            // ====================================================================

            // Repositórios: São os implementadores do acesso ao banco de dados (Infra/Data)
            // Usamos AddScoped para garantir uma instância por requisição HTTP.
            
            // 1. Repositório de Dados: IAnimalRepository -> AnimalRepository
            builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

            // 2. Repositório de Configuração: IFarmConfigRepository -> FarmConfigRepository
            builder.Services.AddScoped<IFarmConfigRepository, FarmConfigRepository>();

            // Serviços: Contém a lógica de negócio (Application/Services)
            
            // 3. Serviço Principal: IAnimalService -> AnimalService
            builder.Services.AddScoped<IAnimalService, AnimalService>();

            // ====================================================================
            
            // Configuração do Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configuração do pipeline HTTP
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
