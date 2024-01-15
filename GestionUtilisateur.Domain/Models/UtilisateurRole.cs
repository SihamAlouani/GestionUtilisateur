using System;
using System.Collections.Generic;

namespace GestionUtilisateur.Domain.Models;

public partial class UtilisateurRole
{
    public int RoleUtisateurId { get; set; }

    public int RoleId { get; set; }

    public int IdUtilisateur { get; set; }

    public int UtilisateurIdUtilisateur { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Utilisateur UtilisateurIdUtilisateurNavigation { get; set; } = null!;
}
