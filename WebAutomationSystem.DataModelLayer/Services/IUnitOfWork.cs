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
        GenericClass<ReferralLetters> referralLettersUW { get; }
        GenericClass<Notation> notationUW { get; }
        GenericClass<SentLetters> sentLettersUW { get; }
        GenericClass<Leave> leaveUW { get; }
        GenericClass<ForeignDocument> foreignDocumentUW { get; }
        GenericClass<Category> categoryUW { get; }
        GenericClass<Blob> blobUW { get; }
        GenericClass<BlobDescription> blobDescriptionUW { get; }
        GenericClass<BlobStream> blobStreamUW { get; }
        GenericClass<Cartable> cartableUW { get; }
        GenericClass<CartableUser> cartableUserUW { get; }
        GenericClass<SecretariatType> secretariatTypeUW { get; }
        IEntityDataBaseTransaction BeginTransaction();
        void save();
        void Dispose();
    }
}
