using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class XLsUplodRepository : IXlsUploadRepository
    {
        private readonly NxsDbContext context;
        public XLsUplodRepository(NxsDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<XlsUpload>> GetXlsUploadsAsync(int regionId, int keyParameterId, int keyParameterLevelId, int scenarioId)
        {
            return await context.XlsUploads
              .Where(x => x.KeyParameterId == keyParameterId && x.KeyParameterLevelId == keyParameterLevelId && x.ScenarioId == scenarioId)
              .ToListAsync();
        }


        public async Task<IEnumerable<XlsUpload>> GetXlsUploadsNotProcessdAsync()
        {
            return await context.XlsUploads
              .Where(x => x.IsProcessed == null 
                      || !x.IsProcessed.Value)
              .ToListAsync();
        }        


        public async Task<XlsUpload> GetXlsLastUplodAsync(int regionId, int keyParameterId,  int keyParameterLevelId, int scenarioId)
        {
            return await context.XlsUploads
              .Where(x => x.KeyParameterLevelId == keyParameterId &&  x.KeyParameterLevelId == keyParameterLevelId &&  x.ScenarioId == scenarioId)
                              .OrderByDescending(x => x.UploadDate)
                              .FirstOrDefaultAsync();
        }

        public void Add(XlsUpload xlsUpload)
        {
            context.XlsUploads.Add(xlsUpload);
        }

        public void Update(XlsUpload xlsUpload) {
            context.XlsUploads.Update(xlsUpload);
        }
    }
}