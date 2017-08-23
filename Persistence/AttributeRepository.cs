using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class AttributeRepository : IAttributeRepository
    {

        private readonly NxsDbContext context;

        public AttributeRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<Attribute> GetAttribute(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Attributes.FindAsync(id);

            return await context.Attributes
              .SingleOrDefaultAsync(p => p.Id == id);
        }


        public async Task<Attribute> GetAttributeByName(string name, bool includeRelated = true)
        {
            return await context.Attributes
              .SingleOrDefaultAsync(p => p.Name == name);
        }


        public void Add(Attribute Attribute)
        {
            context.Attributes.Add(Attribute);
        }

        public void Remove(Attribute Attribute)
        {
            context.Remove(Attribute);
        }


    }
}