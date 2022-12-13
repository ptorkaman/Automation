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
using System.Threading.Tasks;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class BlobDescriptionRepository : Repository<BlobDescription>, IBlobDescriptionRepository
    {
        //private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;

        public BlobDescriptionRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
        //public BlobDescriptionRepository(ApplicationDbContext context, UserManager<ApplicationUsers> userManager)
        //{
        //    _context = context;
        //    _userManager = userManager; 
        //}

        public  async Task<BlobDescription> GetByIncludeId(long? blobDescriptionId)
        {
            return await _appDbContext.BlobDescriptions.Include(i => i.Blobs).ThenInclude(i => i.BlobStream)                
                .Where(x => x.Id == blobDescriptionId).FirstOrDefaultAsync();

        }
    }


}
