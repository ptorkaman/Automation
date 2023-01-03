using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebAutomationSystem.DataModelLayer.ViewModels;
using WebAutomationSystem.DataModelLayer.Services;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.Entities;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class SentLettersRepository : ISentLettersRepository
    {
        private readonly ApplicationDbContext _context;

        public SentLettersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SentLetters> GetByLetterId(int id, CancellationToken cancellationToken)
        {
            return _context.SentLetters
                .Include(c => c.Users_Reciever)
                .Where(c => c.LetterID == id)
                .ToList();
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

    }
}
