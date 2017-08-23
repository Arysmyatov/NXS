using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NXS.Persistence;

namespace NXS.Migrations
{
    [DbContext(typeof(NxsDbContext))]
    [Migration("20170821152101_AgrigationXlsDescription")]
    partial class AgrigationXlsDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NXS.Core.Models.AgrigationXlsDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AttributeCol");

                    b.Property<int>("CommodityCol");

                    b.Property<int>("CommoditySetCol");

                    b.Property<int>("ProcessSetCol");

                    b.Property<int>("RegionAgrigationTypeId");

                    b.Property<int>("RowBg");

                    b.Property<int>("RowEnd");

                    b.Property<string>("SheetName");

                    b.Property<int>("SubVariableCol");

                    b.Property<int>("UserConstraintCol");

                    b.Property<int>("VariableId");

                    b.Property<int>("YearColBg");

                    b.Property<int>("YearColEnd");

                    b.Property<int>("YearRowBg");

                    b.HasKey("Id");

                    b.HasIndex("VariableId");

                    b.ToTable("AgrigationXlsDescriptions");
                });

            modelBuilder.Entity("NXS.Core.Models.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("NXS.Core.Models.Commodity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Commodities");
                });

            modelBuilder.Entity("NXS.Core.Models.CommoditySet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CommoditySet");
                });

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

            modelBuilder.Entity("NXS.Core.Models.NxsUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<int?>("ParentRegionId");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("ParentRegionId");

                    b.ToTable("AspNetUsers");
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

            modelBuilder.Entity("NXS.Core.Models.ProcessSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProcessSet");
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

            modelBuilder.Entity("NXS.Core.Models.RegionAgrigationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RegionAgrigationTypes");
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

            modelBuilder.Entity("NXS.Core.Models.SubVariableData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AttributeId");

                    b.Property<int?>("CommodityId");

                    b.Property<int?>("CommoditySetId");

                    b.Property<int>("KeyParameterId");

                    b.Property<int>("KeyParameterLevelId");

                    b.Property<int?>("ProcessSetId");

                    b.Property<int>("RegionAgrigationTypeId");

                    b.Property<int?>("RegionId");

                    b.Property<int>("ScenarioId");

                    b.Property<int>("SubVariableId");

                    b.Property<int?>("UserConstraintId");

                    b.Property<decimal>("Value");

                    b.Property<int>("VariableId");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("CommoditySetId");

                    b.HasIndex("KeyParameterId");

                    b.HasIndex("KeyParameterLevelId");

                    b.HasIndex("ProcessSetId");

                    b.HasIndex("RegionAgrigationTypeId");

                    b.HasIndex("RegionId");

                    b.HasIndex("ScenarioId");

                    b.HasIndex("SubVariableId");

                    b.HasIndex("UserConstraintId");

                    b.HasIndex("VariableId");

                    b.ToTable("SubVariableData");
                });

            modelBuilder.Entity("NXS.Core.Models.UserConstraint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("UserConstraint");
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

            modelBuilder.Entity("NXS.Core.Models.VariableData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AttributeId");

                    b.Property<int?>("CommodityId");

                    b.Property<int?>("CommoditySetId");

                    b.Property<int>("KeyParameterId");

                    b.Property<int>("KeyParameterLevelId");

                    b.Property<int?>("ProcessSetId");

                    b.Property<int?>("RegionId");

                    b.Property<int>("ScenarioId");

                    b.Property<int?>("UserConstraintId");

                    b.Property<decimal>("Value");

                    b.Property<int>("VariableId");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("CommoditySetId");

                    b.HasIndex("KeyParameterId");

                    b.HasIndex("KeyParameterLevelId");

                    b.HasIndex("ProcessSetId");

                    b.HasIndex("RegionId");

                    b.HasIndex("ScenarioId");

                    b.HasIndex("UserConstraintId");

                    b.HasIndex("VariableId");

                    b.ToTable("VariableData");
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

            modelBuilder.Entity("NXS.Core.Models.VariableXlsDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AttributeCol");

                    b.Property<int>("CommodityCol");

                    b.Property<int>("CommoditySetCol");

                    b.Property<int>("ProcessSetCol");

                    b.Property<int>("RegionCol");

                    b.Property<int>("RowBg");

                    b.Property<int>("RowEnd");

                    b.Property<string>("SheetName");

                    b.Property<int>("UserConstraintCol");

                    b.Property<int>("VariableId");

                    b.Property<int>("YearColBg");

                    b.Property<int>("YearColEnd");

                    b.HasKey("Id");

                    b.HasIndex("VariableId")
                        .IsUnique();

                    b.ToTable("VariableXlsDescriptions");
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

                    b.Property<int>("ScenarioId");

                    b.Property<DateTime>("UploadDate");

                    b.HasKey("Id");

                    b.HasIndex("KeyParameterLevelId");

                    b.HasIndex("ScenarioId");

                    b.ToTable("XlsUploads");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NXS.Core.Models.NxsUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NXS.Core.Models.NxsUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.NxsUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.AgrigationXlsDescription", b =>
                {
                    b.HasOne("NXS.Core.Models.Variable", "Variable")
                        .WithMany()
                        .HasForeignKey("VariableId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.Scenario", "Scenario")
                        .WithMany("Data")
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.SubVariable", "SubVariable")
                        .WithMany()
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

            modelBuilder.Entity("NXS.Core.Models.NxsUser", b =>
                {
                    b.HasOne("NXS.Core.Models.ParentRegion", "ParentRegion")
                        .WithMany("Users")
                        .HasForeignKey("ParentRegionId");
                });

            modelBuilder.Entity("NXS.Core.Models.Region", b =>
                {
                    b.HasOne("NXS.Core.Models.ParentRegion")
                        .WithMany("Regions")
                        .HasForeignKey("ParentRegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.SubVariableData", b =>
                {
                    b.HasOne("NXS.Core.Models.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId");

                    b.HasOne("NXS.Core.Models.CommoditySet", "CommoditySet")
                        .WithMany()
                        .HasForeignKey("CommoditySetId");

                    b.HasOne("NXS.Core.Models.KeyParameter", "KeyParameter")
                        .WithMany()
                        .HasForeignKey("KeyParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.KeyParameterLevel", "KeyParameterLevel")
                        .WithMany()
                        .HasForeignKey("KeyParameterLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.ProcessSet", "ProcessSet")
                        .WithMany()
                        .HasForeignKey("ProcessSetId");

                    b.HasOne("NXS.Core.Models.RegionAgrigationType", "RegionAgrigationType")
                        .WithMany()
                        .HasForeignKey("RegionAgrigationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.HasOne("NXS.Core.Models.Scenario", "Scenario")
                        .WithMany()
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.SubVariable", "SubVariable")
                        .WithMany()
                        .HasForeignKey("SubVariableId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.UserConstraint", "UserConstraint")
                        .WithMany()
                        .HasForeignKey("UserConstraintId");

                    b.HasOne("NXS.Core.Models.Variable", "Variable")
                        .WithMany()
                        .HasForeignKey("VariableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.Variable", b =>
                {
                    b.HasOne("NXS.Core.Models.VariableGroup")
                        .WithMany("Variables")
                        .HasForeignKey("VariableGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.VariableData", b =>
                {
                    b.HasOne("NXS.Core.Models.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId");

                    b.HasOne("NXS.Core.Models.CommoditySet", "CommoditySet")
                        .WithMany()
                        .HasForeignKey("CommoditySetId");

                    b.HasOne("NXS.Core.Models.KeyParameter", "KeyParameter")
                        .WithMany()
                        .HasForeignKey("KeyParameterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.KeyParameterLevel", "KeyParameterLevel")
                        .WithMany()
                        .HasForeignKey("KeyParameterLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.ProcessSet", "ProcessSet")
                        .WithMany()
                        .HasForeignKey("ProcessSetId");

                    b.HasOne("NXS.Core.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.HasOne("NXS.Core.Models.Scenario", "Scenario")
                        .WithMany()
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.UserConstraint", "UserConstraint")
                        .WithMany()
                        .HasForeignKey("UserConstraintId");

                    b.HasOne("NXS.Core.Models.Variable", "Variable")
                        .WithMany()
                        .HasForeignKey("VariableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.VariableXls", b =>
                {
                    b.HasOne("NXS.Core.Models.Variable")
                        .WithOne("VariableXls")
                        .HasForeignKey("NXS.Core.Models.VariableXls", "VariableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.VariableXlsDescription", b =>
                {
                    b.HasOne("NXS.Core.Models.Variable", "Variable")
                        .WithOne("VariableXlsDescription")
                        .HasForeignKey("NXS.Core.Models.VariableXlsDescription", "VariableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NXS.Core.Models.XlsUpload", b =>
                {
                    b.HasOne("NXS.Core.Models.KeyParameterLevel")
                        .WithMany("XlsUploads")
                        .HasForeignKey("KeyParameterLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NXS.Core.Models.Scenario")
                        .WithMany("XlsUploads")
                        .HasForeignKey("ScenarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
