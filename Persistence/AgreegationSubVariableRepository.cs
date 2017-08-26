using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;
using NXS.Extensions;
namespace NXS.Persistence

{
    public class AgreegationSubVariableRepository: IAgreegationSubVariableRepository
    {

        private readonly NxsDbContext context;

        public AgreegationSubVariableRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<AgreegationSubVariable> GetAgreegationSubVariable(int id)
        {
            return await context.AgreegationSubVariables.FindAsync(id);
        }

        public async Task<AgreegationSubVariable> GetAgreegationSubVariable(string name)
        {
            return await context.AgreegationSubVariables.SingleOrDefaultAsync(sv => sv.Name == name);
        }
        

        public void Add(AgreegationSubVariable subVariable)
        {
            context.AgreegationSubVariables.Add(subVariable);
        }

        public void Remove(AgreegationSubVariable subVariable)
        {
            context.Remove(subVariable);
        }


        public async Task<QueryResult<AgreegationSubVariable>> GetAgreegationSubVariablesAsync(AgreegationSubVariableQuery queryObj)
        {
            var result = new QueryResult<AgreegationSubVariable>();

            var query = context.AgreegationSubVariables
              .AsQueryable();

            query = query.ApplyFiltering(queryObj);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }    


        public IEnumerable<AgreegationSubVariable> GetAgreegationSubVariables()
        {
            return context.AgreegationSubVariables.AsEnumerable();
        }            

    }
}