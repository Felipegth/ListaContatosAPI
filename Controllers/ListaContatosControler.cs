using ListaContatos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaContatosController : ControllerBase
    {
        private static List<IContato> ListaContatoMemoria = new List<IContato>();

        [HttpGet] //Retorna todos contatos
        [Route("Contatos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        [AllowAnonymous]// todos
        public ActionResult<IEnumerable<IContato>> Get()
        {
            if (ListaContatoMemoria.Count == 0)
                return NoContent();

            return Ok(ListaContatoMemoria);
        }

        [HttpGet] //Retorna um contato
        [Route("Contatos/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] 
        [ProducesResponseType(StatusCodes.Status403Forbidden)] 
        [Produces("application/json")]
        [Authorize]//somente quem fez login
        public ActionResult<IContato> Get(int id)
        {
            if (ListaContatoMemoria.Find(x => x.Id == id) == null)
                return NotFound();

            return Ok(ListaContatoMemoria.Find(x => x.Id == id));
        }

        [HttpPost] //Insere um contato
        [Route("Contatos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] 
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(Roles = "manager")]//Somente o Gerente
        public ActionResult<IContato> Post([FromBody] Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(contato);
            }

            int id = 1 + ListaContatoMemoria
                .Select(x => x.Id)
                .DefaultIfEmpty(0)
                .Max();

            // Usando try catch ( ignora erro continuando estrutura de linha de comando)
            try
            {
                Contato ctt = new Contato(id, contato.Nome, contato.Telefone, contato.Email, contato.Idade);
                ListaContatoMemoria.Add(ctt);
            }
            catch (Exception)
            {
                return BadRequest(contato);
            }


            return Created("ListaContatos", ListaContatoMemoria.Find(x => x.Id == id));
        }

        [HttpPut] //Altera um contato
        [Route("Contatos/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] 
        [ProducesResponseType(StatusCodes.Status403Forbidden)] 
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(Roles = "employee,manager")] //Gerente e empregado
        public ActionResult<IContato> Put(int id, [FromBody] Contato contato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(contato);
            }

            try
            {
                if (ListaContatoMemoria.Find(x => x.Id == id) == null)
                    return NotFound();

                DateTime dtCadastro = ListaContatoMemoria.Find(x => x.Id == id).DataCadastro;

                ListaContatoMemoria.Remove(ListaContatoMemoria.Find(x => x.Id == id));
                ListaContatoMemoria.Add(new Contato(id, contato.Nome, contato.Telefone, contato.Email, contato.Idade, dtCadastro));
            }
            catch (Exception)
            {
                return BadRequest(contato);
            }

            return Ok(ListaContatoMemoria.Find(x => x.Id == id));
        }

        [HttpDelete] //Deleta um contato
        [Route("Contatos/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "manager")] //Somente Gerente
        public ActionResult<bool> Delete(int id)
        {
            if (ListaContatoMemoria.Find(x => x.Id == id) == null)
                return NotFound();

            ListaContatoMemoria.Remove(ListaContatoMemoria.Find(x => x.Id == id));

            return Ok();
        }
    }
}