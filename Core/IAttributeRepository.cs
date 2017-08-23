using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IAttributeRepository
    {
        Task<Attribute> GetAttribute(int id, bool includeRelated = true);
        Task<Attribute> GetAttributeByName(string name, bool includeRelated = true);
        void Add(Attribute Attribute);
        void Remove(Attribute Attribute);
    }
}