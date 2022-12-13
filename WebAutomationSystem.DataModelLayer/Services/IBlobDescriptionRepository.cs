using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Repository;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface IBlobDescriptionRepository : IRepository<BlobDescription>
    {
        Task<BlobDescription> GetByIncludeId(long? blobDescriptionId);
    }
}
