using DataFarm.Api.Application.Repositories;
using DataFarm.Api.Domain.Exceptions;
using DataFarm.Api.Domain.Purchase.Aggregates;
using DataFarm.Api.DTOs;

namespace DataFarm.Api.Application.Services;

public class FornecedorService : IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorService(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task<Fornecedor?> CreateFornecedorAsync(CreateFornecedorRequest request)
    {
        var fornecedorExistente = await _fornecedorRepository.GetByNameAsync(request.Nome!); 

        if (fornecedorExistente != null)
        {
            throw new DuplicateRecordException($"Já existe um fornecedor com esse nome {request.Nome}");
        }

        var novoFornecedor = new Fornecedor
        {
            Nome = request.Nome,
            Tipo = request.Tipo,
            Favorito = request.Favorito,
        };
        
        _fornecedorRepository.Add(novoFornecedor);
        await _fornecedorRepository.SaveChangesAsync();
        
        return novoFornecedor;
    }

    public async Task<Fornecedor?> UpdateFornecedorAsync(UpdateFornecedorRequest request)
    {
        var fornecedor = await _fornecedorRepository.GetByIdAsync(request.Id);

        if (fornecedor == null)
        {
            throw new NotFoundException("Fornecedor", request.Id);
        }


        if (!string.IsNullOrWhiteSpace(request.Nome)) 
        {
            fornecedor.Nome = request.Nome;
        }

        if (request.Tipo.HasValue) 
        {
            fornecedor.Tipo = request.Tipo.Value;
        }

        if (request.Favorito.HasValue) 
        {
            fornecedor.Favorito = request.Favorito.Value;
        }
        
        _fornecedorRepository.Update(fornecedor);
        
        return await _fornecedorRepository.SaveChangesAsync() ? fornecedor : null;
    }

    public async Task<bool> DeleteFornecedorAsync(int id)
    {
        var fornecedor = await _fornecedorRepository.GetByIdAsync(id);

        if (fornecedor == null)
        {
            throw new NotFoundException("Fornecedor", id);
        }
        
        _fornecedorRepository.Delete(fornecedor);
        
        return await _fornecedorRepository.SaveChangesAsync();
    }

    public async Task<List<Fornecedor>> GetFornecedorListAsync()
    {
        var fornecedores = await _fornecedorRepository.GetAllAsync();

        if (fornecedores.Count == 0)
        {
            throw new NotFoundAllException("Nenhum registro foi encontrado.");
        }
        
        return fornecedores;
    }

    public async Task<Fornecedor?> GetFornecedorByIdAsync(int id)
    {
        var fornecedor = await _fornecedorRepository.GetByIdAsync(id);

        if (fornecedor == null)
        {
            throw new NotFoundException("Fornecedor", id);
        }
        
        return fornecedor;
    }
}
