﻿// <auto-generated />
using System;
using Exam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Exam.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Exam.Entities.Color", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Modificationid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Modificationid");

                    b.ToTable("colores");
                });

            modelBuilder.Entity("Exam.Entities.Model_", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("models");
                });

            modelBuilder.Entity("Exam.Entities.Modification", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Model_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Model_id");

                    b.ToTable("modifications");
                });

            modelBuilder.Entity("Exam.Entities.Color", b =>
                {
                    b.HasOne("Exam.Entities.Modification", null)
                        .WithMany("colors")
                        .HasForeignKey("Modificationid");
                });

            modelBuilder.Entity("Exam.Entities.Modification", b =>
                {
                    b.HasOne("Exam.Entities.Model_", null)
                        .WithMany("modifications_")
                        .HasForeignKey("Model_id");
                });

            modelBuilder.Entity("Exam.Entities.Model_", b =>
                {
                    b.Navigation("modifications_");
                });

            modelBuilder.Entity("Exam.Entities.Modification", b =>
                {
                    b.Navigation("colors");
                });
#pragma warning restore 612, 618
        }
    }
}