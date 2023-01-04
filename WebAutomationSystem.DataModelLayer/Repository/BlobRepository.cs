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
    public class BlobRepository : IBlobRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;

        public BlobRepository(ApplicationDbContext context, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public bool CheckFileExtension(IEnumerable<IFormFile> upload, CancellationToken cancellationToken)
        {
            bool temp = true;
            foreach (var item in upload)
            {
                var data = item.FileName.Split('.');
                var exe = data[data.Length - 1].ToLower();
                if (exe == "doc" || exe == "docx" || exe == "pdf" || exe == "xls" || exe == "xlsx" || exe == "png" || exe == "jpeg" || exe == "jpg")
                    continue;
                else
                {
                    return false;
                }
            }
            return temp;
        }

        public List<Blob> GetByBlobDescriptionId(long blobDescriptionId)
        {
            return _context.Blobs.Where(c => c.BlobDescriptionId == blobDescriptionId && c.IsDeleted == false).AsNoTracking().ToList();
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

        public long? SaveFile(List<IFormFile> upload, int userid, CancellationToken cancellationToken, long? blobDescriptionId)
        {
            if (upload != null && upload.Any())
            {
                if (upload.Count > 0)
                {
                    BlobDescription blobDescription = new BlobDescription();

                    if (blobDescriptionId == null)
                    {
                        blobDescription.CreatedById = userid;
                        _context.BlobDescriptions.AddAsync(blobDescription, cancellationToken);
                        _context.SaveChanges();
                    }
                    else
                        blobDescription.Id = blobDescriptionId.Value;

                    BlobStream blobStream = new BlobStream();
                    foreach (var file in upload)
                    {
                        Blob blob;
                        byte[] fileBytes;
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();

                            blob = new Blob
                            {
                                Size = file.Length,
                                CategoryId = 1,
                                Title = file.FileName,
                                ContentType = file.ContentType,
                                BlobDescriptionId = blobDescription.Id,
                                CreatedById = userid,
                                CreatedOn = DateTime.Now

                            };
                        }
                        _context.Blobs.AddAsync(blob, cancellationToken);
                        _context.SaveChanges();
                        blobStream = new BlobStream()
                        {
                            File = fileBytes,
                            BlobId = blob.Id,
                            CreatedById = userid,
                            CreatedOn = DateTime.Now
                        };
                        _context.BlobStreams.AddAsync(blobStream, cancellationToken);
                        _context.SaveChangesAsync();
                    }
                    return blobDescription.Id;
                }
                return null;
            }
            return null;
        }
    }


}
