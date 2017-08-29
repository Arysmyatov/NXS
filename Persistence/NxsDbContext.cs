using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class NxsDbContext : IdentityDbContext<NxsUser>
    {
        public NxsDbContext(DbContextOptions<NxsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<ParentRegion> ParentRegions { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<VariableGroup> VariableGroups { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<VariableXls> VariableXls { get; set; }
        public DbSet<VariableXlsDescription> VariableXlsDescriptions { get; set; }
        public DbSet<SubVariable> SubVariables { get; set; }        
        public DbSet<SubVariableData> SubVariableData { get; set; }        
        public DbSet<KeyParameter> KeyParameters { get; set; }
        public DbSet<KeyParameterGroup> KeyParameterGroups { get; set; }
        public DbSet<KeyParameterLevel> KeyParameterLevels { get; set; }
        public DbSet<Data> Data { get; set; }
        public DbSet<XlsUpload> XlsUploads { get; set; }
        public DbSet<RegionAgrigationType> RegionAgrigationTypes { get; set; }
        public DbSet<NxsUser> Users { get; set; }
        public DbSet<ProcessSet> ProcessSet { get; set; }        
        public DbSet<Commodity> Commodities { get; set; }        
        public DbSet<CommoditySet> CommoditySet { get; set; }        
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<UserConstraint> UserConstraints { get; set; }
        public DbSet<VariableData> VariableData { get; set; }   
        public DbSet<AgrigationXlsDescription> AgrigationXlsDescriptions { get; set; }                
        public DbSet<AgreegationSubVariable> AgreegationSubVariables { get; set; }
        public DbSet<AgreegationSubVariableSubVariable> AgreegationSubVariableSubVariables { get; set; }                
        public DbSet<ContactUsMessage> ContactUsMessages { get; set; }                
    }
}