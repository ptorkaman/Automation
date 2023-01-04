using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int GetUserLeave_Estehghaghi(string UserID, DateTime FromDate, DateTime ToDate)
        {
            var getEstehghaghy =
                    _context.Leaves.Where(L => L.UserID_Request == UserID &&
                                                  L.LeaveType == 2 &&
                                                  L.LeaveAccept == 2)
                    .Select(c => new
                    {
                        morkhasi = EF.Functions.DateDiffDay(FromDate >= c.FromDate_Day ? FromDate : c.FromDate_Day,
                                                            ToDate <= c.ToDate_Day ? ToDate : c.ToDate_Day) + 1
                    }).ToList();
            int AllEstehghaghy = 0;
            for (int i = 0; i < getEstehghaghy.Count(); i++)
            {
                if (getEstehghaghy[i].morkhasi > 0)
                {
                    AllEstehghaghy += Convert.ToInt32(getEstehghaghy[i].morkhasi);
                }
            }
            return AllEstehghaghy;
        }
        public int GetUserLeave_Estelaji(string UserID, DateTime FromDate, DateTime ToDate)
        {
            var getEstelaji =
                    _context.Leaves.Where(L => L.UserID_Request == UserID &&
                                                  L.LeaveType == 3 &&
                                                  L.LeaveAccept == 2)
                    .Select(c => new
                    {
                        morkhasi = EF.Functions.DateDiffDay(FromDate >= c.FromDate_Day ? FromDate : c.FromDate_Day,
                                                            ToDate <= c.ToDate_Day ? ToDate : c.ToDate_Day) + 1
                    }).ToList();
            int AllEstelaji = 0;
            for (int i = 0; i < getEstelaji.Count(); i++)
            {
                if (getEstelaji[i].morkhasi > 0)
                {
                    AllEstelaji += Convert.ToInt32(getEstelaji[i].morkhasi);
                }
            }
            return AllEstelaji;
        }
        public int GetUserLeave_BiHoghugh(string UserID, DateTime FromDate, DateTime ToDate)
        {
            var getBiHoghugh =
                    _context.Leaves.Where(L => L.UserID_Request == UserID &&
                                                  L.LeaveType == 4 &&
                                                  L.LeaveAccept == 2)
                    .Select(c => new
                    {
                        morkhasi = EF.Functions.DateDiffDay(FromDate >= c.FromDate_Day ? FromDate : c.FromDate_Day,
                                                            ToDate <= c.ToDate_Day ? ToDate : c.ToDate_Day) + 1
                    }).ToList();
            int AllBiHoghugh = 0;
            for (int i = 0; i < getBiHoghugh.Count(); i++)
            {
                if (getBiHoghugh[i].morkhasi > 0)
                {
                    AllBiHoghugh += Convert.ToInt32(getBiHoghugh[i].morkhasi);
                }
            }
            return AllBiHoghugh;
        }
        public string GetUserLeave_Saati(string UserID, DateTime FromDate, DateTime ToDate)
        {
            int AllSaati =
              Convert.ToInt32(_context.Leaves.Where(L => L.UserID_Request == UserID &&
                                          L.LeaveAccept == 2 &&
                                          L.LeaveType == 1 &&
                                          L.FromTime_Saati >= FromDate &&
                                          L.ToTime_Saati <= ToDate)
                .Sum(p => EF.Functions.DateDiffMinute(p.FromTime_Saati, p.ToTime_Saati)));

            TimeSpan t = TimeSpan.FromMinutes(AllSaati);

            return t.Hours + " ساعت و " + t.Minutes + " دقیقه ";
        }
        public List<LeaveListViewModel> LeaveList(string userId_request, int leaveType, int leaveAccept, DateTime fromdate, DateTime todate, string confirmname = "")
        {
            var query = (from L in _context.Leaves
                         join U in _context.Users on L.UserID_Confirm equals U.Id
                         where L.UserID_Request == userId_request
                         select new LeaveListViewModel()
                         {
                             LeaveID = L.LeaveID,
                             Description = L.Description,
                             ToDate_Day = L.ToDate_Day,
                             FromDate_Day = L.FromDate_Day,
                             ToTime_Saati = L.ToTime_Saati,
                             FromTime_Saati = L.FromTime_Saati,
                             FirstName_Confirm = U.FirstName,
                             Family_Confirm = U.Family,
                             FullName_Confirm = U.FirstName + " " + U.Family,
                             UserID_Confirm = L.UserID_Confirm,
                             UserID_Request = L.UserID_Request,

                             LeaveAccept = L.LeaveAccept,
                             LeaveAcceptDesc =
                             (L.LeaveAccept == 1) ? "در حال بررسی" :
                             (L.LeaveAccept == 2) ? "تایید شده" :
                             (L.LeaveAccept == 3) ? "رد شده" : null,

                             LeaveType = L.LeaveType,
                             LeaveTypeDesc =
                             (L.LeaveType == 1) ? "ساعتی" :
                             (L.LeaveType == 2) ? "استحقاقی" :
                             (L.LeaveType == 3) ? "استعلاجی" :
                             (L.LeaveType == 4) ? "بدون حقوق" : null,

                             LeaveRequestDate = L.LeaveRequestDate
                         }).AsEnumerable();

            switch (leaveType)
            {
                case 1:
                    query = query.Where(l => l.LeaveType == 1);
                    break;
                case 2:
                    query = query.Where(l => l.LeaveType == 2);
                    break;
                case 3:
                    query = query.Where(l => l.LeaveType == 3);
                    break;
                case 4:
                    query = query.Where(l => l.LeaveType == 4);
                    break;
            }
            switch (leaveAccept)
            {
                case 1:
                    query = query.Where(l => l.LeaveAccept == 1);
                    break;
                case 2:
                    query = query.Where(l => l.LeaveAccept == 2);
                    break;
                case 3:
                    query = query.Where(l => l.LeaveAccept == 3);
                    break;
            }
            if (fromdate != null)
            {
                query = query.Where(l => l.LeaveRequestDate.Date >= fromdate);
            }
            if (todate != null)
            {
                query = query.Where(l => l.LeaveRequestDate.Date <= todate);
            }
            if (confirmname != null)
            {
                query = query.Where(l => l.FullName_Confirm.Contains(confirmname));
            }
            return query.ToList();
        }

        public List<LeaveManagementViewModel> LeaveManagement(string userId_confirm,
                                                                int leaveType,
                                                                    int leaveAccept,
                                                                        DateTime fromdate,
                                                                            DateTime todate,
                                                                                string requestname = "")
        {
            var query = (from L in _context.Leaves
                         join U in _context.Users on L.UserID_Request equals U.Id
                         where L.UserID_Confirm == userId_confirm
                         select new LeaveManagementViewModel()
                         {
                             LeaveID = L.LeaveID,
                             Description = L.Description,
                             ToDate_Day = L.ToDate_Day,
                             FromDate_Day = L.FromDate_Day,
                             ToTime_Saati = L.ToTime_Saati,
                             FromTime_Saati = L.FromTime_Saati,
                             FirstName_Request = U.FirstName,
                             Family_Request = U.Family,
                             FullName_Request = U.FirstName + " " + U.Family,
                             UserID_Confirm = L.UserID_Confirm,
                             UserID_Request = L.UserID_Request,

                             LeaveAccept = L.LeaveAccept,
                             LeaveAcceptDesc =
                             (L.LeaveAccept == 1) ? "در حال بررسی" :
                             (L.LeaveAccept == 2) ? "تایید شده" :
                             (L.LeaveAccept == 3) ? "رد شده" : null,

                             LeaveType = L.LeaveType,
                             LeaveTypeDesc =
                             (L.LeaveType == 1) ? "ساعتی" :
                             (L.LeaveType == 2) ? "استحقاقی" :
                             (L.LeaveType == 3) ? "استعلاجی" :
                             (L.LeaveType == 4) ? "بدون حقوق" : null,

                             LeaveRequestDate = L.LeaveRequestDate
                         }).AsEnumerable();

            switch (leaveType)
            {
                case 1:
                    query = query.Where(l => l.LeaveType == 1);
                    break;
                case 2:
                    query = query.Where(l => l.LeaveType == 2);
                    break;
                case 3:
                    query = query.Where(l => l.LeaveType == 3);
                    break;
                case 4:
                    query = query.Where(l => l.LeaveType == 4);
                    break;
            }
            switch (leaveAccept)
            {
                case 1:
                    query = query.Where(l => l.LeaveAccept == 1);
                    break;
                case 2:
                    query = query.Where(l => l.LeaveAccept == 2);
                    break;
                case 3:
                    query = query.Where(l => l.LeaveAccept == 3);
                    break;
            }
            if (fromdate != null)
            {
                query = query.Where(l => l.LeaveRequestDate.Date >= fromdate);
            }
            if (todate != null)
            {
                query = query.Where(l => l.LeaveRequestDate.Date <= todate);
            }
            if (requestname != null)
            {
                query = query.Where(l => l.FullName_Request.Contains(requestname));
            }
            return query.ToList();
        }

        public void AcceptRejectLeave(int LeaveID, byte flag)
        {
            var result = (from l in _context.Leaves where l.LeaveID == LeaveID select l);
            var current = result.FirstOrDefault();

            if (result.Count() > 0)
            {
                if (flag == 1)
                {
                    current.LeaveAccept = 2;
                }
                else if (flag == 2)
                {
                    current.LeaveAccept = 3;
                }
                _context.Leaves.Attach(current);
                _context.Entry(current).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
        }


        public LeaveListViewModel LeavePrint(int LeaveID)
        {
            var query = (from L in _context.Leaves
                         where L.LeaveID == LeaveID
                         select new LeaveListViewModel()
                         {
                             LeaveID = L.LeaveID,
                             Description = L.Description,
                             ToDate_Day = L.ToDate_Day,
                             FromDate_Day = L.FromDate_Day,
                             ToTime_Saati = L.ToTime_Saati,
                             FromTime_Saati = L.FromTime_Saati,
                             FullName_Confirm = (_context.Users.Where(u => u.Id == L.UserID_Confirm).Select(u => u.FirstName + " " + u.Family)).Single(),
                             FullName_Request = (_context.Users.Where(u => u.Id == L.UserID_Request).Select(u => u.FirstName + " " + u.Family)).Single(),
                             UserID_Confirm = L.UserID_Confirm,
                             UserID_Request = L.UserID_Request,

                             LeaveAccept = L.LeaveAccept,
                             LeaveAcceptDesc =
                             (L.LeaveAccept == 1) ? "در حال بررسی" :
                             (L.LeaveAccept == 2) ? "تایید شده" :
                             (L.LeaveAccept == 3) ? "رد شده" : null,

                             LeaveType = L.LeaveType,
                             LeaveTypeDesc =
                             (L.LeaveType == 1) ? "ساعتی" :
                             (L.LeaveType == 2) ? "استحقاقی" :
                             (L.LeaveType == 3) ? "استعلاجی" :
                             (L.LeaveType == 4) ? "بدون حقوق" : null,

                             LeaveRequestDate = L.LeaveRequestDate
                         }).AsEnumerable();

            return query.Single();
        }
    }
}