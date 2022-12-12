using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface IForignDocumentRepository
    {
        string CreateDoumentNumber();
        List<ForeignDocumentViewModel> ForeignDocumentList(string userId,
                                                                    DateTime fromdate,
                                                                         DateTime todate,
                                                                              byte searchTypeselected = 0,
                                                                                    string inputsearch = "");


        List<ForeignDocumentViewModel> PrivateForeignDocumentList(string userId,
                                                                            DateTime fromdate,
                                                                                DateTime todate,
                                                                                    byte searchTypeselected = 0,
                                                                                        string inputsearch = "");
    }
}
