using AutoMapper;
using GestionUtilisateur.Application.Interfaces;
using GestionUtilisateur.Application.ViewModel;
using GestionUtilisateur.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Infra.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {

        private readonly GestionBibContext _dBContext;
        private IMapper _mapper;

        public UtilisateurRepository(GestionBibContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }
        public async Task<Utilisateur> CreateAsync(Utilisateur utilisateur)
        {
            await _dBContext.Utilisateurs.AddAsync(utilisateur);
            await _dBContext.SaveChangesAsync();
            return utilisateur;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _dBContext.Utilisateurs
               .Where(model => model.IdUtilisateur == id)
               .ExecuteDeleteAsync();
        }

        public async Task<List<Utilisateur>> GetAllUtilisateurAsync()
        {
            return await _dBContext.Utilisateurs.ToListAsync();
        }

        public async Task<Utilisateur> GetByIdAsync(int id)
        {
            return await _dBContext.Utilisateurs.AsNoTracking()
               .FirstOrDefaultAsync(u => u.IdUtilisateur == id);
        }

        public async Task<int> UpdateAsync(int id, UtilisateurViewModel utilisateur)
        {
            var updatedUser = _mapper.Map<Utilisateur>(utilisateur);
            var user = await _dBContext.Utilisateurs.FindAsync(id);
            _dBContext.Entry(user).CurrentValues.SetValues(updatedUser);
            await _dBContext.SaveChangesAsync();
            return 1;
        }
    }
}
