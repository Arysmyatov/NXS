using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IAgrigationXlsDescriptionRepository
    {
        Task<AgrigationXlsDescription> GetDescription(int id);
        void Add(AgrigationXlsDescription description);
        void Remove(AgrigationXlsDescription description);
        IEnumerable<AgrigationXlsDescription> GetDescriptions();
        IEnumerable<AgrigationXlsDescription> GetWorldDescriptions();
    }
}