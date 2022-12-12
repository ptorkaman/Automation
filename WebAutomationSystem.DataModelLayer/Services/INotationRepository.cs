using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface INotationRepository
    {
        List<RecievedNotationListViewModel> RecievedNotationList(string userId,
                                                                            DateTime fromdate,
                                                                                DateTime todate,
                                                                                    byte searchTypeselected = 0,
                                                                                        string inputsearch = "");

        List<SentNotationListViewModel> SentNotationList(string userId,
                                                                        DateTime fromdate,
                                                                            DateTime todate,
                                                                                byte searchTypeselected = 0,
                                                                                    string inputsearch = "");
    }
}
