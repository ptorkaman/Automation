using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.ViewModels;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserFullNameViewModel> GetAll()
        {
            var query = (from U in _context.Users
                         select new UserFullNameViewModel()
                         {
                             UserFullName = U.FirstName + " " + U.Family + " با کد پرسنلی : " + U.PersonalCode,
                             UserId = U.Id
                         }).ToList();
            return query;
        }

        public List<UserFullNameViewModel> GetUserForSearchInAutoCompelet(string term)
        {
            var query = (from U in _context.Users
                         select new UserFullNameViewModel()
                         {
                             UserFullName = U.FirstName + " " + U.Family + " با کد پرسنلی : " + U.PersonalCode,
                             UserId = U.Id
                         }).Where(U => U.UserFullName.Contains(term)).ToList();
            return query;
        }
    }


}
