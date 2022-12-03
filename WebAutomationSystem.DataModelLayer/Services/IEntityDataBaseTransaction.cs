using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface IEntityDataBaseTransaction : IDisposable
    {
        void Commit();
        void RollBack();
    }
}
