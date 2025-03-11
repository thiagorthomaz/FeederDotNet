using System.ComponentModel.DataAnnotations;

namespace FeederDotNet.Models
{
    public class CrawledLink
    {
        [Key]
        public string Url { get; set; }
        public DateTime CrawledAt { get; set; }
    }
}
