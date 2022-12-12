using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
    public class CreateLeaveViewModel
    {
        public int LeaveID { get; set; }
        //1 ساعتی
        //2 استحقاقی
        //3 استعلاجی
        //4 بدون حقوق
        public byte LeaveType { get; set; }

        [Display(Name = "از تاریخ")]
        public string FromDate_Day { get; set; }
        [Display(Name = "تا تاریخ")]
        public string ToDate_Day { get; set; }
        [Display(Name = "از ساعت")]
        public string FromTime_Saati { get; set; }
        [Display(Name = "تا ساعت")]
        public string ToTime_Saati { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        //تاریخ ثبت درخواست
        public DateTime LeaveRequestDate { get; set; }
        public string UserID_Request { get; set; }
        public string UserID_Confirm { get; set; }
        //1 در حال بررسی
        //2 پذیرفته شده
        //3 رد شده
        public byte LeaveAccept { get; set; }
    }

    public class LeaveListViewModel
    {
        public int LeaveID { get; set; }
        //1 ساعتی
        //2 استحقاقی
        //3 استعلاجی
        //4 بدون حقوق
        public byte LeaveType { get; set; }
        public string LeaveTypeDesc { get; set; }

        public DateTime? FromDate_Day { get; set; }
        public DateTime? ToDate_Day { get; set; }
        public DateTime? FromTime_Saati { get; set; }
        public DateTime? ToTime_Saati { get; set; }
        public string Description { get; set; }
        //تاریخ ثبت درخواست
        public DateTime LeaveRequestDate { get; set; }
        public string UserID_Request { get; set; }
        public string UserID_Confirm { get; set; }
        public string FirstName_Confirm { get; set; }
        public string Family_Confirm { get; set; }
        public string FullName_Confirm { get; set; }
        public string FullName_Request { get; set; }
        //1 در حال بررسی
        //2 پذیرفته شده
        //3 رد شده
        public byte LeaveAccept { get; set; }
        public string LeaveAcceptDesc { get; set; }
    }

    public class LeaveManagementViewModel
    {
        public int LeaveID { get; set; }
        //1 ساعتی
        //2 استحقاقی
        //3 استعلاجی
        //4 بدون حقوق
        public byte LeaveType { get; set; }
        public string LeaveTypeDesc { get; set; }

        public DateTime? FromDate_Day { get; set; }
        public DateTime? ToDate_Day { get; set; }
        public DateTime? FromTime_Saati { get; set; }
        public DateTime? ToTime_Saati { get; set; }
        public string Description { get; set; }
        //تاریخ ثبت درخواست
        public DateTime LeaveRequestDate { get; set; }
        public string UserID_Request { get; set; }
        public string FirstName_Request { get; set; }
        public string Family_Request { get; set; }
        public string FullName_Request { get; set; }
        public string UserID_Confirm { get; set; }
 
        //1 در حال بررسی
        //2 پذیرفته شده
        //3 رد شده
        public byte LeaveAccept { get; set; }
        public string LeaveAcceptDesc { get; set; }
    }
}