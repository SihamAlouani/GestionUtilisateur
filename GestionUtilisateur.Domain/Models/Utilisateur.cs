using System;
using System.Collections.Generic;

namespace GestionUtilisateur.Domain.Models;

public partial class Utilisateur
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
