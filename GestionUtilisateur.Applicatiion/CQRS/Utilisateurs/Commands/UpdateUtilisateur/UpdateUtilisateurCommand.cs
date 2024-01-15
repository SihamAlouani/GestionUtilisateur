using GestionUtilisateur.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.CQRS.Utilisateurs.Commands.UpdateUtilisateur
{
    public class UpdateUtilisateurCommand : IRequest<int>
    {
        public int IdUtilisateur { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public string Sexe { get; set; } = null!;

        public bool JobInTech { get; set; }

        public virtual ICollection<UtilisateurRole> UtilisateurRoles { get; set; } = new List<UtilisateurRole>();
    }

}

