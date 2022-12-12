using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public interface ILeaveRepository
    {
        int GetUserLeave_Estehghaghi(string UserID, DateTime FromDate, DateTime ToDate);
        int GetUserLeave_Estelaji(string UserID, DateTime FromDate, DateTime ToDate);
        int GetUserLeave_BiHoghugh(string UserID, DateTime FromDate, DateTime ToDate);
        string GetUserLeave_Saati(string UserID, DateTime FromDate, DateTime ToDate);
        List<LeaveListViewModel> LeaveList(string userId_request,
                                                    int leaveType,
                                                        int leaveAccept,
                                                            DateTime fromdate,
                                                                DateTime todate,
                                                                    string confirmname = "");
        List<LeaveManagementViewModel> LeaveManagement(string userId_confirm,
                                                                int leaveType,
                                                                    int leaveAccept,
                                                                        DateTime fromdate,
                                                                            DateTime todate,
                                                                                string requestname = "");
        void AcceptRejectLeave(int LeaveID, byte flag);
        LeaveListViewModel LeavePrint(int LeaveID);
    }
}
