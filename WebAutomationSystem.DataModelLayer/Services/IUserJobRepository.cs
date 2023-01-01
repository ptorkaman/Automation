using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface IUserJobRepository
    {
        void DeleteJobFromUser(int UserJobId);
        UserJob GetByJobId(int id);
        List<UserWithJobNameViewModel> UserFullNameWithJobName();
    }
}
