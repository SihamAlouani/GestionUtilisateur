﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Infra.Db
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions <AuthDbContext> options) : base(options)
        {
        }
    }
}
