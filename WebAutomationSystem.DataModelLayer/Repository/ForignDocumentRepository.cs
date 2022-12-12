using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class ForignDocumentRepository : IForignDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public ForignDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string CreateDoumentNumber()
        {
            var query = (from d in _context.ForeignDocuments select d.ForeignDocumentID).ToList();
            string DocumentNo = "";
            if (query.Count > 0)
            {
                DocumentNo = "9000" + (query.Last() + 1);
            }
            else
            {
                DocumentNo = "90001";
            }
            return DocumentNo;
        }

        public List<ForeignDocumentViewModel> ForeignDocumentList(string userId,
                                                                    DateTime fromdate,
                                                                         DateTime todate,
                                                                              byte searchTypeselected = 0,
                                                                                    string inputsearch = "")
        {
            var Query = (from FD in _context.ForeignDocuments
                                join J in _context.JobsCharts on FD.JobsChartID equals J.JobsChartID
                                where FD.UserID_SaveDocument == userId
                                
                                select new ForeignDocumentViewModel()
                                {
                                   DocumentNumber = FD.DocumentNumber,
                                   DocumentTitle = FD.DocumentTitle,
                                   FullNameDelivery = FD.FullNameDelivery,
                                   DocumentContent = FD.DocumentContent,
                                   DocumentEnterDate = FD.DocumentEnterDate,
                                   DocumentImagePath = FD.DocumentImagePath,
                                   ForeignDocumentID = FD.ForeignDocumentID,
                                   JobsChartID = FD.JobsChartID,
                                   OrgnizationDocumentName = FD.OrgnizationDocumentName,
                                   UserID_RecieveDocument = FD.UserID_RecieveDocument,
                                   PhoneNumberDelivery = FD.PhoneNumberDelivery,
                                   UserID_SaveDocument = FD.UserID_SaveDocument,
                                   JobsChartName = J.JobsChartName
                                }).AsEnumerable();

            //موضوع سند
            if (searchTypeselected == 1 && inputsearch != null)
            {
                Query = Query.Where(l => l.DocumentTitle.Contains(inputsearch));
            }
            //مرجع صادر کننده
            if (searchTypeselected == 2 && inputsearch != null)
            {
                Query = Query.Where(l => l.OrgnizationDocumentName.Contains(inputsearch));
            }
            //شماره سند
            if (searchTypeselected == 3 && inputsearch != null)
            {
                Query = Query.Where(l => l.DocumentNumber.Contains(inputsearch));
            }
            //واحد دریافت کننده
            if (searchTypeselected == 4 && inputsearch != null)
            {
                Query = Query.Where(l => l.JobsChartName.Contains(inputsearch));
            }
            if (searchTypeselected == 5)
            {
                if (fromdate != null)
                {
                    Query = Query.Where(l => l.DocumentEnterDate.Date >= fromdate);
                }
                if (todate != null)
                {
                    Query = Query.Where(l => l.DocumentEnterDate.Date <= todate);
                }
            }


            return Query.ToList();
        }


        public List<ForeignDocumentViewModel> PrivateForeignDocumentList(string userId,
                                                                            DateTime fromdate,
                                                                                DateTime todate,
                                                                                    byte searchTypeselected = 0,
                                                                                        string inputsearch = "")
        {
            var Query = (from FD in _context.ForeignDocuments
                         where FD.UserID_RecieveDocument == userId

                         select new ForeignDocumentViewModel()
                         {
                             DocumentNumber = FD.DocumentNumber,
                             DocumentTitle = FD.DocumentTitle,
                             FullNameDelivery = FD.FullNameDelivery,
                             DocumentContent = FD.DocumentContent,
                             DocumentEnterDate = FD.DocumentEnterDate,
                             DocumentImagePath = FD.DocumentImagePath,
                             ForeignDocumentID = FD.ForeignDocumentID,
                             JobsChartID = FD.JobsChartID,
                             OrgnizationDocumentName = FD.OrgnizationDocumentName,
                             UserID_RecieveDocument = FD.UserID_RecieveDocument,
                             PhoneNumberDelivery = FD.PhoneNumberDelivery,
                             UserID_SaveDocument = FD.UserID_SaveDocument
                         }).AsEnumerable();

            //موضوع سند
            if (searchTypeselected == 1 && inputsearch != null)
            {
                Query = Query.Where(l => l.DocumentTitle.Contains(inputsearch));
            }
            //مرجع صادر کننده
            if (searchTypeselected == 2 && inputsearch != null)
            {
                Query = Query.Where(l => l.OrgnizationDocumentName.Contains(inputsearch));
            }
            //شماره سند
            if (searchTypeselected == 3 && inputsearch != null)
            {
                Query = Query.Where(l => l.DocumentNumber.Contains(inputsearch));
            }
            if (searchTypeselected == 5)
            {
                if (fromdate != null)
                {
                    Query = Query.Where(l => l.DocumentEnterDate.Date >= fromdate);
                }
                if (todate != null)
                {
                    Query = Query.Where(l => l.DocumentEnterDate.Date <= todate);
                }
            }


            return Query.ToList();
        }
    }
}
