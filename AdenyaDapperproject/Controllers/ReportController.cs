using AdenyaDapperProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdenyaDapperProject.Controllers
{
    [AdminControl]
    public class ReportController : Controller
    {
        private readonly Context _context;

        public ReportController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var totalUsers = _context.Getir<ReportModel>("ReportTotalUsers", null);
            var totalJobs = _context.Getir<ReportModel>("ReportTotalJobs", null);
            var mostBidJob = _context.Getir<ReportModel>("ReportMostBidJob", null);
            var averageBid = _context.Getir<ReportModel>("ReportAverageBid", null);

            var categoryReports = _context.Listele<ReportModel>("ReportJobCountByCategory");
            var lastJobs = _context.Listele<ReportModel>("ReportLastJobs");
            var lastBids = _context.Listele<ReportModel>("ReportLastBids");

            ViewBag.TotalUsers = totalUsers?.TotalUsers ?? 0;
            ViewBag.TotalJobs = totalJobs?.TotalJobs ?? 0;
            ViewBag.MostBidJobTitle = mostBidJob?.Title ?? "Henüz teklif yok";
            ViewBag.MostBidJobCount = mostBidJob?.TotalBid ?? 0;
            ViewBag.AverageBid = averageBid?.AverageBid ?? 0;

            ViewBag.LastJobs = lastJobs;
            ViewBag.LastBids = lastBids;

            return View(categoryReports);
        }
    }
}