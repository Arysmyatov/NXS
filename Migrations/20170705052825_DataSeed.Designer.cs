using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NXS.Persistence;

namespace NXS.Migrations
{
    [DbContext(typeof(NxsDbContext))]
    [Migration("20170705052825_DataSeed")]
    partial class DataSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NXS.Core.Models.Data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KeyParameterId");

                    b.Property<int>("KeyParameterLevelId");

                    b.Property<int>("RegionId");

                    b.Property<int>("ScenarioId");

                    b.Property<decimal>("Value");

                    b.Property<int>("VariableId");

                    b.Property<string>("Year")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("KeyParameterId");

                    b.HasIndex("RegionId");

                    b.HasIndex("ScenarioId");

                    b.HasIndex("VariableId");

                    b.ToTable("Data");
                });

            modelBuilder.Entity("NXS.Core.Models.KeyParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KeyParameterGroupId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("KeyParameterGroupId");

                    b.ToTable("KeyParameters");
                });

            modelBuilder.Entity("NXS.Core.Models.KeyParameterGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("KeyParameterGroups");
                });

            modelBuilder.Entity("NXS.Core.Models.KeyParameterLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("KeyParameterLevels");
                });

            modelBuilder.Entity("NXS.Core.Models.ParentRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ParentRegions");
                });

            modelBuilder.Entity("NXS.Core.Models.Region", b =>
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

            modelBuilder.Entity("NXS.Core.Models.Scenario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Scenarios");
                });

            modelBuilder.Entity("NXS.Core.Models.Variable", b =>
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

            modelBuilder.Entity("NXS.Core.Models.VariableGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("VariableGroups");
                });

            modelBuilder.Entity("NXS.Core.Models.Data", b =>
                {
                    b.HasOne("NXS.Core.Models.KeyParameter")
                        .WithMany("Data")
                        .HasForeignKey("KeyParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.Region")
                        .WithMany("Data")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.Scenario")
                        .WithMany("Data")
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.Variable")
                        .WithMany("Data")
                        .HasForeignKey("VariableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.KeyParameter", b =>
                {
                    b.HasOne("NXS.Core.Models.KeyParameterGroup")
                        .WithMany("KeyParameters")
                        .HasForeignKey("KeyParameterGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.Region", b =>
                {
                    b.HasOne("NXS.Core.Models.ParentRegion")
                        .WithMany("Regions")
                        .HasForeignKey("ParentRegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.Variable", b =>
                {
                    b.HasOne("NXS.Core.Models.VariableGroup")
                        .WithMany("Variables")
                        .HasForeignKey("VariableGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
