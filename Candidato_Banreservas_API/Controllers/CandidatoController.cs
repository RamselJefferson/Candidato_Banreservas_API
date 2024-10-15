using Candidato.Core.Application.Interfaces.Services;
using Candidato.Core.Application.Request;
using Candidato.Core.Application.Services;
using Candidato.Core.Domain.Entities;
using Candidato.Infrastructure.Persistance.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;


namespace Candidato_Banreservas_API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoService _svcCandidato;
        public CandidatoController(ICandidatoService svcCandidato)
        {
            _svcCandidato = svcCandidato;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
        Summary = "list of candidates",
        Description = "get all the candidates records in the database"
        )]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var candidatos = await _svcCandidato.GetAllAsync();
                if ( candidatos.Count == 0)
                {
                    return NotFound();
                }
                
                return Ok(candidatos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
          Summary = "Get Candidate",
          Description = "Get a Candidate by its id"
          )]
        public virtual async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var entity = await _svcCandidato.GetByIdAsync(id);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(
            Summary = "Candidate",
            Description = "Add a Candidate"
            )]
        public virtual async Task<IActionResult> Add([FromBody] CandidatoRequest candidate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var entity = await _svcCandidato.AddAsync(candidate);

                if (entity == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return Ok("Candidato creado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCandidatoRequest candidate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool existingCandidate = await _svcCandidato.ExistCandidato(id);
                if (!existingCandidate)
                {
                    return NotFound("Candidato no encontrado.");
                }

                await _svcCandidato.UpdateCandidate(candidate);

                return Ok(candidate);

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var candidato = await _svcCandidato.GetByIdAsync(id);

                if (candidato == null)
                {
                    return NotFound();
                }

                await _svcCandidato.DeleteAsync(id);

                return Ok(candidato);

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
