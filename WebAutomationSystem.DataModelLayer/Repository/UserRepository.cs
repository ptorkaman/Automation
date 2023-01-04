using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.ViewModels;
using WebAutomationSystem.DataModelLayer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;

        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<UserFullNameViewModel> GetAll()
        {
            var query = (from U in _context.Users
                         join blob in _context.BlobDescriptions on U.BlobDescriptionId equals blob.Id
                         join blb in _context.Blobs on blob.Id equals blb.BlobDescriptionId
                         join strm in _context.BlobStreams on blb.Id equals strm.BlobId
                         select new UserFullNameViewModel()
                         {
                             UserFullName = U.FirstName + " " + U.Family ,//+ " با کد پرسنلی : " + U.PersonalCode,
                             UserId = U.Id,
                             BlobDescriptionId = U.BlobDescriptionId,
                             BlobDescription = blob,
                             Blob = blb,
                             BlobStream = strm,
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
