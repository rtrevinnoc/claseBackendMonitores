﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monitores;

#nullable disable

namespace Monitores.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Monitores.Entidades.EMonitor", b =>
                {
                    b.Property<Guid>("EMonitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("brand")
                        .HasColumnType("int");

                    b.Property<int>("displayType")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("refreshRate")
                        .HasColumnType("int");

                    b.Property<float>("size")
                        .HasColumnType("real");

                    b.HasKey("EMonitorId");

                    b.HasIndex("RoomId");

                    b.ToTable("Monitors");
                });

            modelBuilder.Entity("Monitores.Entidades.Room", b =>
                {
                    b.Property<Guid>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("length")
                        .HasColumnType("real");

                    b.Property<float>("width")
                        .HasColumnType("real");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Monitores.Entidades.EMonitor", b =>
                {
                    b.HasOne("Monitores.Entidades.Room", "Room")
                        .WithMany("monitors")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Monitores.Entidades.Room", b =>
                {
                    b.Navigation("monitors");
                });
#pragma warning restore 612, 618
        }
    }
}
