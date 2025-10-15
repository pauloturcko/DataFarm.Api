using DataFarm.Api.Application.Services;
using DataFarm.Api.Domain.Animais;
using DataFarm.Api.Domain.Animais.Aggregates;
using DataFarm.Api.Domain.Animais.Enum;
using DataFarm.Api.Domain.Exceptions;
using DataFarm.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DataFarm.Api.Controllers;

[ApiController] // 1. Indica que é um controlador de API
[Route("api/[controller]")] // 2. Define a rota base: /api/animals
public class AnimalsController : ControllerBase
{
    private readonly IAnimalService _animalService;
    
    public AnimalsController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpPost] // <--- 1. Atributo HTTP: Define este método como um endpoint POST
    public async Task<IActionResult> Create([FromBody] CreateAnimalRequest request)
    {
        // 1. Mapeamento da Raça: Converte a string do DTO para o nosso Enum (RacaEnum)
        if (!Enum.TryParse(request.Raca, true, out RacaEnum raca))
        {
            return BadRequest(new { message = "Raça fornecida inválida." });
        }

        // 2. Criando o objeto PESO inicial
        var pesoInicial = new Peso
        {
            PesoAnimal = request.PesoInicial,
            DataRegistro = request.DataChegada,
        };
        
        // 3. Criando o objeto ANIMAL de Domínio
        var novoAnimal = new Animal
        {
            Raca = raca,
            DataChegada = request.DataChegada,

            // 4. Inicializa as listas e adiciona o primeiro registro de peso
            HistoricoPeso = new List<Peso> { pesoInicial },
            HistoricoVacina = new List<RegistroVacina>()
        };

        try
        {
            var animalSalvo = await _animalService.CreateAnimalAsync(novoAnimal);

            return CreatedAtAction(nameof(GetById), new { id = animalSalvo.Id }, animalSalvo);
        }
        catch (AnimalsMaxCapacityReachedException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocorreu um erro ao processar a requisição.", errorDetail = ex.Message });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);

            return Ok(animal);
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
            var animals = await _animalService.GetAnimalListAsync();

            return Ok(animals);
        }
        catch (NotFoundAllException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {message = "Ocorreu um erro ao processar a requisição.", errorDetail = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var succes = await _animalService.DeleteAnimalAsync(id);

            return NoContent();
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAnimalRequest request)
    {
        try
        {
            var animalAtualizado = await _animalService.UpdateAnimalAsync(id, request);

            return Ok(animalAtualizado);
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
    
}