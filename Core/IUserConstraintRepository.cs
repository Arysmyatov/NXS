using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IUserConstraintRepository
    {
        Task<UserConstraint> GetUserConstraint(int id, bool includeRelated = true);
        Task<UserConstraint> GetUserConstraintByName(string name, bool includeRelated = true);
        void Add(UserConstraint UserConstraint);
        void Remove(UserConstraint UserConstraint);        
    }
}