using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebAutomationSystem.DataModelLayer.ViewModels;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class GroupUserRepository : IGroupUserRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<GroupUser> GetByGroupId(int groupid)
        {
            return _context.GroupUsers.Where(c => c.GroupId == groupid).ToList();
        }
    }
}
