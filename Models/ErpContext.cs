using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.Models;

public partial class ErpContext : DbContext
{
    public ErpContext(DbContextOptions<ErpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LanguagesLevel> LanguagesLevels { get; set; }

    public virtual DbSet<LinesOfBusiness> LinesOfBusinesses { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__349DA5862A8CC37D");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.AccountName).HasMaxLength(250);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC2784877490");

            entity.HasIndex(e => e.AccountId, "IX_Employees_AccountID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Age).HasComputedColumnSql("(datediff(year,[DateOfBirth],getdate()))", false);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NationalId)
                .HasMaxLength(14)
                .HasColumnName("NationalID");

            entity.HasOne(d => d.Account).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_Employees_AccountID");
        });

        modelBuilder.Entity<EmployeeLanguage>(entity =>
        {
            entity.HasKey(e => e.EmplpoyeeLangaugeId).HasName("PK__Employee__11968AA384D0F179");

            entity.HasIndex(e => e.EmployeeId, "IX_EmployeeLanguages_EmployeeID");

            entity.HasIndex(e => e.LanguageId, "IX_EmployeeLanguages_LanguageID");

            entity.Property(e => e.EmplpoyeeLangaugeId).HasColumnName("EmplpoyeeLangaugeID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.LanguageLevel)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeLanguages)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__EmployeeL__Emplo__5165187F");

            entity.HasOne(d => d.Language).WithMany(p => p.EmployeeLanguages)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK__EmployeeL__Langu__5070F446");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__B938558B8DD40A10");

            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.LanguageName).HasMaxLength(250);
        });

        modelBuilder.Entity<LanguagesLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3214EC27D9291F47");

            entity.HasIndex(e => e.LanguageId, "IX_LanguagesLevels_LanguageID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.LanguageLevel).HasMaxLength(2);

            entity.HasOne(d => d.Language).WithMany(p => p.LanguagesLevels)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Language_Levels");
        });

        modelBuilder.Entity<LinesOfBusiness>(entity =>
        {
            entity.HasKey(e => e.LineOfBusinessId).HasName("PK__LineOfBu__5875A02238E331D3");

            entity.ToTable("LinesOfBusiness");

            entity.HasIndex(e => e.AccountId, "IX_LinesOfBusiness_AccountID");

            entity.Property(e => e.LineOfBusinessId).HasColumnName("LineOfBusinessID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.LineOfBusinessName).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.LinesOfBusinesses)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_LinesOfBusiness_AccountID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
