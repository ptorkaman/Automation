using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Repository;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface ILettersRepository
    {
        Task<Letters> AddAsync(Letters entity, CancellationToken cancellationToken);

        List<LettersListViewModel> LettersList(string userId);
        List<JobsChartWithUserInfoViewModel> JobsChartWithUserInfo();
        void ExitLetterFromDraft(int LetterID, string UserId);
        string GetUserIdFromJobID(int jobid);
        List<MyLetterViewModel> MyLetter(string userId_reciever,
                                                     DateTime fromdate,
                                                        DateTime todate,
                                                            byte classificationradio = 0,
                                                                 byte replyradio = 2,
                                                                    byte attachmentradio = 2,
                                                                        byte readradio = 2,
                                                                            byte searchTypeselected = 0,
                                                                                byte immediatelytype = 0,
                                                                                    string inputsearch = "");

        List<SentLetterViewModel> SentLetters(string userId_sender,
                                             DateTime fromdate,
                                                DateTime todate,
                                                    byte classificationradio = 0,
                                                         byte replyradio = 2,
                                                            byte attachmentradio = 2,
                                                                    byte searchTypeselected = 0,
                                                                        byte immediatelytype = 0,
                                                                            string inputsearch = "");


        List<ReferLetterViewModel> ReferLetters(string userId,
                                     DateTime fromdate,
                                        DateTime todate,
                                            byte classificationradio = 0,
                                                    byte attachmentradio = 2,
                                                            byte searchTypeselected = 0,
                                                                byte immediatelytype = 0,
                                                                    string inputsearch = "");

        List<RecievedReferLetterViewModel> RecievedReferLetters(string userId,
                                                                DateTime fromdate,
                                                                    DateTime todate,
                                                                        byte classificationradio = 0,
                                                                            byte attachmentradio = 2,
                                                                                byte searchTypeselected = 0,
                                                                                    byte immediatelytype = 0,
                                                                                        string inputsearch = "");

        MyLetterViewModel ReadLetter(string userid,int LetterID);
        string GetUserJob(string UserID);
        int GetUserJobID(string UserID);
        string GetUserSignature(string UserID);
        void UpdateLetterReadStatus(string UserID,int LetterID);
    }
}
