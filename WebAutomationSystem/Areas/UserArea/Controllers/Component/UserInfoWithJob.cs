using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.Areas.UserArea.Controllers.Component
{
    [ViewComponent(Name = "UserInfoWithJob")]
    public class UserInfoWithJob : ViewComponent
    {
        private readonly IUserInfoWithJobRepository _iuser;
        private readonly UserManager<ApplicationUsers> _userManager;

        public UserInfoWithJob(IUserInfoWithJobRepository iuser, UserManager<ApplicationUsers> userManager)
        {
            _iuser = iuser;
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var model = _iuser.UserInfoWithJob(_userManager.GetUserId(HttpContext.User));
            return View(model);
        }

    }

    public class UserInfoWithJobRepository : IUserInfoWithJobRepository
    {
        private readonly ApplicationDbContext _context;

        public UserInfoWithJobRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserInfoWithJobViewModel UserInfoWithJob(string UserId)
        {
            var JobsChartQuery = (from JobsChart in _context.JobsCharts
                                  join userJob in _context.UserJobs on JobsChart.JobsChartID equals userJob.JobID
                                  join users in _context.Users on userJob.UserID equals users.Id
                                  where userJob.IsHaveJob == true
                                  where users.Id == UserId
                                  select new UserInfoWithJobViewModel()
                                  {
                                      FirstName = users.FirstName,
                                      Family = users.Family,
                                      ImagePath = users.ImagePath,
                                      UserID = users.Id,
                                      JobName = JobsChart.JobsChartName,
                                      JobId = JobsChart.JobsChartID
                                  });
            return JobsChartQuery.Single();
        }
    }

    public interface IUserInfoWithJobRepository
    {
        UserInfoWithJobViewModel UserInfoWithJob(string UserId);
    }

    public class UserInfoWithJobViewModel
    {
        public string FirstName { get; set; }
        public string Family { get; set; }
        public string UserID { get; set; }
        public string ImagePath { get; set; }
        public int JobId { get; set; }
        public string JobName { get; set; }
    }
}
