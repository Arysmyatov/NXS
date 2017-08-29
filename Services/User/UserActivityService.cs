using System.Text;
using System.Threading.Tasks;
using NXS.Core;
using NXS.Core.Models;
using NXS.Services.Abstract;

namespace NXS.Services.User
{
    public class UserActivityService : IUserActivityService
    {
        private readonly IContactUsMessageRepository _contactUsMessageRepository;
        private readonly IEmailService _emailService;                
        private readonly IUnitOfWork _unitOfWork;                

        public UserActivityService(IContactUsMessageRepository contactUsMessageRepository,
                                   IUnitOfWork unitOfWork,
                                   IEmailService emailService)
        {
            _contactUsMessageRepository = contactUsMessageRepository;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddContactUsMessageAsync(ContactUsMessage contactUsMessage)
        {
            _contactUsMessageRepository.Add(contactUsMessage);
            await _unitOfWork.CompleteAsync();
            await _emailService.SendEmailAsync(contactUsMessage.Email, "Contact us request", BuildMessage(contactUsMessage));
        }


        private string BuildMessage(ContactUsMessage contactUsMessage){
            var message = new StringBuilder();
            message.Append($"From Name: { contactUsMessage.Name },  \n");
            message.Append($"Email: { contactUsMessage.Email },  \n");
            message.Append($"Phone Number: { contactUsMessage.PhoneNumber },  \n");
            message.Append($"Phone Number: { contactUsMessage.Message } ");
            return message.ToString();
        }
    }
}