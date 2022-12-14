using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
    public class RecievedNotationListViewModel
    {
        public int NotationID { get; set; }
        public string NotationTitle { get; set; }
        public string NotationContent { get; set; }
        public DateTime NotationDate { get; set; }
        public NotationCreatorInfo CreatorInfo { get; set; }
        public string UserID_Reciever { get; set; }
    }

    public class SentNotationListViewModel
    {
        public int NotationID { get; set; }
        public string NotationTitle { get; set; }
        public string NotationContent { get; set; }
        public DateTime NotationDate { get; set; }
        public NotationCreatorInfo RecieverInfo { get; set; }
        public string UserID_Creator { get; set; }
    }

    public class NotationCreatorInfo
    {
        public string FirstName { get; set; }
        public string Family { get; set; }
        public string FullName { get; set; }
        public string UserID_Creator { get; set; }
    }
}