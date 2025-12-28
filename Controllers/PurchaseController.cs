using DataFarm.Api.Application.Services;
using DataFarm.Api.Domain.Exceptions;
using DataFarm.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DataFarm.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseController : ControllerBase
{
    private readonly IPurchaseService _purchaseService;

    public PurchaseController(IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePurchaseRequest request)
    {
        try
        {
            var compra = await _purchaseService.CreateCompraAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = compra!.Id }, compra);
        }
        catch (DuplicateRecordException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro interno ao processar a requisição.", errorDetail = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var compra = await _purchaseService.GetCompraByIdAsync(id);
            return Ok(compra);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var compras = await _purchaseService.GetCompraListAsync();
            return Ok(compras);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePurchaseRequest request)
    {
        try
        {
            request.FornecedorFk = id;
            var compra = await _purchaseService.UpdateCompraAsync(id, request);
            return Ok(compra);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _purchaseService.DeletePurchaseAsync(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}