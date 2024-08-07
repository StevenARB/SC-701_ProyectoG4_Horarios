﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SC_701_ProyectoG4_Horarios.DAL;

#nullable disable

namespace SC_701_ProyectoG4_Horarios.DAL.Migrations.Horarios
{
    [DbContext(typeof(HorariosContext))]
    partial class HorariosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Clase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Reservacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AulaId")
                        .HasColumnType("int");

                    b.Property<int?>("ClaseId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly>("HoraFin")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioCreacionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsuarioModificacionId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AulaId");

                    b.HasIndex("ClaseId");

                    b.HasIndex("ProfesorId");

                    b.HasIndex("UsuarioCreacionId");

                    b.HasIndex("UsuarioModificacionId");

                    b.ToTable("Reservaciones");
                });

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PrimerApellido")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Profesor", b =>
                {
                    b.HasOne("SC_701_ProyectoG4_Horarios.DAL.Usuario", "Usuario")
                        .WithOne("Profesor")
                        .HasForeignKey("SC_701_ProyectoG4_Horarios.DAL.Profesor", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Reservacion", b =>
                {
                    b.HasOne("SC_701_ProyectoG4_Horarios.DAL.Aula", "Aula")
                        .WithMany("Reservaciones")
                        .HasForeignKey("AulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SC_701_ProyectoG4_Horarios.DAL.Clase", "Clase")
                        .WithMany("Reservaciones")
                        .HasForeignKey("ClaseId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SC_701_ProyectoG4_Horarios.DAL.Profesor", "Profesor")
                        .WithMany("Reservaciones")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SC_701_ProyectoG4_Horarios.DAL.Usuario", "UsuarioCreacion")
                        .WithMany("ReservacionesCreacion")
                        .HasForeignKey("UsuarioCreacionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SC_701_ProyectoG4_Horarios.DAL.Usuario", "UsuarioModificacion")
                        .WithMany("ReservacionesModificacion")
                        .HasForeignKey("UsuarioModificacionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Aula");

                    b.Navigation("Clase");

                    b.Navigation("Profesor");

                    b.Navigation("UsuarioCreacion");

                    b.Navigation("UsuarioModificacion");
                });

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Aula", b =>
                {
                    b.Navigation("Reservaciones");
                });

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Clase", b =>
                {
                    b.Navigation("Reservaciones");
                });

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Profesor", b =>
                {
                    b.Navigation("Reservaciones");
                });

            modelBuilder.Entity("SC_701_ProyectoG4_Horarios.DAL.Usuario", b =>
                {
                    b.Navigation("Profesor");

                    b.Navigation("ReservacionesCreacion");

                    b.Navigation("ReservacionesModificacion");
                });
#pragma warning restore 612, 618
        }
    }
}
