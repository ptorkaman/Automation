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
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Group> GetAll()
        {
            return  _context.Groups
                .Include(c => c.GroupUsers).ThenInclude(c=>c.User)
                .ToList();
        }
    }
}
