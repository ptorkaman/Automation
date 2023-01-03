using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;
using WebAutomationSystem.DataModelLayer.Entities;

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
                currentJob.IsHaveJob = false;
                _context.UserJobs.Attach(currentJob);
                _context.Entry(currentJob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public UserJob GetByJobId(int id)
        {
            return _context.UserJobs.Where(c => c.JobID == id).FirstOrDefault();
        }

        public List<UserWithJobNameViewModel> UserFullNameWithJobName()
        {
            var query = (from userjob in _context.UserJobs
                         join user in _context.Users on userjob.UserID equals user.Id
                         join jobchart in _context.JobsCharts on userjob.JobID equals jobchart.JobsChartID
                         where userjob.IsHaveJob == true
                         select new UserWithJobNameViewModel()
                         {
                             UserID = user.Id,
                             JobId=jobchart.JobsChartID,
                             UserFullNameWithJob = jobchart.JobsChartName + "(" + user.FirstName + " " + user.Family + ")"
                         }).ToList();
            return query;
        }
    }
}
