using System.Linq;
using System.Threading.Tasks;
using NXS.Core;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class VariableXlsRepository : IVariableXlsRepository
    {
        private readonly NxsDbContext context;
        public VariableXlsRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public VariableXls GetVariableXlsAsync(int variableId, int rerionTypeId)
        {
            return context.VariableXls
              .FirstOrDefault(x => x.VariableId == variableId &&  x.XlsRegionTypeId == rerionTypeId);
        }

        public void Add(VariableXls xlsUpload)
        {
            context.VariableXls.Add(xlsUpload);
        }

        public void Update(VariableXls xlsUpload)
        {
            context.VariableXls.Update(xlsUpload);
        }
        
    }
}