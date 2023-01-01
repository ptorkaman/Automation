using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Repository;

namespace WebAutomationSystem.DataModelLayer.Services
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
        }

        private GenericClass<ApplicationUsers> _userManager;
        private GenericClass<ApplicationRoles> _roleManager;
        private GenericClass<JobsChart> _jobsChart;
        private GenericClass<UserJob> _userJob;
        private GenericClass<Reminder> _reminder;
        private GenericClass<RolePattern> _rolePattern;
        private GenericClass<RolePatternDetails> _rolePatterDetails;
        private GenericClass<Letters> _letters;
        private GenericClass<AdministrativeForm> _administrativeForm;
        private GenericClass<SentLetters> _sentLetters;
        private GenericClass<ReferralLetters> _referralLetters;
        private GenericClass<Notation> _notation;
        private GenericClass<Leave> _leave;
        private GenericClass<ForeignDocument> _foreignDocument;

        private GenericClass<Category> _category;
        private GenericClass<Blob> _blob;
        private GenericClass<BlobDescription> _blobDescription;
        private GenericClass<BlobStream> _blobStream;
        private GenericClass<Cartable> _cartable;
        private GenericClass<CartableUser> _cartableUser;
        private GenericClass<SecretariatType> _secretariatType;
        private GenericClass<Group> _group;
        private GenericClass<GroupUser> _groupUser;
        private GenericClass<LetterUser> _letterUser;

        //ثبت گیرندگان نامه   
        public GenericClass<LetterUser> letterUserUW
        {
            //فقط خواندنی    
            get
            {
                if (_letterUser == null)
                {
                    _letterUser = new GenericClass<LetterUser>(_context);
                }
                return _letterUser;
            }
        }

        //ثبت گروه   
        public GenericClass<GroupUser> groupUserUW
        {
            //فقط خواندنی    
            get
            {
                if (_groupUser == null)
                {
                    _groupUser = new GenericClass<GroupUser>(_context);
                }
                return _groupUser;
            }
        }

        //ثبت گروه   
        public GenericClass<Group> groupUW
        {
            //فقط خواندنی    
            get
            {
                if (_group == null)
                {
                    _group = new GenericClass<Group>(_context);
                }
                return _group;
            }
        }


        //ثبت دبیرخانه   
        public GenericClass<SecretariatType> secretariatTypeUW
        {
            //فقط خواندنی    
            get
            {
                if (_secretariatType == null)
                {
                    _secretariatType = new GenericClass<SecretariatType>(_context);
                }
                return _secretariatType;
            }
        }

        //ثبت کاربر کارتابل   
        public GenericClass<CartableUser> cartableUserUW
        {
            //فقط خواندنی    
            get
            {
                if (_cartableUser == null)
                {
                    _cartableUser = new GenericClass<CartableUser>(_context);
                }
                return _cartableUser;
            }
        }

        //ثبت کارتابل   
        public GenericClass<Cartable> cartableUW
        {
            //فقط خواندنی    
            get
            {
                if (_cartable == null)
                {
                    _cartable = new GenericClass<Cartable>(_context);
                }
                return _cartable;
            }
        }

        //ثبت توضیحات  فایل
        public GenericClass<BlobStream> blobStreamUW
        {
            //فقط خواندنی    
            get
            {
                if (_blobStream == null)
                {
                    _blobStream = new GenericClass<BlobStream>(_context);
                }
                return _blobStream;
            }
        }

        //ثبت توضیحات  فایل
        public GenericClass<BlobDescription> blobDescriptionUW
        {
            //فقط خواندنی    
            get
            {
                if (_blobDescription == null)
                {
                    _blobDescription = new GenericClass<BlobDescription>(_context);
                }
                return _blobDescription;
            }
        }

        //ثبت فایل
        public GenericClass<Blob> blobUW
        {
            //فقط خواندنی    
            get
            {
                if (_blob == null)
                {
                    _blob = new GenericClass<Blob>(_context);
                }
                return _blob;
            }
        }

        //ثبت انواع کتگوری
        public GenericClass<Category> categoryUW
        {
            //فقط خواندنی    
            get
            {
                if (_category == null)
                {
                    _category = new GenericClass<Category>(_context);
                }
                return _category;
            }
        }

        //ثبت اسناد وارده به سازمان
        public GenericClass<ForeignDocument> foreignDocumentUW
        {
            //فقط خواندنی    
            get
            {
                if (_foreignDocument == null)
                {
                    _foreignDocument = new GenericClass<ForeignDocument>(_context);
                }
                return _foreignDocument;
            }
        }

        //مرخصی
        public GenericClass<Leave> leaveUW
        {
            //فقط خواندنی    
            get
            {
                if (_leave == null)
                {
                    _leave = new GenericClass<Leave>(_context);
                }
                return _leave;
            }
        }


        //یادداشت
        public GenericClass<Notation> notationUW
        {
            //فقط خواندنی    
            get
            {
                if (_notation == null)
                {
                    _notation = new GenericClass<Notation>(_context);
                }
                return _notation;
            }
        }

        //ارجاع نامه
        public GenericClass<ReferralLetters> referralLettersUW
        {
            //فقط خواندنی    
            get
            {
                if (_referralLetters == null)
                {
                    _referralLetters = new GenericClass<ReferralLetters>(_context);
                }
                return _referralLetters;
            }
        }

        //نامه های ارسال شده
        public GenericClass<SentLetters> sentLettersUW
        {
            //فقط خواندنی    
            get
            {
                if (_sentLetters == null)
                {
                    _sentLetters = new GenericClass<SentLetters>(_context);
                }
                return _sentLetters;
            }
        }

        //نامه های پیش فرض
        public GenericClass<AdministrativeForm> administrativeFormUW
        {
            //فقط خواندنی    
            get
            {
                if (_administrativeForm == null)
                {
                    _administrativeForm = new GenericClass<AdministrativeForm>(_context);
                }
                return _administrativeForm;
            }
        }

        //نامه ها
        public GenericClass<Letters> lettersUW
        {
            //فقط خواندنی    
            get
            {
                if (_letters == null)
                {
                    _letters = new GenericClass<Letters>(_context);
                }
                return _letters;
            }
        }

        //جزییات نقش های کاربری
        public GenericClass<RolePatternDetails> rolePatternDetailsUW
        {
            //فقط خواندنی    
            get
            {
                if (_rolePatterDetails == null)
                {
                    _rolePatterDetails = new GenericClass<RolePatternDetails>(_context);
                }
                return _rolePatterDetails;
            }
        }

        //نقش های کاربری
        public GenericClass<RolePattern> rolePatternUW
        {
            //فقط خواندنی    
            get
            {
                if (_rolePattern == null)
                {
                    _rolePattern = new GenericClass<RolePattern>(_context);
                }
                return _rolePattern;
            }
        }

        //یادآوری
        public GenericClass<Reminder> reminderUW
        {
            //فقط خواندنی    
            get
            {
                if (_reminder == null)
                {
                    _reminder = new GenericClass<Reminder>(_context);
                }
                return _reminder;
            }
        }

        //جدول تخصیص شغل به کاربر
        public GenericClass<UserJob> userJobUW
        {
            //فقط خواندنی    
            get
            {
                if (_userJob == null)
                {
                    _userJob = new GenericClass<UserJob>(_context);
                }
                return _userJob;
            }
        }

        //چارت مشاغل سازمانی
        public GenericClass<JobsChart> jobsChartUW
        {
            //فقط خواندنی    
            get
            {
                if (_jobsChart == null)
                {
                    _jobsChart = new GenericClass<JobsChart>(_context);
                }
                return _jobsChart;
            }
        }

        //کاربران
        public GenericClass<ApplicationUsers> userManagerUW
        {
            //فقط خواندنی    
            get
            {
                if (_userManager == null)
                {
                    _userManager = new GenericClass<ApplicationUsers>(_context);
                }
                return _userManager;
            }
        }

        //نقش ها
        public GenericClass<ApplicationRoles> roleManagerUW
        {
            //فقط خواندنی    
            get
            {
                if (_roleManager == null)
                {
                    _roleManager = new GenericClass<ApplicationRoles>(_context);
                }
                return _roleManager;
            }
        }

        public IEntityDataBaseTransaction BeginTransaction()
        {
            return new EntityDataBaseTransaction(_context);
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}