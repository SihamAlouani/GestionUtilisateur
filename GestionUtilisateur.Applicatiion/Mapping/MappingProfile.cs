using AutoMapper;
using GestionUtilisateur.Application.ViewModel;
using GestionUtilisateur.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Utilisateur, UtilisateurViewModel>().ReverseMap();
        }

    }
}
