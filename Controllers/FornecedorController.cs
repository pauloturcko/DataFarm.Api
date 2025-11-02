using DataFarm.Api.Application.Services;
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

   /* [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFornecedorRequest request)
    {
        
    } */
}