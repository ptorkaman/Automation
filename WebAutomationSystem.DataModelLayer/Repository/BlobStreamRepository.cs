using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.ViewModels;
using WebAutomationSystem.DataModelLayer.Services;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.IO;
using WebAutomationSystem.DataModelLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class BlobStreamRepository : IBlobStreamRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;

        public BlobStreamRepository(ApplicationDbContext context, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       

        public BlobStream GetByBlobId(long blobId)
        {
            return _context.BlobStreams.Where(c => c.BlobId == blobId).ToList().OrderByDescending(c=>c.Id).FirstOrDefault();
        }

        

    }


}
