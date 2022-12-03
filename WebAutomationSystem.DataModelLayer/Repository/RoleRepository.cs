using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Services;
using System.Linq;

namespace WebAutomationSystem.DataModelLayer.Repository
{
   public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext db)
        {
            _context = db;
        }

        public string GetRoleId(string userId)
        {
            //دارای یک نکته مهم
            var getRoleId = _context.UserRoles.Where(ur => ur.UserId == userId).ToList();
            string getRollString = "";
            for (int i = 0; i < getRoleId.Count; i++)
            {
                getRollString += getRoleId[i].RoleId.ToString() + ",";
            }

            return getRollString;
        }

        public string GetRolePatternId(int RolePatternID)
        {
            //دارای یک نکته مهم
            var getRoleId = _context.RolePatternDetails.Where(rp => rp.RolePatternID == RolePatternID).ToList();
            string getRollString = "";
            for (int i = 0; i < getRoleId.Count; i++)
            {
                getRollString += getRoleId[i].RoleID.ToString() + ",";
            }

            return getRollString;
        }
    }
}
