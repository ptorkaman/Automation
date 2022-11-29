﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.DataModelLayer.Repository
{
   public class UserJobRepository : IUserJobRepository
    {
        private readonly ApplicationDbContext _context;

        public UserJobRepository(ApplicationDbContext db)
        {
            _context = db;
        }


        public void DeleteJobFromUser(int UserJobId)
        {
            var result = (from uj in _context.UserJobs where uj.UserJobID == UserJobId select uj);
            var currentJob = result.FirstOrDefault();

            if (result.Count() > 0)
            {
                currentJob.EndJobDate = DateTime.Now;
                currentJob.IaHaveJob = false;
                _context.UserJobs.Attach(currentJob);
                _context.Entry(currentJob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
