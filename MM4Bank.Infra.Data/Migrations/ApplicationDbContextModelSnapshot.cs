﻿// <auto-generated />
using System;
using MM4Bank.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MM4Bank.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MM4Bank.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int")
                        .HasColumnName("NR_ACCOUNT");

                    b.Property<decimal>("Balance")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("VL_BALANCE");

                    b.Property<Guid>("ClientId")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_CLIENT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_CREATED");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("ST_ISACTIVE");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_UPDATED");

                    b.HasKey("Id");

                    b.ToTable("TB_ACCOUNT");
                });

            modelBuilder.Entity("MM4Bank.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("AccountId")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_ACCOUNT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("DS_ADRESS");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("NR_CPF");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_CREATED");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("ST_ISACTIVE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NM_NAME");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("DS_PASSWORD");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_UPDATED");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("TB_CLIENT");
                });

            modelBuilder.Entity("MM4Bank.Domain.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_CREATED");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("ST_ISACTIVE");

                    b.Property<Guid>("SourceAccountId")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_SOURCE_ACCOUNT");

                    b.Property<Guid>("TargetAccountId")
                        .HasMaxLength(100)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID_TARGET_ACCOUNT");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("DS_TYPE");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_UPDATED");

                    b.Property<decimal>("Value")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("VL_VALUE");

                    b.HasKey("Id");

                    b.HasIndex("SourceAccountId");

                    b.HasIndex("TargetAccountId");

                    b.ToTable("TB_TRANSACTION");
                });

            modelBuilder.Entity("MM4Bank.Domain.Entities.Client", b =>
                {
                    b.HasOne("MM4Bank.Domain.Entities.Account", "Account")
                        .WithOne("Client")
                        .HasForeignKey("MM4Bank.Domain.Entities.Client", "AccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MM4Bank.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("MM4Bank.Domain.Entities.Account", "SourceAccount")
                        .WithMany("Withdrawals")
                        .HasForeignKey("SourceAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MM4Bank.Domain.Entities.Account", "TargetAccount")
                        .WithMany("Deposits")
                        .HasForeignKey("TargetAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SourceAccount");

                    b.Navigation("TargetAccount");
                });

            modelBuilder.Entity("MM4Bank.Domain.Entities.Account", b =>
                {
                    b.Navigation("Client")
                        .IsRequired();

                    b.Navigation("Deposits");

                    b.Navigation("Withdrawals");
                });
#pragma warning restore 612, 618
        }
    }
}
