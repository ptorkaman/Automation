using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.CommonLayer.Services
{
    public interface IUploadFiles
    {
        string UploadFileFunc(IEnumerable<IFormFile> files, string uploadPath);
    }
}
