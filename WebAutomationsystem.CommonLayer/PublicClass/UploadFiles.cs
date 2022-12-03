using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebAutomationSystem.CommonLayer.Services;

namespace WebAutomationSystem.CommonLayer.PublicClass
{
    public class UploadFiles : IUploadFiles
    {

        private readonly IHostingEnvironment _appEnvironment;

        public UploadFiles(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public string UploadFileFunc(IEnumerable<IFormFile> files, string uploadPath)
        {
            var upload = Path.Combine(_appEnvironment.WebRootPath, uploadPath);
            var filename = "";
            foreach (var item in files)
            {
                filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(item.FileName);
                using (var fs = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                {
                    item.CopyTo(fs);
                }

            }
            return filename;
        }


        public string UploadAttachamentFunc(IEnumerable<IFormFile> files, string uploadPath, string username)
        {
            var upload = Path.Combine(_appEnvironment.WebRootPath, uploadPath);

            if (!Directory.Exists(upload + username))
            {
                Directory.CreateDirectory(upload + username);
            }
            upload = upload + username;

            var filename = "";
            foreach (var item in files)
            {
                filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(item.FileName);
                using (var fs = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                {
                    item.CopyTo(fs);
                }

            }
            return filename;
        }
    }
}
