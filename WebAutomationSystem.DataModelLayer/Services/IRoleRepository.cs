using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Services
{
   public interface IRoleRepository
    {
        string GetRoleId(string userId);
        string GetRolePatternId(int RolePatternID);
    }
}
