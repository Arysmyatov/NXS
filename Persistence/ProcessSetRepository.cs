using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class ProcessSetRepository : IProcessSetRepository
    {

        private readonly NxsDbContext context;

        public ProcessSetRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<ProcessSet> GetProcessSet(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.ProcessSet.FindAsync(id);

            return await context.ProcessSet
              .SingleOrDefaultAsync(p => p.Id == id);
        }


        public async Task<ProcessSet> GetProcessSetByName(string name, bool includeRelated = true)
        {
            return await context.ProcessSet
              .SingleOrDefaultAsync(p => p.Name == name);
        }


        public void Add(ProcessSet ProcessSet)
        {
            context.ProcessSet.Add(ProcessSet);
        }

        public void Remove(ProcessSet ProcessSet)
        {
            context.Remove(ProcessSet);
        }

    }
}