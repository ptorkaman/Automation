using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class EntityDataBaseTransaction : IEntityDataBaseTransaction
    {
        private readonly IDbContextTransaction _transaction;

        public EntityDataBaseTransaction(ApplicationDbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            //وقتی همه دستورات با موفقیت انجام شد
            _transaction.Commit();
        }

        public void RollBack()
        {
            //وقتی خطایی پیش آمد
            _transaction.Rollback();
        }

        public void Dispose()
        {
            //برای از بین بردن دیتابیس
            _transaction.Dispose();
        }

    }
}
