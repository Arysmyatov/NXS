using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class UserConstraintRepository : IUserConstraintRepository
    {
        private readonly NxsDbContext context;

        public UserConstraintRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<UserConstraint> GetUserConstraint(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.UserConstraints.FindAsync(id);

            return await context.UserConstraints
              .SingleOrDefaultAsync(p => p.Id == id);
        }


        public async Task<UserConstraint> GetUserConstraintByName(string name, bool includeRelated = true)
        {
            return await context.UserConstraints
              .SingleOrDefaultAsync(p => p.Name == name);
        }


        public void Add(UserConstraint UserConstraint)
        {
            context.UserConstraints.Add(UserConstraint);
        }

        public void Remove(UserConstraint UserConstraint)
        {
            context.Remove(UserConstraint);
        }
        
    }
}