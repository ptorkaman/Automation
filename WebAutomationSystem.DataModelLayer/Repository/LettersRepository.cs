using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebAutomationSystem.DataModelLayer.ViewModels;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class LettersRepository : ILettersRepository
    {
        private readonly ApplicationDbContext _context;

        public LettersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<LettersListViewModel> LettersList(string userId)
        {
            var lettersQuery = (from L in _context.Letters
                                where L.UserID == userId
                                where L.IsInDraft == false
                                select new LettersListViewModel()
                                {
                                    LetterID = L.LetterID,
                                    LetterSubject = L.LetterSubject,
                                    LetterContent = L.LetterContent,
                                    UserID = L.UserID,
                                    LetterCreateDate = L.LetterCreateDate,
                                    LetterAttachamentFile = L.LetterAttachamentFile,
                                    //
                                    ReplyStatus = L.ReplyStatus,
                                    ReplyStatusText =
                                    (L.ReplyStatus == true) ? "دارد" :
                                    (L.ReplyStatus == false) ? "ندارد" : null,
                                    //
                                    AttachmentStatus = L.AttachmentStatus,
                                    AttachmentStatusText =
                                    (L.AttachmentStatus == true) ? "دارد" :
                                    (L.AttachmentStatus == false) ? "ندارد" : null,
                                    //
                                    ImmediatellyStatus = L.ImmediatellyStatus,
                                    ImmediatellyStatusText =
                                    (L.ImmediatellyStatus == 1) ? "عادی" :
                                    (L.ImmediatellyStatus == 2) ? "فوری" :
                                    (L.ImmediatellyStatus == 3) ? "آنی" : null,
                                    //
                                    ClassificationStatus = L.ClassificationStatus,
                                    ClassificationStatusText =
                                    (L.ClassificationStatus == 1) ? "عادی" :
                                    (L.ClassificationStatus == 2) ? "محرمانه" :
                                    (L.ClassificationStatus == 3) ? "فوق محرمانه" : null,
                                    //
                                    ReplyDate = L.ReplyDate,
                                    LetterType = L.LetterType,
                                    MainLetterID = L.MainLetterID

                                }).ToList();
            return lettersQuery;
        }

        public List<JobsChartWithUserInfoViewModel> JobsChartWithUserInfo()
        {
            var JobsChartQuery = (from JobsChart in _context.JobsCharts
                                  join userJob in _context.UserJobs  on JobsChart.JobsChartID equals userJob.JobID
                                  join users in _context.Users on userJob.UserID equals users.Id
                                  where JobsChart.JobsChartLevel != 0
                                  where userJob.IaHaveJob == true
                                  select new JobsChartWithUserInfoViewModel()
                                  {
                                      JobsChartID = JobsChart.JobsChartID,
                                      JobsChartName = JobsChart.JobsChartName,
                                      JobsChartLevel = JobsChart.JobsChartLevel,
                                      FirstName = users.FirstName,
                                      Family = users.Family

                                  }).ToList();
            return JobsChartQuery;
        }

        public string GetUserIdFromJobID(int jobid)
        {
            var userid = (from uj in _context.UserJobs
                          where uj.JobID == jobid
                          where uj.IaHaveJob == true
                          select uj.UserID).Single();
            return userid;
        }

        public void ExitLetterFromDraft(int LetterID, string UserId)
        {
            var result = (from l in _context.Letters where l.LetterID == LetterID select l);
            var currentLetter = result.FirstOrDefault();

            if (result.Count() > 0)
            {
                //Create LetterNumber
                //Year/JobID/LetterID
                //Get JobID
                int getUserJobId = _context.UserJobs.Where(u => u.UserID == UserId && u.IaHaveJob == true)
                                        .Select(uj => uj.JobID).Single();

                currentLetter.LetterNumber = DateTime.Now.Year + "-" + getUserJobId + "-" + LetterID;
                //
                currentLetter.IsInDraft = true;
                _context.Letters.Attach(currentLetter);
                _context.Entry(currentLetter).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public List<MyLetterViewModel> MyLetter(string userId_reciever,
                                                     DateTime fromdate,
                                                        DateTime todate,
                                                            byte classificationradio = 0,
                                                                 byte replyradio = 2,
                                                                    byte attachmentradio = 2,
                                                                        byte readradio = 2,
                                                                            byte searchTypeselected = 0,
                                                                                byte immediatelytype = 0,
                                                                                    string inputsearch = "")
        {
            var lettersQuery = (from SL in _context.SentLetters
                                join L in _context.Letters on SL.LetterID equals L.LetterID
                                join U in _context.Users on SL.userId_sender equals U.Id
                                where SL.userId_reciever == userId_reciever
                                select new MyLetterViewModel()
                                {
                                    LetterID = L.LetterID,
                                    LetterSubject = L.LetterSubject,
                                    LetterContent = L.LetterContent,
                                    UserID_Sender = SL.userId_sender,
                                    Family_sender = U.Family,
                                    FirstName_Sender = U.FirstName,
                                    FullName_sender = U.FirstName + " " + U.Family,
                                    UserName_sender = U.UserName,
                                    LetterSentDate = SL.SentLetterDate,
                                    LetterAttachamentFile = L.LetterAttachamentFile,
                                    //
                                    ReplyStatus = L.ReplyStatus,
                                    ReplyStatusText =
                                    (L.ReplyStatus == true) ? "دارد" :
                                    (L.ReplyStatus == false) ? "ندارد" : null,
                                    //
                                    AttachmentStatus = L.AttachmentStatus,
                                    AttachmentStatusText =
                                    (L.AttachmentStatus == true) ? "دارد" :
                                    (L.AttachmentStatus == false) ? "ندارد" : null,
                                    //
                                    ImmediatellyStatus = L.ImmediatellyStatus,
                                    ImmediatellyStatusText =
                                    (L.ImmediatellyStatus == 1) ? "عادی" :
                                    (L.ImmediatellyStatus == 2) ? "فوری" :
                                    (L.ImmediatellyStatus == 3) ? "آنی" : null,
                                    //
                                    ClassificationStatus = L.ClassificationStatus,
                                    ClassificationStatusText =
                                    (L.ClassificationStatus == 1) ? "عادی" :
                                    (L.ClassificationStatus == 2) ? "محرمانه" :
                                    (L.ClassificationStatus == 3) ? "فوق محرمانه" : null,
                                    //
                                    ReplyDate = L.ReplyDate,
                                    //
                                    ReadType = SL.ReadType,
                                    ReadTypeText =
                                    (SL.ReadType == true) ? "خوانده" :
                                    (SL.ReadType == false) ? "نخوانده" : null,
                                    LetterNumber = L.LetterNumber,
                                    LetterType = L.LetterType,
                                    MainLetterID = L.MainLetterID
                                }).AsEnumerable();

            //جستجو در طبقه بندی نامه ها
            switch (classificationradio)
            {
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 1);
                    break;
                case 2:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 2);
                    break;
                case 3:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 3);
                    break;
            }
            //جستجو در درخواست پاسخ
            switch (replyradio)
            {
                case 0:
                    lettersQuery = lettersQuery.Where(l => l.ReplyStatus == false);
                    break;
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ReplyStatus == true);
                    break;
            }
            //جستجو در پیوست
            switch (attachmentradio)
            {
                case 0:
                    lettersQuery = lettersQuery.Where(l => l.AttachmentStatus == false);
                    break;
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.AttachmentStatus == true);
                    break;
            }
            //جستجو در فوریت نامه
            switch (immediatelytype)
            {
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 1);
                    break;
                case 2:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 2);
                    break;
                case 3:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 3);
                    break;
            }
            //جستجو در وضعیت خوانده شدن
            switch (readradio)
            {
                case 0:
                    lettersQuery = lettersQuery.Where(l => l.ReadType == false);
                    break;
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ReadType == true);
                    break;
            }

            //جستجو در موضوع نامه
            if (searchTypeselected == 1 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.LetterSubject.Contains(inputsearch));
            }
            //جستجو نام فرستنده
            if (searchTypeselected == 2 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.FullName_sender.Contains(inputsearch));
            }
            //جستجو در تاریخ دریافت نامه
            if (searchTypeselected == 3)
            {
                if (fromdate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.LetterSentDate.Date >= fromdate);
                }
                if (todate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.LetterSentDate.Date <= todate);
                }
            }
            //جستجو در تاریخ پاسخ
            if (searchTypeselected == 4)
            {
                if (fromdate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.ReplyDate?.Date >= fromdate);
                }
                if (todate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.ReplyDate?.Date <= todate);
                }
            }
            //جستجو شماره نامه 
            if (searchTypeselected == 5 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.LetterNumber.Contains(inputsearch));
            }

            return lettersQuery.ToList();
        }


        public List<SentLetterViewModel> SentLetters(string userId_sender,
                                             DateTime fromdate,
                                                DateTime todate,
                                                    byte classificationradio = 0,
                                                         byte replyradio = 2,
                                                            byte attachmentradio = 2,
                                                                    byte searchTypeselected = 0,
                                                                        byte immediatelytype = 0,
                                                                            string inputsearch = "")
        {
            var lettersQuery = (from SL in _context.SentLetters
                                join L in _context.Letters on SL.LetterID equals L.LetterID
                                join U in _context.Users on SL.userId_reciever equals U.Id
                                where SL.userId_sender == userId_sender
                                select new SentLetterViewModel()
                                {
                                    LetterID = L.LetterID,
                                    LetterSubject = L.LetterSubject,
                                    LetterContent = L.LetterContent,
                                    UserID_Sender = SL.userId_sender,
                                    Family_Reciever = U.Family,
                                    FirstName_Reciever = U.FirstName,
                                    FullName_Reciever = U.FirstName + " " + U.Family,
                                    UserName_Reciever = U.UserName,
                                    LetterSentDate = SL.SentLetterDate,
                                    LetterAttachamentFile = L.LetterAttachamentFile,
                                    //
                                    ReplyStatus = L.ReplyStatus,
                                    ReplyStatusText =
                                    (L.ReplyStatus == true) ? "دارد" :
                                    (L.ReplyStatus == false) ? "ندارد" : null,
                                    //
                                    AttachmentStatus = L.AttachmentStatus,
                                    AttachmentStatusText =
                                    (L.AttachmentStatus == true) ? "دارد" :
                                    (L.AttachmentStatus == false) ? "ندارد" : null,
                                    //
                                    ImmediatellyStatus = L.ImmediatellyStatus,
                                    ImmediatellyStatusText =
                                    (L.ImmediatellyStatus == 1) ? "عادی" :
                                    (L.ImmediatellyStatus == 2) ? "فوری" :
                                    (L.ImmediatellyStatus == 3) ? "آنی" : null,
                                    //
                                    ClassificationStatus = L.ClassificationStatus,
                                    ClassificationStatusText =
                                    (L.ClassificationStatus == 1) ? "عادی" :
                                    (L.ClassificationStatus == 2) ? "محرمانه" :
                                    (L.ClassificationStatus == 3) ? "فوق محرمانه" : null,
                                    //
                                    ReplyDate = L.ReplyDate,
                                    LetterNumber = L.LetterNumber,
                                    LetterType = L.LetterType,
                                    MainLetterID = L.MainLetterID
                                }).AsEnumerable();

            //جستجو در طبقه بندی نامه ها
            switch (classificationradio)
            {
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 1);
                    break;
                case 2:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 2);
                    break;
                case 3:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 3);
                    break;
            }
            //جستجو در درخواست پاسخ
            switch (replyradio)
            {
                case 0:
                    lettersQuery = lettersQuery.Where(l => l.ReplyStatus == false);
                    break;
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ReplyStatus == true);
                    break;
            }
            //جستجو در پیوست
            switch (attachmentradio)
            {
                case 0:
                    lettersQuery = lettersQuery.Where(l => l.AttachmentStatus == false);
                    break;
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.AttachmentStatus == true);
                    break;
            }
            //جستجو در فوریت نامه
            switch (immediatelytype)
            {
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 1);
                    break;
                case 2:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 2);
                    break;
                case 3:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 3);
                    break;
            }

            //جستجو در موضوع نامه
            if (searchTypeselected == 1 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.LetterSubject.Contains(inputsearch));
            }
            //جستجو نام فرستنده
            if (searchTypeselected == 2 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.FullName_Reciever.Contains(inputsearch));
            }
            //جستجو در تاریخ دریافت نامه
            if (searchTypeselected == 3)
            {
                if (fromdate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.LetterSentDate.Date >= fromdate);
                }
                if (todate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.LetterSentDate.Date <= todate);
                }
            }
            //جستجو در تاریخ پاسخ
            if (searchTypeselected == 4)
            {
                if (fromdate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.ReplyDate?.Date >= fromdate);
                }
                if (todate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.ReplyDate?.Date <= todate);
                }
            }
            //جستجو شماره نامه 
            if (searchTypeselected == 5 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.LetterNumber.Contains(inputsearch));
            }

            return lettersQuery.ToList();
        }

        public List<ReferLetterViewModel> ReferLetters(string userId,
                                     DateTime fromdate,
                                        DateTime todate,
                                            byte classificationradio = 0,
                                                    byte attachmentradio = 2,
                                                            byte searchTypeselected = 0,
                                                                byte immediatelytype = 0,
                                                                    string inputsearch = "")
        {
            var lettersQuery = (from RL in _context.ReferralLetters
                                join L in _context.Letters on RL.LetterID equals L.LetterID
                                where RL.ReferUserID == userId
                                select new ReferLetterViewModel()
                                {
                                    LetterID = L.LetterID,
                                    LetterSubject = L.LetterSubject,
                                    LetterContent = L.LetterContent,
                                    AttachmentStatus = L.AttachmentStatus,
                                    AttachmentStatusText =
                                    (L.AttachmentStatus == true) ? "دارد" :
                                    (L.AttachmentStatus == false) ? "ندارد" : null,
                                    //
                                    ImmediatellyStatus = L.ImmediatellyStatus,
                                    ImmediatellyStatusText =
                                    (L.ImmediatellyStatus == 1) ? "عادی" :
                                    (L.ImmediatellyStatus == 2) ? "فوری" :
                                    (L.ImmediatellyStatus == 3) ? "آنی" : null,
                                    //
                                    ClassificationStatus = L.ClassificationStatus,
                                    ClassificationStatusText =
                                    (L.ClassificationStatus == 1) ? "عادی" :
                                    (L.ClassificationStatus == 2) ? "محرمانه" :
                                    (L.ClassificationStatus == 3) ? "فوق محرمانه" : null,
                                    //
                                    LetterNumber = L.LetterNumber,

                                    //ایجاد کننده نامه
                                    UserInfo_Creator = _context.Users.Where(u => u.Id == RL.mainUserID).
                                        Select(u => new ReferLetterUserInfo()
                                        {
                                            FullName = u.FirstName + " " + u.Family,
                                            UserID = u.Id,
                                            UserName = u.UserName
                                        }).Single(),
                                    //گیرنده ارجاع
                                    UserInfo_RecievedRefer = _context.Users.Where(u => u.Id == RL.RecieveReferUserID).
                                        Select(u => new ReferLetterUserInfo()
                                        {
                                            FullName = u.FirstName + " " + u.Family,
                                            UserID = u.Id,
                                            UserName = u.UserName
                                        }).Single(),
                                    LetterReferDate = RL.ReferDate,
                                    LetterAttachamentFile = L.LetterAttachamentFile
                                }).AsEnumerable();

            //جستجو در طبقه بندی نامه ها
            switch (classificationradio)
            {
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 1);
                    break;
                case 2:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 2);
                    break;
                case 3:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 3);
                    break;
            }

            //جستجو در پیوست
            switch (attachmentradio)
            {
                case 0:
                    lettersQuery = lettersQuery.Where(l => l.AttachmentStatus == false);
                    break;
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.AttachmentStatus == true);
                    break;
            }
            //جستجو در فوریت نامه
            switch (immediatelytype)
            {
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 1);
                    break;
                case 2:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 2);
                    break;
                case 3:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 3);
                    break;
            }

            //جستجو در موضوع نامه
            if (searchTypeselected == 1 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.LetterSubject.Contains(inputsearch));
            }
            //جستجو نام ایجاد کننده نامه
            if (searchTypeselected == 2 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.UserInfo_Creator.FullName.Contains(inputsearch));
            }
            //جستجو نام گیرنده ارجاع
            if (searchTypeselected == 3 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.UserInfo_RecievedRefer.FullName.Contains(inputsearch));
            }
            //جستجو در تاریخ ارجاع نامه
            if (searchTypeselected == 4)
            {
                if (fromdate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.LetterReferDate.Date >= fromdate);
                }
                if (todate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.LetterReferDate.Date <= todate);
                }
            }

            //جستجو شماره نامه 
            if (searchTypeselected == 5 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.LetterNumber.Contains(inputsearch));
            }

            return lettersQuery.ToList();
        }

        public List<RecievedReferLetterViewModel> RecievedReferLetters(string userId,
                                                                DateTime fromdate,
                                                                    DateTime todate,
                                                                        byte classificationradio = 0,
                                                                            byte attachmentradio = 2,
                                                                                byte searchTypeselected = 0,
                                                                                    byte immediatelytype = 0,
                                                                                        string inputsearch = "")
        {
            var lettersQuery = (from RL in _context.ReferralLetters
                                join L in _context.Letters on RL.LetterID equals L.LetterID
                                where RL.RecieveReferUserID == userId
                                select new RecievedReferLetterViewModel()
                                {
                                    LetterID = L.LetterID,
                                    LetterSubject = L.LetterSubject,
                                    LetterContent = L.LetterContent,
                                    AttachmentStatus = L.AttachmentStatus,
                                    AttachmentStatusText =
                                    (L.AttachmentStatus == true) ? "دارد" :
                                    (L.AttachmentStatus == false) ? "ندارد" : null,
                                    //
                                    ImmediatellyStatus = L.ImmediatellyStatus,
                                    ImmediatellyStatusText =
                                    (L.ImmediatellyStatus == 1) ? "عادی" :
                                    (L.ImmediatellyStatus == 2) ? "فوری" :
                                    (L.ImmediatellyStatus == 3) ? "آنی" : null,
                                    //
                                    ClassificationStatus = L.ClassificationStatus,
                                    ClassificationStatusText =
                                    (L.ClassificationStatus == 1) ? "عادی" :
                                    (L.ClassificationStatus == 2) ? "محرمانه" :
                                    (L.ClassificationStatus == 3) ? "فوق محرمانه" : null,
                                    //
                                    LetterNumber = L.LetterNumber,

                                    //ایجاد کننده نامه
                                    UserInfo_Creator = _context.Users.Where(u => u.Id == RL.mainUserID).
                                        Select(u => new ReferLetterUserInfo()
                                        {
                                            FullName = u.FirstName + " " + u.Family,
                                            UserID = u.Id,
                                            UserName = u.UserName
                                        }).Single(),
                                    //فرستنده ارجاع
                                    UserInfo_Refer = _context.Users.Where(u => u.Id == RL.ReferUserID).
                                        Select(u => new ReferLetterUserInfo()
                                        {
                                            FullName = u.FirstName + " " + u.Family,
                                            UserID = u.Id,
                                            UserName = u.UserName
                                        }).Single(),
                                    LetterrecievedReferDate = RL.ReferDate,
                                    LetterAttachamentFile = L.LetterAttachamentFile
                                }).AsEnumerable();

            //جستجو در طبقه بندی نامه ها
            switch (classificationradio)
            {
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 1);
                    break;
                case 2:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 2);
                    break;
                case 3:
                    lettersQuery = lettersQuery.Where(l => l.ClassificationStatus == 3);
                    break;
            }

            //جستجو در پیوست
            switch (attachmentradio)
            {
                case 0:
                    lettersQuery = lettersQuery.Where(l => l.AttachmentStatus == false);
                    break;
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.AttachmentStatus == true);
                    break;
            }
            //جستجو در فوریت نامه
            switch (immediatelytype)
            {
                case 1:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 1);
                    break;
                case 2:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 2);
                    break;
                case 3:
                    lettersQuery = lettersQuery.Where(l => l.ImmediatellyStatus == 3);
                    break;
            }

            //جستجو در موضوع نامه
            if (searchTypeselected == 1 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.LetterSubject.Contains(inputsearch));
            }
            //جستجو نام ایجاد کننده نامه
            if (searchTypeselected == 2 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.UserInfo_Creator.FullName.Contains(inputsearch));
            }
            //جستجو نام گیرنده ارجاع
            if (searchTypeselected == 3 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.UserInfo_Refer.FullName.Contains(inputsearch));
            }
            //جستجو در تاریخ ارجاع نامه
            if (searchTypeselected == 4)
            {
                if (fromdate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.LetterrecievedReferDate.Date >= fromdate);
                }
                if (todate != null)
                {
                    lettersQuery = lettersQuery.Where(l => l.LetterrecievedReferDate.Date <= todate);
                }
            }

            //جستجو شماره نامه 
            if (searchTypeselected == 5 && inputsearch != null)
            {
                lettersQuery = lettersQuery.Where(l => l.LetterNumber.Contains(inputsearch));
            }

            return lettersQuery.ToList();
        }

        public MyLetterViewModel ReadLetter(int LetterID)
        {
            var lettersQuery = (from SL in _context.SentLetters
                                join L in _context.Letters on SL.LetterID equals L.LetterID
                                join U in _context.Users on SL.userId_sender equals U.Id
                                where L.LetterID == LetterID
                                select new MyLetterViewModel()
                                {
                                    LetterID = L.LetterID,
                                    LetterSubject = L.LetterSubject,
                                    LetterContent = L.LetterContent,
                                    UserID_Sender = SL.userId_sender,
                                    UserID_Reciever = SL.userId_reciever,
                                    LetterSentDate = SL.SentLetterDate,
                                    LetterAttachamentFile = L.LetterAttachamentFile,
                                    //
                                    ReplyStatus = L.ReplyStatus,
                                    ReplyStatusText =
                                    (L.ReplyStatus == true) ? "دارد" :
                                    (L.ReplyStatus == false) ? "ندارد" : null,
                                    //
                                    AttachmentStatus = L.AttachmentStatus,
                                    AttachmentStatusText =
                                    (L.AttachmentStatus == true) ? "دارد" :
                                    (L.AttachmentStatus == false) ? "ندارد" : null,
                                    //
                                    ImmediatellyStatus = L.ImmediatellyStatus,
                                    ImmediatellyStatusText =
                                    (L.ImmediatellyStatus == 1) ? "عادی" :
                                    (L.ImmediatellyStatus == 2) ? "فوری" :
                                    (L.ImmediatellyStatus == 3) ? "آنی" : null,
                                    //
                                    ClassificationStatus = L.ClassificationStatus,
                                    ClassificationStatusText =
                                    (L.ClassificationStatus == 1) ? "عادی" :
                                    (L.ClassificationStatus == 2) ? "محرمانه" :
                                    (L.ClassificationStatus == 3) ? "فوق محرمانه" : null,
                                    //
                                    ReplyDate = L.ReplyDate,
                                    //
                                    ReadType = SL.ReadType,
                                    ReadTypeText =
                                    (SL.ReadType == true) ? "خوانده" :
                                    (SL.ReadType == false) ? "نخوانده" : null,
                                    LetterNumber = L.LetterNumber,
                                    LetterType = L.LetterType,
                                    MainLetterID = L.MainLetterID
                                }).AsEnumerable();

            return lettersQuery.Single();
        }

        public string GetUserJob(string UserID)
        {
            var userjob = (from UJ in _context.UserJobs
                           join JC in _context.JobsCharts on UJ.JobID equals JC.JobsChartID
                           where UJ.UserID == UserID
                           where UJ.IaHaveJob == true
                           select JC.JobsChartName).Single();
            return userjob;
        }

        public int GetUserJobID(string UserID)
        {
            var userjob = (from UJ in _context.UserJobs
                           join JC in _context.JobsCharts on UJ.JobID equals JC.JobsChartID
                           where UJ.UserID == UserID
                           where UJ.IaHaveJob == true
                           select JC.JobsChartID);
            if (userjob.Count() == 0)
            {
                return 0;
            }
            return userjob.Single();
        }

        public string GetUserSignature(string UserID)
        {
            var model = (from U in _context.Users where U.Id == UserID select U.SignaturePath).Single();
            return model;
        }


        public void UpdateLetterReadStatus(int LetterID)
        {
            var result = (from l in _context.SentLetters where l.LetterID == LetterID select l);
            var currentLetter = result.FirstOrDefault();

            if (result.Count() > 0)
            {

                currentLetter.ReadType = true;;
                
                _context.SentLetters.Attach(currentLetter);
                _context.Entry(currentLetter).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
