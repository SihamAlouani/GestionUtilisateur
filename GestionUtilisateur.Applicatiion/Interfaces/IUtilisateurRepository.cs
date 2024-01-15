using GestionUtilisateur.Application.ViewModel;
using GestionUtilisateur.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.Interfaces
{
    public interface IUtilisateurRepository
    {
        Task<List<Utilisateur>> GetAllUtilisateurAsync();
        Task<Utilisateur> GetByIdAsync(int id);
        Task<Utilisateur> CreateAsync(Utilisateur utilisateur);
        Task<int> UpdateAsync(int id, UtilisateurViewModel utilisateur);
        Task<int> DeleteAsync(int id);
    }
}
