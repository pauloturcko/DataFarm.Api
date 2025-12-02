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
    
}