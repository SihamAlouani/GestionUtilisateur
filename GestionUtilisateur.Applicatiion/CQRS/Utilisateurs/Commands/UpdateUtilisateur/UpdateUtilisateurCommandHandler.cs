using GestionUtilisateur.Application.Interfaces;
using GestionUtilisateur.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.CQRS.Utilisateurs.Commands.UpdateUtilisateur
{
    public class UpdateUtilisateurCommandHandler : IRequestHandler<UpdateUtilisateurCommand, int>
    {
        public IUtilisateurRepository _utilisateurRepository;
        public UpdateUtilisateurCommandHandler(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }

        public async Task<int> Handle(UpdateUtilisateurCommand request, CancellationToken cancellationToken)
        {
            var updateUtilisateur = new UtilisateurViewModel()
            {
                IdUtilisateur = request.IdUtilisateur,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Adress = request.Adress,
                Sexe = request.Sexe,
                JobInTech = request.JobInTech,
                UtilisateurRoles = request.UtilisateurRoles,
            };
            return await _utilisateurRepository.UpdateAsync(request.IdUtilisateur, updateUtilisateur);
        }
    }
}
