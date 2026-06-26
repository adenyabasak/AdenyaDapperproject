using AdenyaDapperProject.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;




namespace AdenyaDapperProject.Controllers
{
    [SessionControl]
    public class JobController : Controller
    {
        private readonly Context _context;

        public JobController(Context context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Title", search);

                var searchResult = _context.Listele<JobModel>("JobSearch", param);
                return View(searchResult);
            }

            var values = _context.Listele<JobModel>("JobList");
            return View(values);
        }

        [HttpGet]
        [AdminControl]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Listele<CategoryModel>("CategoryList"), "CategoryId", "CategoryName");
            ViewBag.Users = new SelectList(_context.Listele<UserModel>("UserList"), "UserId", "FullName");

            return View();
        }

        [HttpPost]
        [AdminControl]
        public IActionResult Create(JobModel job)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Title", job.Title);
            param.Add("@Description", job.Description);
            param.Add("@Budget", job.Budget);
            param.Add("@CategoryId", job.CategoryId);
            param.Add("@UserId", job.UserId);

            _context.Execute("JobAdd", param);

            return RedirectToAction("Index");
        }
        [AdminControl]
        public IActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@JobId", id);

            _context.Execute("JobDelete", param);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [AdminControl]
        public IActionResult Edit(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@JobId", id);

            var value = _context.Getir<JobModel>("JobGetById", param);

            ViewBag.Categories = new SelectList(_context.Listele<CategoryModel>("CategoryList"), "CategoryId", "CategoryName");
            ViewBag.Users = new SelectList(_context.Listele<UserModel>("UserList"), "UserId", "FullName");

            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(JobModel job)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@JobId", job.JobId);
            param.Add("@Title", job.Title);
            param.Add("@Description", job.Description);
            param.Add("@Budget", job.Budget);
            param.Add("@CategoryId", job.CategoryId);
            param.Add("@UserId", job.UserId);

            _context.Execute("JobUpdate", param);

            return RedirectToAction("Index");
        }

        public IActionResult ExportToPdf()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var jobs = _context.Listele<JobModel>("JobList");

            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Header()
                        .Text("İş İlanları Raporu")
                        .SemiBold()
                        .FontSize(20)
                        .FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingTop(1, Unit.Centimetre)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(35);
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.ConstantColumn(80);
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("ID").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Başlık").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Kategori").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Bütçe").Bold();
                                header.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Kullanıcı").Bold();
                            });

                            foreach (var item in jobs)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.JobId.ToString());
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Title);
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.CategoryName);
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Budget.ToString("N0") + " TL");
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.FullName);
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Sayfa ");
                            x.CurrentPageNumber();
                        });
                });
            });

            var pdfBytes = pdfDocument.GeneratePdf();

            return File(pdfBytes, "application/pdf", $"Is_Ilanlari_{DateTime.Now:yyyyMMdd}.pdf");
        }

        public IActionResult ExportToExcel()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Adenya Freelance");

            var jobs = _context.Listele<JobModel>("JobList");

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("İş İlanları");

                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Başlık";
                worksheet.Cells[1, 3].Value = "Açıklama";
                worksheet.Cells[1, 4].Value = "Bütçe";
                worksheet.Cells[1, 5].Value = "Kategori";
                worksheet.Cells[1, 6].Value = "Kullanıcı";

                using (var range = worksheet.Cells[1, 1, 1, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(41, 128, 185));
                    range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                int rowNumber = 2;

                foreach (var item in jobs)
                {
                    worksheet.Cells[rowNumber, 1].Value = item.JobId;
                    worksheet.Cells[rowNumber, 2].Value = item.Title;
                    worksheet.Cells[rowNumber, 3].Value = item.Description;
                    worksheet.Cells[rowNumber, 4].Value = item.Budget;
                    worksheet.Cells[rowNumber, 5].Value = item.CategoryName;
                    worksheet.Cells[rowNumber, 6].Value = item.FullName;

                    rowNumber++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var fileBytes = package.GetAsByteArray();

                return File(
                    fileBytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"Is_Ilanlari_{DateTime.Now:yyyyMMdd}.xlsx"
                );
            }
        }
    }
}