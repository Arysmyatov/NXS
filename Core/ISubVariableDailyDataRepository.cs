using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface ISubVariableDailyDataRepository
    {
        IEnumerable<SubVariableDailyData> GetSubVariableData();
        IEnumerable<SubVariableDailyData> GetSubVariableData(SubVariableDataQuery queryObj, bool includeRelated);
    }
}