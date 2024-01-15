using GestionUtilisateur.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.CQRS.Utilisateurs.Queries.GetUtilisateurs
{
    public class GetUtilisateursQuery : IRequest<List<UtilisateurViewModel>>
    {
    }
}
