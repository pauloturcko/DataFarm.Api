using DataFarm.Api.Application.Repositories;
using DataFarm.Api.Domain.Exceptions;
using DataFarm.Api.Domain.Purchase;
using DataFarm.Api.Domain.Shared;
using DataFarm.Api.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace DataFarm.Api.Application.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IEstoqueRepository _estoqueRepository;

    public PurchaseService(IPurchaseRepository purchaseRepository, IFornecedorRepository fornecedorRepository,
        IEstoqueRepository estoqueRepository)
    {
        _purchaseRepository = purchaseRepository;
        _fornecedorRepository = fornecedorRepository;
        _estoqueRepository = estoqueRepository;
    }

    public async Task<Compra?> CreateCompraAsync(CreatePurchaseRequest request)
    {
        var fornecedor = await _fornecedorRepository.GetByIdAsync(request.FornecedorFk);
        if (fornecedor == null)
        {
            throw new NotFoundException(
                "Fornecedor", (int)request.FornecedorFk);
        }
        
        decimal valorTotal = 0;

        foreach (var item in request.Itens)
        {
            decimal qtdConvertida = (decimal)item.Quantidade;
            
            valorTotal += qtdConvertida * item.PrecoUnitario;
        }

        var listaInsumos = request.Itens.Select(item => new Insumo()
        {
            Nome = item.Nome,
            Tipo = item.Tipo,
            Quantidade = item.Quantidade,
        }).ToList();

        var novaCompra = new Compra
        {
            FornecedorId = fornecedor.Id,
            Fornecedor = fornecedor,
            DataCompra = request.DataCompra,
            ValorTotal = valorTotal,
            Itens = listaInsumos
        };
         _purchaseRepository.Add(novaCompra);
         await _purchaseRepository.SaveChangesAsync();
         
        return novaCompra;
    }
    
    public async Task<Compra?> GetCompraByIdAsync(int id)
    {
        var compra = await _purchaseRepository.GetByIdAsync(id);

        if (compra == null)
        {
            throw new NotFoundException("Compra", id);
        }
        
        return compra;
    }
    
    public async Task<List<Compra>> GetCompraListAsync()
    {
        var compras = await _purchaseRepository.GetAllAsync();

        if (compras.Count == 0)
        {
            throw new NotFoundAllException("Nenhum registro foi encontrado.");
        }
        
        return compras;
    }
    
    public async Task<Compra?> UpdateCompraAsync(int id, UpdatePurchaseRequest request)
    {
        // 1. Busca a COMPRA correta pelo ID da rota
        var compra = await _purchaseRepository.GetByIdAsync(id);

        if (compra == null)
        {
            throw new NotFoundException("Compra", id);
        }

        // 2. Atualiza o Fornecedor (Se um novo ID foi enviado)
        // Note: Usamos FornecedorFk (int?), não o objeto Fornecedor
        if (request.FornecedorFk.HasValue)
        {
            // Verifica se o novo fornecedor existe antes de trocar
            var novoFornecedor = await _fornecedorRepository.GetByIdAsync(request.FornecedorFk.Value);
        
            if (novoFornecedor == null)
            {
                throw new NotFoundException("Fornecedor", request.FornecedorFk.Value);
            }

            // Atualiza a relação (Chave Estrangeira e Objeto)
            compra.FornecedorId = request.FornecedorFk.Value;
            compra.Fornecedor = novoFornecedor;
        }

        // 3. Atualiza a Data (Se enviada)
        if (request.DataCompra.HasValue)
        {
            compra.DataCompra = request.DataCompra.Value;
        }

        // Nota: Atualizar os ITENS é muito complexo (envolve estoque), 
        // por enquanto vamos atualizar apenas os dados básicos da compra.

        // 4. Salva usando o Repositório de COMPRA
        _purchaseRepository.Update(compra);
    
        return await _purchaseRepository.SaveChangesAsync() ? compra : null;
    }

    public async Task<bool> DeletePurchaseAsync (int id)
    {
        var compra = await _purchaseRepository.GetByIdAsync(id);

        if (compra == null)
        {
            throw new NotFoundException("Compra", id);
        }
        
        _purchaseRepository.Delete(compra);
        
        return await _purchaseRepository.SaveChangesAsync();
    }
    
}