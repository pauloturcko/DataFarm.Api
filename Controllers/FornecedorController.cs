using DataFarm.Api.Application.Services;
using DataFarm.Api.Domain.Purchase.Aggregates;
using DataFarm.Api.Domain.Exceptions; // Adicionado para DuplicateEntryException
using DataFarm.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DataFarm.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FornecedorController : ControllerBase
{
    private readonly IFornecedorService _fornecedorService;

    public FornecedorController(IFornecedorService fornecedorService)
    {
        _fornecedorService = fornecedorService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFornecedorRequest request)
    {
        try
        {
            var fornecedorSalvo = await _fornecedorService.CreateFornecedorAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = fornecedorSalvo!.Id }, fornecedorSalvo);
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
            var fornecedor = await _fornecedorService.GetFornecedorByIdAsync(id);

            return Ok(fornecedor);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {message = "Ocorreu um erro ao processar a requisição.", errorDetail = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var fornecedores = await _fornecedorService.GetFornecedorListAsync();

            return Ok(fornecedores);
        }
        catch (NotFoundAllException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro ao processar a requisição.", errorDetail = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateFornecedorRequest request)
    {
        try
        {
            var fornecedorAtualizado = await _fornecedorService.UpdateFornecedorAsync(id, request);

            return Ok(fornecedorAtualizado!);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro ao processar a requisição.", errorDetail = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var succes = await _fornecedorService.DeleteFornecedorAsync(id);

            return NoContent();
            // Ajustar isso aqui, precisa retornar que o objeto foi deletado, pode ser feito no front mesmo mas precisa retornar status code
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro ao processar a requsição.", errorDetail = ex.Message });
        }
    }
}