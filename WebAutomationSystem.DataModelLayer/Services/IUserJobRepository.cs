using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface IUserJobRepository
    {
        void DeleteJobFromUser(int UserJobId);
    }
}
