using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface IBlobRepository
    {
        bool CheckFileExtension(IEnumerable<IFormFile> upload, CancellationToken cancellationToken);
        List<Blob> GetByBlobDescriptionId(long value);
        long? SaveFile(List<IFormFile> upload,int userid, CancellationToken cancellationToken, long? blobDescriptionId);
    }
}
