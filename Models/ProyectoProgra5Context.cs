using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgra5.Models;

public partial class ProyectoProgra5Context : DbContext
{
    public ProyectoProgra5Context()
    {
    }

    public ProyectoProgra5Context(DbContextOptions<ProyectoProgra5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserxRol> UserxRols { get; set; }

    public virtual DbSet<Votacion> Votacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS; database=ProyectoProgra5; integrated security=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Candidat__3214EC27DA73A49C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Experencia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Partido)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cargos__3214EC27F0B04937");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Partido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partidos__3214EC271557FA7B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fundacion).HasColumnType("date");
            entity.Property(e => e.Lider)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F7646002266");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Accesso).HasColumnName("accesso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F5B61594B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<UserxRol>(entity =>
        {
            entity.HasKey(e => e.IdUsersxRol).HasName("PK__UserxRol__5AC99FB4F83BCA3B");

            entity.ToTable("UserxRol");

            entity.Property(e => e.IdUsersxRol).HasColumnName("idUsersxRol");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UserxRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__UserxRol__idRol__3D5E1FD2");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserxRols)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__UserxRol__idUser__3C69FB99");
        });

        modelBuilder.Entity<Votacion>(entity =>
        {
            entity.HasKey(e => e.IdVotacion).HasName("PK__Votacion__712150FA9ED5B5B7");

            entity.ToTable("Votacion");

            entity.Property(e => e.IdVotacion).HasColumnName("idVotacion");
            entity.Property(e => e.IdCandidato).HasColumnName("idCandidato");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdCandidatoNavigation).WithMany(p => p.Votacions)
                .HasForeignKey(d => d.IdCandidato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Votacion__idCand__2CF2ADDF");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Votacions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Votacion__idUsua__2BFE89A6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
