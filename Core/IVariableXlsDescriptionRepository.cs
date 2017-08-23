using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IVariableXlsDescriptionRepository
    {
        Task<VariableXlsDescription> GetVariableXlsDescription(int id, bool includeRelated = true); 
        void Add(VariableXlsDescription variableXlsDescription);
        void Remove(VariableXlsDescription variableXlsDescription);
        IEnumerable<VariableXlsDescription> GetVariableXlsDescriptions();
    }
}