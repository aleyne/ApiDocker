using ApiDocker.DTO;
using ApiDocker.Entities;
using ApiDocker.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDocker.Controllers
{
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("d0000/exemplo-api/v1/[controller]")]
    [ApiController]
    public class OrgaoController : ControllerBase
    {
        /// <summary>
        /// Metodo para obter todos os orgões sem a logo
        /// </summary>
        /// <param name="orgaoService"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(OrgaoSemLogo), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet]
        public IActionResult Get([FromServices] IOrgaoService orgaoService)
        {
            try
            {
                var lista = orgaoService.ObterTodosOrgaos();

                if (lista == null || !lista.Any())
                    return NoContent();

                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Metodo para obter Orgão por Id
        /// </summary>
        /// <param name="orgaoService"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(OrgaoComLogo), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IOrgaoService orgaoService, int id)
        {
            try
            {
                var orgao = orgaoService.ObterOrgaoPorId(id);

                if (orgao == null)
                    return NoContent();

                return Ok(orgao);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
