using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer.Services
{
   public interface ISecretariatTypeRepository
    {
        List<SecretariatType> GetAll();
    }
}
