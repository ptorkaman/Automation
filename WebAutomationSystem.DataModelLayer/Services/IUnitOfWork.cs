using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Repository;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface IUnitOfWork
    {
        GenericClass<ApplicationUsers> userManagerUW { get; }
        GenericClass<ApplicationRoles> roleManagerUW { get; }
        GenericClass<JobsChart> jobsChartUW { get; }
        GenericClass<UserJob> userJobUW { get; }
        GenericClass<Reminder> reminderUW { get; }
        GenericClass<RolePattern> rolePatternUW { get; }
        GenericClass<RolePatternDetails> rolePatternDetailsUW { get; }
        GenericClass<Letters> lettersUW { get; }
        GenericClass<AdministrativeForm> administrativeFormUW { get; }
        IEntityDataBaseTransaction BeginTransaction();
        void save();
        void Dispose();
    }
}
