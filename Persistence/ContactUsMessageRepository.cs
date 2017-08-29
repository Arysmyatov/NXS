using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class ContactUsMessageRepository : IContactUsMessageRepository
    {
        private readonly NxsDbContext context;

        public ContactUsMessageRepository(NxsDbContext context)
        {
            this.context = context;
        }

        public async Task<ContactUsMessage> GetContactUsMessage(int id)
        {
            return await context.ContactUsMessages
              .SingleOrDefaultAsync(p => p.Id == id);
        }


        public IEnumerable<ContactUsMessage> GetContactUsMessages()
        {
            return context.ContactUsMessages;
        }


        public void Add(ContactUsMessage ContactUsMessage)
        {
            context.ContactUsMessages.Add(ContactUsMessage);
        }


        public void Remove(ContactUsMessage ContactUsMessage)
        {
            context.Remove(ContactUsMessage);
        }
    }
}