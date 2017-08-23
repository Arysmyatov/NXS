using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IProcessSetRepository
    {
        Task<ProcessSet> GetProcessSet(int id, bool includeRelated = true);
        Task<ProcessSet> GetProcessSetByName(string name, bool includeRelated = true);
        void Add(ProcessSet processSet);
        void Remove(ProcessSet processSet);
    }
}