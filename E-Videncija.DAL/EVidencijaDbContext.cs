using System;
using System.Collections.Generic;
using E_Videncija.DAL.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Videncija.DAL;

public partial class EVidencijaDbContext : DbContext
{
    public EVidencijaDbContext()
    {
    }

    public EVidencijaDbContext(DbContextOptions<EVidencijaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EvidentiranMjesec> EvidentiranMjesecs { get; set; }

    public virtual DbSet<EvidentiranoVrijeme> EvidentiranoVrijemes { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<RadnaSmjenaDani> RadnaSmjenaDanis { get; set; }

    public virtual DbSet<RadnaSmjenaEvidencijaRadnika> RadnaSmjenaEvidencijaRadnikas { get; set; }

    public virtual DbSet<RadnaSmjenaRadnici> RadnaSmjenaRadnicis { get; set; }

    public virtual DbSet<RadnaSmjene> RadnaSmjenes { get; set; }

    public virtual DbSet<RadnikPlaca> RadnikPlacas { get; set; }

    public virtual DbSet<TvrtkaConfig> TvrtkaConfigs { get; set; }

    public virtual DbSet<UserInformation> UserInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("name=E-Videncija");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EvidentiranMjesec>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__evidenti__3213E83F9868B05F");
        });

        modelBuilder.Entity<EvidentiranoVrijeme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__evidenti__3213E83FEB4EDED8");

            entity.Property(e => e.SatiZastojaDo).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.SatiZastojaOd).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.EvidentiranMjesec).WithMany(p => p.EvidentiranoVrijemes).HasConstraintName("FK__evidentir__evide__5DCAEF64");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<RadnaSmjenaDani>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__radna_sm__3213E83FC9169469");

            entity.HasOne(d => d.IdRadnaSmjenaNavigation).WithMany(p => p.RadnaSmjenaDanis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__radna_smj__id_ra__4BAC3F29");
        });

        modelBuilder.Entity<RadnaSmjenaEvidencijaRadnika>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__radna_sm__3213E83FA56C2593");

            entity.Property(e => e.Evidentirano).HasDefaultValue("U tijeku");

            entity.HasOne(d => d.IdRadnaSmjenaRadniciNavigation).WithMany(p => p.RadnaSmjenaEvidencijaRadnikas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__radna_smj__id_ra__4F7CD00D");
        });

        modelBuilder.Entity<RadnaSmjenaRadnici>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__radna_sm__3213E83FEE5EC0E3");

            entity.HasOne(d => d.IdRadnaSmjenaDaniNavigation).WithMany(p => p.RadnaSmjenaRadnicis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__radna_smj__id_ra__4CA06362");

            entity.HasOne(d => d.IdUserInformationNavigation).WithMany(p => p.RadnaSmjenaRadnicis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__radna_smj__id_us__5070F446");
        });

        modelBuilder.Entity<RadnaSmjene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__radna_sm__3213E83F34E91E23");

            entity.Property(e => e.PosebniDan).HasDefaultValue(false);
        });

        modelBuilder.Entity<RadnikPlaca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__radnik_p__3213E83F5855637F");

            entity.HasOne(d => d.IdEvidentiranogMjesecaNavigation).WithMany(p => p.RadnikPlacas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__radnik_pl__id_ev__4D94879B");

            entity.HasOne(d => d.IdRadnikNavigation).WithMany(p => p.RadnikPlacas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__radnik_pl__id_ra__4E88ABD4");
        });

        modelBuilder.Entity<UserInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_inf__3213E83FC185FEF8");

            entity.Property(e => e.Spol).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
