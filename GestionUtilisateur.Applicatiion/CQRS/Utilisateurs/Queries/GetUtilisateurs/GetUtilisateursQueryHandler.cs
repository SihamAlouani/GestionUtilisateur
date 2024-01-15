using AutoMapper;
using GestionUtilisateur.Application.Interfaces;
using GestionUtilisateur.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.CQRS.Utilisateurs.Queries.GetUtilisateurs
{
    public class GetUtilisateursQueryHandler : IRequestHandler<GetUtilisateursQuery, List<UtilisateurViewModel>>
    {
        private readonly IUtilisateurRepository _utilisateurRepository;
        private readonly IMapper _mapper;
        public GetUtilisateursQueryHandler(IUtilisateurRepository utilisateurRepository, IMapper mapper)
        {
            _utilisateurRepository = utilisateurRepository;
            _mapper = mapper;
        }

        public async Task<List<UtilisateurViewModel>> Handle(GetUtilisateursQuery request, CancellationToken cancellationToken)
        {
            var utilisateurs = await _utilisateurRepository.GetAllUtilisateurAsync();
            var utilisateurList = _mapper.Map<List<UtilisateurViewModel>>(utilisateurs);

            return utilisateurList;
        }
    }

         
    
}
