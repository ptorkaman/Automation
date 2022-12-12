using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.ViewModels;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class NotationRepository : INotationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotationRepository(ApplicationDbContext db)
        {
            _context = db;
        }

        public List<RecievedNotationListViewModel> RecievedNotationList(string userId,
                                                                            DateTime fromdate,
                                                                                DateTime todate,
                                                                                    byte searchTypeselected = 0,
                                                                                        string inputsearch = "")
        {
            var Query = (from N in _context.Notations
                                where N.UserID_Reciever == userId
                                select new RecievedNotationListViewModel()
                                {
                                    NotationContent = N.NotationContent,
                                    NotationDate = N.NotationDate,
                                    NotationID = N.NotationID,
                                    NotationTitle = N.NotationTitle,
                                    UserID_Reciever = N.UserID_Reciever,

                                    CreatorInfo = _context.Users.Where(u => u.Id == N.UserID_Creator).
                                        Select(u => new NotationCreatorInfo()
                                        {
                                            FullName = u.FirstName + " " + u.Family,
                                            FirstName = u.FirstName,
                                            Family = u.Family,
                                            UserID_Creator = u.Id
                                        }).Single(),

                                }).AsEnumerable();

            //جستجو در موضوع یادداشت
            if (searchTypeselected == 1 && inputsearch != null)
            {
                Query = Query.Where(l => l.NotationTitle.Contains(inputsearch));
            }
            //جستجو نام فرستنده
            if (searchTypeselected == 2 && inputsearch != null)
            {
                Query = Query.Where(l => l.CreatorInfo.FullName.Contains(inputsearch));
            }
            //جستجو در تاریخ دریافت نامه
            if (searchTypeselected == 3)
            {
                if (fromdate != null)
                {
                    Query = Query.Where(l => l.NotationDate.Date >= fromdate);
                }
                if (todate != null)
                {
                    Query = Query.Where(l => l.NotationDate.Date <= todate);
                }
            }
          
            return Query.ToList();
        }

        public List<SentNotationListViewModel> SentNotationList(string userId,
                                                                        DateTime fromdate,
                                                                            DateTime todate,
                                                                                byte searchTypeselected = 0,
                                                                                    string inputsearch = "")
        {
            var Query = (from N in _context.Notations
                         where N.UserID_Creator == userId
                         select new SentNotationListViewModel()
                         {
                             NotationContent = N.NotationContent,
                             NotationDate = N.NotationDate,
                             NotationID = N.NotationID,
                             NotationTitle = N.NotationTitle,
                             UserID_Creator = N.UserID_Creator,

                             RecieverInfo = _context.Users.Where(u => u.Id == N.UserID_Reciever).
                                 Select(u => new NotationCreatorInfo()
                                 {
                                     FullName = u.FirstName + " " + u.Family,
                                     FirstName = u.FirstName,
                                     Family = u.Family,
                                     UserID_Creator = u.Id
                                 }).Single(),

                         }).AsEnumerable();

            //جستجو در موضوع یادداشت
            if (searchTypeselected == 1 && inputsearch != null)
            {
                Query = Query.Where(l => l.NotationTitle.Contains(inputsearch));
            }
            //جستجو نام فرستنده
            if (searchTypeselected == 2 && inputsearch != null)
            {
                Query = Query.Where(l => l.RecieverInfo.FullName.Contains(inputsearch));
            }
            //جستجو در تاریخ دریافت نامه
            if (searchTypeselected == 3)
            {
                if (fromdate != null)
                {
                    Query = Query.Where(l => l.NotationDate.Date >= fromdate);
                }
                if (todate != null)
                {
                    Query = Query.Where(l => l.NotationDate.Date <= todate);
                }
            }

            return Query.ToList();
        }
    }
}