﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SQLProcedureConvert.DataAccess;

#nullable disable

namespace SQLProcedureConvert.DataAccess.Migrations
{
    [DbContext(typeof(ProjectDBContext))]
    [Migration("20240411114731_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SQLProcedureConvert.Domain.Models.Application", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ContactID")
                        .HasColumnType("int");

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ContactID");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("SQLProcedureConvert.Domain.Models.ChangeApplicationStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ApplicationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NewStatus")
                        .HasColumnType("int");

                    b.Property<int>("StatusFrom")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ApplicationID");

                    b.ToTable("ChangeApplicationStatus");
                });

            modelBuilder.Entity("SQLProcedureConvert.Domain.Models.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("SQLProcedureConvert.Domain.Models.Application", b =>
                {
                    b.HasOne("SQLProcedureConvert.Domain.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("SQLProcedureConvert.Domain.Models.ChangeApplicationStatus", b =>
                {
                    b.HasOne("SQLProcedureConvert.Domain.Models.Application", "Application")
                        .WithMany("ChangeApplicationStatus")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("SQLProcedureConvert.Domain.Models.Application", b =>
                {
                    b.Navigation("ChangeApplicationStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
