namespace AdenyaDapperProject.Models
{
    public class BidModel
    {
        public int BidId { get; set; }

        public int JobId { get; set; }

        public int UserId { get; set; }

        public decimal Price { get; set; }

        public string Message { get; set; }

        public DateTime BidDate { get; set; }

        
        public string Title { get; set; }

        public string FullName { get; set; }
    }
}