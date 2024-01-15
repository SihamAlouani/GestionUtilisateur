using AutoMapper;
using GestionUtilisateur.Application.Interfaces;
using GestionUtilisateur.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.CQRS.Utilisateurs.Queries.GetUtilisateurById
{
    public class GetUtilisateurByIdQueryHandler : IRequestHandler<GetUtilisateurByIdQuery, UtilisateurViewModel>
    {
        private readonly IUtilisateurRepository _utilisateurRepository;
        private readonly IMapper _mapper;

        public GetUtilisateurByIdQueryHandler(IUtilisateurRepository utilisateurRepository, IMapper mapper)
        {
            _utilisateurRepository = utilisateurRepository;
            _mapper = mapper;
        }
        public async Task<UtilisateurViewModel> Handle(GetUtilisateurByIdQuery request, CancellationToken cancellationToken)
        {
            var utilisateur = await _utilisateurRepository.GetByIdAsync(request.IdUtilisateur);
            return _mapper.Map<UtilisateurViewModel>(utilisateur);
        }
    }
}
