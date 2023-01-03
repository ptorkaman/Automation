using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WebAutomationSystem.DataModelLayer.ViewModels;
using WebAutomationSystem.DataModelLayer.Services;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.Entities;
using System.Threading;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class ReferralLetterRepository : IReferralLetterRepository
    {
        private readonly ApplicationDbContext _context;

        public ReferralLetterRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void UpdateLetterReadStatus(string userID ,int LetterID)
        {
            var result = (from l in _context.ReferralLetters where l.LetterID == LetterID && l.RecieveReferUserID == userID select l);
            var currentLetter = result.FirstOrDefault();

            if (result.Count() > 0)
            {

                currentLetter.ReadType = true; ;

                _context.ReferralLetters.Attach(currentLetter);
                _context.Entry(currentLetter).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
        }

    }
}
