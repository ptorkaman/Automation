using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.StaticClassValue
{
    public class ImmediatellyTypeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<ImmediatellyTypeModel> GetImmediatellyTypeModel()
        {
            var model = new List<ImmediatellyTypeModel>
            {
                new ImmediatellyTypeModel {ID = 0, Title = "همه"},
                new ImmediatellyTypeModel {ID = 1, Title = "عادی"},
                new ImmediatellyTypeModel {ID = 2, Title = "فوری"},
                new ImmediatellyTypeModel {ID = 3, Title = "آنی"},
            };
            return model;
        }
    }

    public class LetterSearchTypeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<LetterSearchTypeModel> GetLetterTypeModel()
        {
            var model = new List<LetterSearchTypeModel>
            {
                new LetterSearchTypeModel {ID = 0, Title = "---انتخاب---"},
                new LetterSearchTypeModel {ID = 1, Title = "موضوع"},
                new LetterSearchTypeModel {ID = 2, Title = "نام فرستنده"},
                new LetterSearchTypeModel {ID = 3, Title = "تاریخ دریافت"},
                new LetterSearchTypeModel {ID = 4, Title = "تاریخ پاسخ"},
                new LetterSearchTypeModel {ID = 5, Title = "شماره نامه"},
            };
            return model;
        }
    }

    public class SentLetterSearchTypeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<SentLetterSearchTypeModel> GetSentLetterTypeModel()
        {
            var model = new List<SentLetterSearchTypeModel>
            {
                new SentLetterSearchTypeModel {ID = 0, Title = "---انتخاب---"},
                new SentLetterSearchTypeModel {ID = 1, Title = "موضوع"},
                new SentLetterSearchTypeModel {ID = 2, Title = "نام گیرنده"},
                new SentLetterSearchTypeModel {ID = 3, Title = "تاریخ ارسال"},
                new SentLetterSearchTypeModel {ID = 4, Title = "تاریخ پاسخ"},
                new SentLetterSearchTypeModel {ID = 5, Title = "شماره نامه"},
            };
            return model;
        }
    }

    public class ReferLetterSearchTypeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<ReferLetterSearchTypeModel> GetReferLetterTypeModel()
        {
            var model = new List<ReferLetterSearchTypeModel>
            {
                new ReferLetterSearchTypeModel {ID = 0, Title = "---انتخاب---"},
                new ReferLetterSearchTypeModel {ID = 1, Title = "موضوع"},
                new ReferLetterSearchTypeModel {ID = 2, Title = "نام ایجاد کننده"},
                new ReferLetterSearchTypeModel {ID = 3, Title = "نام گیرنده"},
                new ReferLetterSearchTypeModel {ID = 4, Title = "تاریخ ارجاع"},
                new ReferLetterSearchTypeModel {ID = 5, Title = "شماره نامه"},
            };
            return model;
        }
    }

    public class RecievedReferLetterSearchTypeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<RecievedReferLetterSearchTypeModel> GetRecievedReferLetterTypeModel()
        {
            var model = new List<RecievedReferLetterSearchTypeModel>
            {
                new RecievedReferLetterSearchTypeModel {ID = 0, Title = "---انتخاب---"},
                new RecievedReferLetterSearchTypeModel {ID = 1, Title = "موضوع"},
                new RecievedReferLetterSearchTypeModel {ID = 2, Title = "نام ایجاد کننده"},
                new RecievedReferLetterSearchTypeModel {ID = 3, Title = "نام ارسال کننده"},
                new RecievedReferLetterSearchTypeModel {ID = 4, Title = "تاریخ دریافت"},
                new RecievedReferLetterSearchTypeModel {ID = 5, Title = "شماره نامه"},
            };
            return model;
        }
    }

    public class RecievedNotationSearchTypeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<RecievedNotationSearchTypeModel> GetRecievedNotationTypeModel()
        {
            var model = new List<RecievedNotationSearchTypeModel>
            {
                new RecievedNotationSearchTypeModel {ID = 0, Title = "---انتخاب---"},
                new RecievedNotationSearchTypeModel {ID = 1, Title = "موضوع یادداشت"},
                new RecievedNotationSearchTypeModel {ID = 2, Title = "نام فرستنده"},
                new RecievedNotationSearchTypeModel {ID = 3, Title = "تاریخ دریافت"},
            };
            return model;
        }
    }

    public class SentNotationSearchTypeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<SentNotationSearchTypeModel> GetSentNotationTypeModel()
        {
            var model = new List<SentNotationSearchTypeModel>
            {
                new SentNotationSearchTypeModel {ID = 0, Title = "---انتخاب---"},
                new SentNotationSearchTypeModel {ID = 1, Title = "موضوع یادداشت"},
                new SentNotationSearchTypeModel {ID = 2, Title = "نام گیرنده"},
                new SentNotationSearchTypeModel {ID = 3, Title = "تاریخ ارسال"},
            };
            return model;
        }
    }

    public class EnterDocumentListSearchTypeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<EnterDocumentListSearchTypeModel> GetEnterDocumentListSearchTypeModel()
        {
            var model = new List<EnterDocumentListSearchTypeModel>
            {
                new EnterDocumentListSearchTypeModel {ID = 0, Title = "---انتخاب---"},
                new EnterDocumentListSearchTypeModel {ID = 1, Title = "موضوع"},
                new EnterDocumentListSearchTypeModel {ID = 2, Title = "مرجع صدور سند"},
                new EnterDocumentListSearchTypeModel {ID = 3, Title = "شماره سند"},
                new EnterDocumentListSearchTypeModel {ID = 4, Title = "واحد دریافت کننده"},
                new EnterDocumentListSearchTypeModel {ID = 5, Title = "تاریخ ثبت"},
            };
            return model;
        }
    }

    public class PrivateEnterDocumentListSearchTypeModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<PrivateEnterDocumentListSearchTypeModel> GetPrivateEnterDocumentListSearchTypeModel()
        {
            var model = new List<PrivateEnterDocumentListSearchTypeModel>
            {
                new PrivateEnterDocumentListSearchTypeModel {ID = 0, Title = "---انتخاب---"},
                new PrivateEnterDocumentListSearchTypeModel {ID = 1, Title = "موضوع"},
                new PrivateEnterDocumentListSearchTypeModel {ID = 2, Title = "مرجع صدور سند"},
                new PrivateEnterDocumentListSearchTypeModel {ID = 3, Title = "شماره سند"},
                new PrivateEnterDocumentListSearchTypeModel {ID = 5, Title = "تاریخ ثبت"},
            };
            return model;
        }
    }
}
