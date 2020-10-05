using System.Collections.Generic;
using System.Threading.Tasks;
using Questions.Domain.Models;
using Questions.Services.ViewModels;

namespace Questions.Services.Interfaces
{
    public interface IShareService
    {
        Task ShareAsync(string destinationEmail, string contentUrl);
    }
}