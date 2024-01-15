using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.CQRS.Utilisateurs.Commands.DeleteUtilisateur
{
    public class DeleteUtilisateurCommand:IRequest<int>
    {
        public int IdUtilisateur { get; set; }
    }
}
