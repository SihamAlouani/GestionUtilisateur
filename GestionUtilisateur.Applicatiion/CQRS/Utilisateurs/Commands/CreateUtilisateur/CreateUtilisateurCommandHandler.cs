using AutoMapper;
using GestionUtilisateur.Application.Interfaces;
using GestionUtilisateur.Application.ViewModel;
using GestionUtilisateur.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.CQRS.Utilisateurs.Commands.CreateUtilisateur
{
    public class CreateUtilisateurCommandHandler : IRequestHandler<CreateUtilisateurCommand, UtilisateurViewModel>
    {
        private readonly IUtilisateurRepository _utilisateurRepository;
        private readonly IMapper _mapper;

        public CreateUtilisateurCommandHandler(IUtilisateurRepository utilisateurRepository, IMapper mapper)
        {
            _utilisateurRepository = utilisateurRepository;
            _mapper = mapper;
        }
        public async Task<UtilisateurViewModel> Handle(CreateUtilisateurCommand request, CancellationToken cancellationToken)
        {
            var NewUtilisateur = new Utilisateur()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Adress = request.Adress,
                Sexe = request.Sexe,
                JobInTech = request.JobInTech,
                UtilisateurRoles = request.UtilisateurRoles,
            };

            var resultat = await _utilisateurRepository.CreateAsync(NewUtilisateur);
            return _mapper.Map<UtilisateurViewModel>(resultat);
        }
    }
}
