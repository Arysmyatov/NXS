using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NXS.Persistence;

namespace NXS.Migrations
{
    [DbContext(typeof(NxsDbContext))]
    partial class NxsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("SubVariableId");

                    b.Property<decimal>("Value");

                    b.Property<int>("VariableId");

                    b.Property<string>("Year")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("KeyParameterId");

                    b.HasIndex("KeyParameterLevelId");

                    b.HasIndex("RegionId");

                    b.HasIndex("ScenarioId");

                    b.HasIndex("SubVariableId");

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

            modelBuilder.Entity("NXS.Core.Models.SubVariable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("SubVariables");
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

            modelBuilder.Entity("NXS.Core.Models.VariableXls", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("DataBgCol");

                    b.Property<int>("DataBgRow");

                    b.Property<int>("DataEndCol");

                    b.Property<int>("DataEndRow");

                    b.Property<string>("SheetName");

                    b.Property<int>("VariableId");

                    b.Property<int>("YearBgCol");

                    b.Property<int>("YearBgRow");

                    b.Property<int>("YearEndCol");

                    b.Property<int>("YearEndRow");

                    b.HasKey("Id");

                    b.HasIndex("VariableId")
                        .IsUnique();

                    b.ToTable("VariableXls");
                });

            modelBuilder.Entity("NXS.Core.Models.XlsUpload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("KeyParameterId");

                    b.Property<int>("KeyParameterLevelId");

                    b.Property<int?>("RegionId");

                    b.Property<int>("ScenarioId");

                    b.Property<DateTime>("UploadDate");

                    b.HasKey("Id");

                    b.HasIndex("KeyParameterLevelId");

                    b.HasIndex("RegionId");

                    b.HasIndex("ScenarioId");

                    b.ToTable("XlsUploads");
                });

            modelBuilder.Entity("NXS.Core.Models.Data", b =>
                {
                    b.HasOne("NXS.Core.Models.KeyParameter", "KeyParameter")
                        .WithMany("Data")
                        .HasForeignKey("KeyParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.KeyParameterLevel", "KeyParameterLevel")
                        .WithMany()
                        .HasForeignKey("KeyParameterLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.Region", "Region")
                        .WithMany("Data")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.Scenario", "Scenario")
                        .WithMany("Data")
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.SubVariable", "SubVariable")
                        .WithMany("Data")
                        .HasForeignKey("SubVariableId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.Variable", "Variable")
                        .WithMany()
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

            modelBuilder.Entity("NXS.Core.Models.VariableXls", b =>
                {
                    b.HasOne("NXS.Core.Models.Variable")
                        .WithOne("VariableXls")
                        .HasForeignKey("NXS.Core.Models.VariableXls", "VariableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.XlsUpload", b =>
                {
                    b.HasOne("NXS.Core.Models.KeyParameterLevel")
                        .WithMany("XlsUploads")
                        .HasForeignKey("KeyParameterLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.Region")
                        .WithMany("XlsUploads")
                        .HasForeignKey("RegionId");

                    b.HasOne("NXS.Core.Models.Scenario")
                        .WithMany("XlsUploads")
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
