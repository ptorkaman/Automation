using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Repository;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
        }

        private GenericClass<ApplicationUsers> _userManager;
        private GenericClass<ApplicationRoles> _roleManager;
        private GenericClass<JobsChart> _jobsChart;
        private GenericClass<UserJob> _userJob;
        private GenericClass<Reminder> _reminder;


        //یادآوری
        public GenericClass<Reminder> reminderUW
        {
            //فقط خواندنی    
            get
            {
                if (_reminder == null)
                {
                    _reminder = new GenericClass<Reminder>(_context);
                }
                return _reminder;
            }
        }

        //جدول تخصیص شغل به کاربر
        public GenericClass<UserJob> userJobUW
        {
            //فقط خواندنی    
            get
            {
                if (_userJob == null)
                {
                    _userJob = new GenericClass<UserJob>(_context);
                }
                return _userJob;
            }
        }

        //چارت مشاغل سازمانی
        public GenericClass<JobsChart> jobsChartUW
        {
            //فقط خواندنی    
            get
            {
                if (_jobsChart == null)
                {
                    _jobsChart = new GenericClass<JobsChart>(_context);
                }
                return _jobsChart;
            }
        }

        //کاربران
        public GenericClass<ApplicationUsers> userManagerUW
        {
            //فقط خواندنی    
            get
            {
                if (_userManager == null)
                {
                    _userManager = new GenericClass<ApplicationUsers>(_context);
                }
                return _userManager;
            }
        }

        //نقش ها
        public GenericClass<ApplicationRoles> roleManagerUW
        {
            //فقط خواندنی    
            get
            {
                if (_roleManager == null)
                {
                    _roleManager = new GenericClass<ApplicationRoles>(_context);
                }
                return _roleManager;
            }
        }


        public void save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}