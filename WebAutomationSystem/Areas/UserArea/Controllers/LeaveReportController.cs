using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using WebAutomationSystem.CommonLayer.PublicClass;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class LeaveReportController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IUserRepository _iuser;
        private readonly IWebHostEnvironment _hosting;


        public LeaveReportController(IUnitOfWork context,
                                        IUserRepository iuser,
                                            IWebHostEnvironment hosting)
        {
            _context = context;
            _iuser = iuser;
            _hosting = hosting;

            var stimulKey = Path.Combine(_hosting.ContentRootPath, "wwwroot\\reports\\license", "license.key");
            if (System.IO.File.Exists(stimulKey))
            {
                StiLicense.LoadFromFile(stimulKey);
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchInUser(string term)
        {
            try
            {
                var query = _iuser.GetUserForSearchInAutoCompelet(term).
                                Select(U => new { label = U.UserFullName, id = U.UserId });
                return Ok(query);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        public IActionResult CreateLeaveReport(string userfullname,
                                                    string fromdate,
                                                        string todate,
                                                            int leavetype,
                                                                string userid)
        {
            StiReport report = new StiReport();
            report["fullname"] = userfullname;
            report["startdate"] = fromdate;
            report["enddate"] = todate;
            report["reportdate"] = ConvertDateTime.ConvertMiladiToShamsi(DateTime.Now, "yyyy/MM/dd");
            //Stored Procedure Parameter
            report["fromdate"] = "'" + (ConvertDateTime.ConvertShamsiToMiladi(fromdate).ToString("yyyy-MM-dd" , new CultureInfo("ar-JO"))) + "'";
            report["todate"] = "'" + (ConvertDateTime.ConvertShamsiToMiladi(todate).ToString("yyyy-MM-dd" , new CultureInfo("ar-JO"))) + "'";
            report["leavetype"] = leavetype;
            report["userid"] = "'" + userid + "'";
            //
            switch (leavetype)
            {
                case -1:
                    report["leavetypedesc"] = "همه";
                    break;
                case 1:
                    report["leavetypedesc"] = "ساعتی";
                    break;
                case 2:
                    report["leavetypedesc"] = "استحقاقی";
                    break;
                case 3:
                    report["leavetypedesc"] = "استعلاجی";
                    break;
                case 4:
                    report["leavetypedesc"] = "بدون حقوق";
                    break;
            }

            Stimulsoft.Base.StiFontCollection.AddFontFile("wwwroot/fonts/bmitra/B_Mitra.ttf");
            ///
            report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/reports/userLeavereport.mrt"));
            return StiNetCoreReportResponse.PrintAsPdf(report);
        }

    }
}