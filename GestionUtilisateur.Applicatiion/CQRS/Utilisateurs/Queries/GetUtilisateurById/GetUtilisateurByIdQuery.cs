using GestionUtilisateur.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.CQRS.Utilisateurs.Queries.GetUtilisateurById
{
    public class GetUtilisateurByIdQuery : IRequest<UtilisateurViewModel>
    {
        public int IdUtilisateur {  get; set; }
    }
}
