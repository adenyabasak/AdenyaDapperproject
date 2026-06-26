namespace AdenyaDapperProject.Models
{
    public class JobModel
    {
        public int JobId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Budget { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }

        
        public string CategoryName { get; set; }

        public string FullName { get; set; }
    }
}