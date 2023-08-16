﻿// <auto-generated />
using System;
using ERPSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERPSystem.Migrations
{
    [DbContext(typeof(ErpContext))]
    partial class ErpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ERPSystem.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("AccountId")
                        .HasName("PK__Accounts__349DA5862A8CC37D");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ERPSystem.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(MAX)");

                    b.Property<byte[]>("SaltKey")
                        .IsRequired()
                        .HasColumnType("varbinary(MAX)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ERPSystem.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<int?>("Age")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasComputedColumnSql("(datediff(year,[DateOfBirth],getdate()))", false);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NationalId")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("NationalID");

                    b.HasKey("Id")
                        .HasName("PK__Employee__3214EC2784877490");

                    b.HasIndex(new[] { "AccountId" }, "IX_Employees_AccountID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ERPSystem.Models.EmployeeLanguage", b =>
                {
                    b.Property<int>("EmplpoyeeLangaugeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmplpoyeeLangaugeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmplpoyeeLangaugeId"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int")
                        .HasColumnName("LanguageID");

                    b.Property<string>("LanguageLevel")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.HasKey("EmplpoyeeLangaugeId")
                        .HasName("PK__Employee__11968AA384D0F179");

                    b.HasIndex(new[] { "EmployeeId" }, "IX_EmployeeLanguages_EmployeeID");

                    b.HasIndex(new[] { "LanguageId" }, "IX_EmployeeLanguages_LanguageID");

                    b.ToTable("EmployeeLanguages");
                });

            modelBuilder.Entity("ERPSystem.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LanguageID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"));

                    b.Property<string>("LanguageName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("LanguageId")
                        .HasName("PK__Language__B938558B8DD40A10");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("ERPSystem.Models.LanguagesLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LanguageId")
                        .HasColumnType("int")
                        .HasColumnName("LanguageID");

                    b.Property<string>("LanguageLevel")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Id")
                        .HasName("PK__Language__3214EC27D9291F47");

                    b.HasIndex(new[] { "LanguageId" }, "IX_LanguagesLevels_LanguageID");

                    b.ToTable("LanguagesLevels");
                });

            modelBuilder.Entity("ERPSystem.Models.LinesOfBusiness", b =>
                {
                    b.Property<int>("LineOfBusinessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LineOfBusinessID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LineOfBusinessId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<string>("LineOfBusinessName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("LineOfBusinessId")
                        .HasName("PK__LineOfBu__5875A02238E331D3");

                    b.HasIndex(new[] { "AccountId" }, "IX_LinesOfBusiness_AccountID");

                    b.ToTable("LinesOfBusiness", (string)null);
                });

            modelBuilder.Entity("ERPSystem.Models.Employee", b =>
                {
                    b.HasOne("ERPSystem.Models.Account", "Account")
                        .WithMany("Employees")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_Employees_AccountID");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ERPSystem.Models.EmployeeLanguage", b =>
                {
                    b.HasOne("ERPSystem.Models.Employee", "Employee")
                        .WithMany("EmployeeLanguages")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__EmployeeL__Emplo__5165187F");

                    b.HasOne("ERPSystem.Models.Language", "Language")
                        .WithMany("EmployeeLanguages")
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("FK__EmployeeL__Langu__5070F446");

                    b.Navigation("Employee");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("ERPSystem.Models.LanguagesLevel", b =>
                {
                    b.HasOne("ERPSystem.Models.Language", "Language")
                        .WithMany("LanguagesLevels")
                        .HasForeignKey("LanguageId")
                        .IsRequired()
                        .HasConstraintName("FK_Language_Levels");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("ERPSystem.Models.LinesOfBusiness", b =>
                {
                    b.HasOne("ERPSystem.Models.Account", "Account")
                        .WithMany("LinesOfBusinesses")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_LinesOfBusiness_AccountID");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ERPSystem.Models.Account", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("LinesOfBusinesses");
                });

            modelBuilder.Entity("ERPSystem.Models.Employee", b =>
                {
                    b.Navigation("EmployeeLanguages");
                });

            modelBuilder.Entity("ERPSystem.Models.Language", b =>
                {
                    b.Navigation("EmployeeLanguages");

                    b.Navigation("LanguagesLevels");
                });
#pragma warning restore 612, 618
        }
    }
}