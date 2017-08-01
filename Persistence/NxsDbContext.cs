using Microsoft.EntityFrameworkCore;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class NxsDbContext : DbContext
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
        public DbSet<SubVariable> SubVariables { get; set; }        
        public DbSet<KeyParameter> KeyParameters { get; set; }
        public DbSet<KeyParameterGroup> KeyParameterGroups { get; set; }
        public DbSet<KeyParameterLevel> KeyParameterLevels { get; set; }
        public DbSet<Data> Data { get; set; }
        public DbSet<XlsUpload> XlsUploads { get; set; }
        public DbSet<XlsRegionType> XlsRegionTypes { get; set; }
    }
}