using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface IUserRepository
    {
        List<UserFullNameViewModel> GetAll();
        List<UserFullNameViewModel> GetUserForSearchInAutoCompelet(string term);
    }
}
