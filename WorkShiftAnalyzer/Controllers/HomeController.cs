using System.Diagnostics;
using Application.Interfaces;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Domain.Models.EmployeeWork;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using WorkShiftAnalyzer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorkShiftAnalyzer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorkShiftServices _workShiftServices;

        public HomeController(ILogger<HomeController> logger,IWorkShiftServices workShiftServices)
        {
            _logger = logger;
            _workShiftServices = workShiftServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task< IActionResult> ReportAll()
        {
            WorkDeficitViewModel model = new WorkDeficitViewModel();

            model.ExcessBreakCounts=  await  _workShiftServices.ExcessBreakCalc();
            model.WorkDeficitCounts =await _workShiftServices.WorkDeficitCalc();


            return View(model);
        }

        public async Task< IActionResult> Report()
        {
            EmployeeWorkLogViewModel model = new EmployeeWorkLogViewModel();
            model=await _workShiftServices.GetAllUserAndDates();
            return View(model);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "لطفاً یک فایل اکسل انتخاب کنید!";
                return RedirectToAction("Index");
            }

            var errors = new List<string>(); // لیست خطاها
            string fileName = Path.GetFileName(file.FileName);

            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    using (var workbook = new XLWorkbook(stream))
                    {
                        var worksheet = workbook.Worksheet(1);
                        var rows = worksheet.RowsUsed().Skip(1); // حذف هدر

                        var workLogs = new List<EmployeeWorkLog>();

                        int rowNumber = 2; // شماره سطر (برای نمایش خطا)

                        foreach (var row in rows)
                        {
                         
                            try
                            {
                                TimeSpan  Workstart = TimeSpan.TryParse(row.Cell(4).GetValue<string>(), out var workHours) ? workHours : TimeSpan.Zero;
                                TimeSpan  Workend = TimeSpan.TryParse(row.Cell(5).GetValue<string>(), out var workEnd) ? workEnd : TimeSpan.Zero;
                                TimeSpan  Breaktime = TimeSpan.TryParse(row.Cell(6).GetValue<string>(), out var breakTime) ? breakTime : TimeSpan.Zero;
                                TimeSpan Workhours = Workend - Workstart;

                                var log = new EmployeeWorkLog
                                {
                                    EmployeeCode = row.Cell(2).GetValue<string>(),
                                    EmployeeName = row.Cell(1).GetValue<string>(),
                                    Date = Convert.ToDateTime(row.Cell(3).GetValue<string>()),
                                    WorkStart = Workstart,
                                    WorkEnd = Workend,
                                    WorkHours =Workhours,
                                    BreakTime = Breaktime,
                                    Usefulwork=(Workhours - Breaktime),
                                    FileName=fileName,
                                    ShiftId = _workShiftServices.GetShiftId(row.Cell(7).GetValue<string>().ToUpper())
                                };

                                // بررسی مقدار خالی
                                if (string.IsNullOrEmpty(log.EmployeeCode) || string.IsNullOrEmpty(log.EmployeeName))
                                {
                                    errors.Add($"خطا در سطر {rowNumber}: کد یا نام کارمند خالی است!");
                                    continue;
                                }

                                workLogs.Add(log);
                            }
                            catch (Exception ex)
                            {
                                errors.Add($"خطا در سطر {rowNumber}: {ex.Message}");
                            }

                            rowNumber++;
                        }

                        if (errors.Any())
                        {
                            TempData["ErrorList"] = errors;
                        }
                        else
                        {
                            await _workShiftServices.AddRangeAsync(workLogs);
                            TempData["Success"] = "اطلاعات با موفقیت ذخیره شد!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"خطای کلی: {ex.Message}";
            }

            return RedirectToAction("Index");
        }




    }


}
