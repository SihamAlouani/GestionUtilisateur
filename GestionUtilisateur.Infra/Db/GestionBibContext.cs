using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionUtilisateur.Domain.Models;

public partial class GestionBibContext : DbContext
{
    public GestionBibContext()
    {
    }

    public GestionBibContext(DbContextOptions<GestionBibContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<UtilisateurRole> UtilisateurRoles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning  To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=SIHAM;Database=GestionBib;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.NameRole).HasMaxLength(100);
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.IdUtilisateur);

            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Sexe).HasMaxLength(10);
        });

        modelBuilder.Entity<UtilisateurRole>(entity =>
        {
            entity.HasKey(e => e.RoleUtisateurId);

            entity.HasIndex(e => e.RoleId, "IX_UtilisateurRoles_RoleId");

            entity.HasIndex(e => e.UtilisateurIdUtilisateur, "IX_UtilisateurRoles_UtilisateurIdUtilisateur");

            entity.HasOne(d => d.Role).WithMany(p => p.UtilisateurRoles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.UtilisateurIdUtilisateurNavigation).WithMany(p => p.UtilisateurRoles).HasForeignKey(d => d.UtilisateurIdUtilisateur);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
