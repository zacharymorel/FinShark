namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        // The "?"is optional. Not required for FK to be present.
        public int? StockId { get; set; } // FK
        public Stocks? Stocks { get; set; } // NAVIGATION Property that tells EF where to find Parent Model/ Table

    }
}