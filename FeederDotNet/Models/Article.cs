using System.ComponentModel.DataAnnotations;

namespace FeederDotNet.Models
{
    public class Article
    {

        [Key]
        [Required]
        public Uri Uri { get; set; }

        //
        // Value:
        //     The clean title
        [Required]
        public string Title { get; set; }

        //
        // Value:
        //     The URI of the main image
        public string? FeaturedImage { get; set; }

        //
        // Value:
        //     The HTML content
        [Required]
        public string Content { get; set; }

        //
        // Value:
        //     The excerpt provided by the metadata
        public string? Excerpt { get; set; }

        //
        // Value:
        //     The language provided by the metadata
        public string? Language { get; set; }

        //
        // Value:
        //     The author, which can be parsed or read in the metadata
        public string? Author { get; set; }

        //
        // Value:
        //     The name of the website, which can be parsed or read in the metadata
        public string? SiteName { get; set; }

        //
        // Value:
        //     The publication date, which can be parsed or read in the metadata
        public DateTime? PublicationDate { get; }

        //
        // Value:
        //     It indicates whether an article was actually found
        [Required]
        public bool IsReadable { get; set; }

        //
        // Value:
        //     The pure-text content cleaned to be readable
        [Required]
        public string TextContent { get; set; }

    }
}
