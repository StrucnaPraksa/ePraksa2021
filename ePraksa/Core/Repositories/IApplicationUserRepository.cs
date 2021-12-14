using System.Collections.Generic;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.ViewModel;

namespace PracticeManagement.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        List<UserViewModel> GetUsers();
        ApplicationUser GetUser(string id);
    }
}