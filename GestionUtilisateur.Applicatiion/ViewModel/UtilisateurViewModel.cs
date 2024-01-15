using GestionUtilisateur.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.ViewModel
{
    public class UtilisateurViewModel
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
