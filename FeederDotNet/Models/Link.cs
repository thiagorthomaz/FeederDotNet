using System.ComponentModel.DataAnnotations;

namespace FeederDotNet.Models
{
    public class Link
    {
        [Key]
        public string Url { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? CrawledAt { get; set; }
        public DateTime? ScrapedAt { get; set; }
        public DateTime? InactivatedAt { get; set; }
        public string Status { get; set; }
    }
}
