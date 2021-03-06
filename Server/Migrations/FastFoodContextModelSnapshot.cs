﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Models;

namespace Server.Migrations
{
    [DbContext(typeof(FastFoodContext))]
    partial class FastFoodContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Server.Models.FastFood", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int>("Cena")
                        .HasColumnType("int")
                        .HasColumnName("Cena");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int")
                        .HasColumnName("Kapacitet");

                    b.Property<int>("M")
                        .HasColumnType("int")
                        .HasColumnName("M");

                    b.Property<int>("N")
                        .HasColumnType("int")
                        .HasColumnName("N");

                    b.Property<string>("Naziv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Naziv");

                    b.HasKey("ID");

                    b.ToTable("FastFood");
                });

            modelBuilder.Entity("Server.Models.Lokacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int?>("FastFoodID")
                        .HasColumnType("int");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int")
                        .HasColumnName("Kapacitet");

                    b.Property<int>("MaxKapacitet")
                        .HasColumnType("int")
                        .HasColumnName("MaxKapacitet");

                    b.Property<int>("X")
                        .HasColumnType("int")
                        .HasColumnName("X");

                    b.Property<int>("Y")
                        .HasColumnType("int")
                        .HasColumnName("Y");

                    b.HasKey("ID");

                    b.HasIndex("FastFoodID");

                    b.ToTable("Lokacija");
                });

            modelBuilder.Entity("Server.Models.Obracun", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int?>("FastFoodID")
                        .HasColumnType("int");

                    b.Property<int>("UkupnaCena")
                        .HasColumnType("int")
                        .HasColumnName("UkupnaCena");

                    b.Property<int>("X")
                        .HasColumnType("int")
                        .HasColumnName("X");

                    b.Property<int>("Y")
                        .HasColumnType("int")
                        .HasColumnName("Y");

                    b.HasKey("ID");

                    b.HasIndex("FastFoodID");

                    b.ToTable("Racuni");
                });

            modelBuilder.Entity("Server.Models.Lokacija", b =>
                {
                    b.HasOne("Server.Models.FastFood", "FastFood")
                        .WithMany("Lokacije")
                        .HasForeignKey("FastFoodID");

                    b.Navigation("FastFood");
                });

            modelBuilder.Entity("Server.Models.Obracun", b =>
                {
                    b.HasOne("Server.Models.FastFood", "FastFood")
                        .WithMany("Racuni")
                        .HasForeignKey("FastFoodID");

                    b.Navigation("FastFood");
                });

            modelBuilder.Entity("Server.Models.FastFood", b =>
                {
                    b.Navigation("Lokacije");

                    b.Navigation("Racuni");
                });
#pragma warning restore 612, 618
        }
    }
}
