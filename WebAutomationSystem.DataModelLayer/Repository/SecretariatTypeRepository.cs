using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Services;
using System.Linq;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer.Repository
{
   public class SecretariatTypeRepository : ISecretariatTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public SecretariatTypeRepository(ApplicationDbContext db)
        {
            _context = db;
        }

        public List<SecretariatType> GetAll()
        {
            return _context.SecretariatTypes.ToList();
        }
    }
}
