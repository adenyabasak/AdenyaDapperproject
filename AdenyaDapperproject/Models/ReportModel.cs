namespace AdenyaDapperProject.Models
{
    public class ReportModel
    {
        public int TotalUsers { get; set; }

        public int TotalJobs { get; set; }

        public string CategoryName { get; set; }

        public int JobCount { get; set; }

        public string Title { get; set; }

        public int TotalBid { get; set; }

        public decimal AverageBid { get; set; }

        public decimal Budget { get; set; }

        public decimal Price { get; set; }

        public string Message { get; set; }

        public DateTime BidDate { get; set; }
    }
}