using GestionUtilisateur.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.CQRS.Utilisateurs.Commands.DeleteUtilisateur
{
    public class DeleteUtilisateurCommandHandler : IRequestHandler<DeleteUtilisateurCommand, int>
    {
        public IUtilisateurRepository _utilisateurRepository;
        public DeleteUtilisateurCommandHandler(IUtilisateurRepository utilisateurRepository)
        {
            _utilisateurRepository = utilisateurRepository;
        }
        public async Task<int> Handle(DeleteUtilisateurCommand request, CancellationToken cancellationToken)
        {
            return await _utilisateurRepository.DeleteAsync(request.IdUtilisateur);
        }
    }
}
