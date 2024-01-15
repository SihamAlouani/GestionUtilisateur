using AutoMapper;
using GestionUtilisateur.Application.CQRS.Utilisateurs.Commands.CreateUtilisateur;
using GestionUtilisateur.Application.CQRS.Utilisateurs.Commands.DeleteUtilisateur;
using GestionUtilisateur.Application.CQRS.Utilisateurs.Commands.UpdateUtilisateur;
using GestionUtilisateur.Application.CQRS.Utilisateurs.Queries.GetUtilisateurById;
using GestionUtilisateur.Application.CQRS.Utilisateurs.Queries.GetUtilisateurs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace GestionUtilisateur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    //[Authorize]
    public class UtilisateurController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UtilisateurController(IMediator mediator)
        {
            _mediator = mediator;
        }


        
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var utilisateurs = await _mediator.Send(new GetUtilisateursQuery());
            return Ok(utilisateurs);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var utilisateur = await _mediator.Send(new GetUtilisateurByIdQuery() { IdUtilisateur = id });
            if (utilisateur == null)
            {
                return NotFound();
            }
            return Ok(utilisateur);
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateUtilisateurCommand commande)
        {
            var newUtili = await _mediator.Send(commande);
            return CreatedAtAction(nameof(GetById), new { id = newUtili.IdUtilisateur }, newUtili);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUtilisateurCommand commande)
        {
            if (id != commande.IdUtilisateur)
            {
                return BadRequest();
            }
            await _mediator.Send(commande);
            return NoContent();
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteUtilisateurCommand { IdUtilisateur= id });
            return NoContent();
        }
    }
}
