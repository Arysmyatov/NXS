using System.Threading.Tasks;
using NXS.Core.Models;

namespace NXS.Services.Abstract
{
    public interface IUserActivityService
    {
        Task AddContactUsMessageAsync(ContactUsMessage contactUsMessageResource);
    }
}