using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeederDotNet.Models
{
    public class Dataset
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        //
        // Value:
        //     The clean title
        [Required]
        public string Text { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Url { get; set; }

    }
}
