using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface IGroupUserRepository
    {       
        List<GroupUser> GetByGroupId(int groupid);
       
    }
}
