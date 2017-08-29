using System.Collections.Generic;
using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Core
{
    public interface IContactUsMessageRepository
    {
        Task<ContactUsMessage> GetContactUsMessage(int id);
        void Add(ContactUsMessage ContactUsMessage);
        void Remove(ContactUsMessage ContactUsMessage);
        IEnumerable<ContactUsMessage> GetContactUsMessages();
    }
}