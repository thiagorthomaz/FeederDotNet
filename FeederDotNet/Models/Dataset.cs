using System.ComponentModel.DataAnnotations;

namespace FeederDotNet.Models
{
    public class Dataset
    {

        [Key]
        [Required]
        public Uri Uri { get; set; }

        //
        // Value:
        //     The clean title
        [Required]
        public string Text { get; set; }

        [Required]
        public string Classification { get; set; }

    }
}
