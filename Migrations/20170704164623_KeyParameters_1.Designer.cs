﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NXS.Persistence;

namespace NXS.Migrations
{
    [DbContext(typeof(NxsDbContext))]
    [Migration("20170704164623_KeyParameters_1")]
    partial class KeyParameters_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NXS.Models.KeyParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KeyParameterGroupId");

                    b.Property<int?>("KeyParameterLevelId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("KeyParameterGroupId");

                    b.HasIndex("KeyParameterLevelId");

                    b.ToTable("KeyParameters");
                });

            modelBuilder.Entity("NXS.Models.KeyParameterGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("KeyParameterGroups");
                });

            modelBuilder.Entity("NXS.Models.KeyParameterLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("KeyParameterLevels");
                });

            modelBuilder.Entity("NXS.Models.ParentRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ParentRegions");
                });

            modelBuilder.Entity("NXS.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("ParentRegionId");

                    b.HasKey("Id");

                    b.HasIndex("ParentRegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("NXS.Models.Scenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Scenarios");
                });

            modelBuilder.Entity("NXS.Models.Variable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("VariableGroupId");

                    b.HasKey("Id");

                    b.HasIndex("VariableGroupId");

                    b.ToTable("Variables");
                });

            modelBuilder.Entity("NXS.Models.VariableGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("VariableGroups");
                });

            modelBuilder.Entity("NXS.Models.KeyParameter", b =>
                {
                    b.HasOne("NXS.Models.KeyParameterGroup")
                        .WithMany("KeyParameters")
                        .HasForeignKey("KeyParameterGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Models.KeyParameterLevel", "KeyParameterLevel")
                        .WithMany("KeyParameters")
                        .HasForeignKey("KeyParameterLevelId");
                });

            modelBuilder.Entity("NXS.Models.Region", b =>
                {
                    b.HasOne("NXS.Models.ParentRegion")
                        .WithMany("Regions")
                        .HasForeignKey("ParentRegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Models.Variable", b =>
                {
                    b.HasOne("NXS.Models.VariableGroup")
                        .WithMany("Variables")
                        .HasForeignKey("VariableGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}