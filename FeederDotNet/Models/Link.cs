using System.ComponentModel.DataAnnotations;

namespace FeederDotNet.Models
{
    public class Link
    {
        [Key]
        public string Url { get; set; }
        public DateTime CrawledAt { get; set; }
        public DateTime? ScrapedAt { get; set; }
        public string Status { get; set; }
    }
}
