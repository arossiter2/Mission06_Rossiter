using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Rossiter.Models
{
    //Model that helps create the database. Everything is required to be inputted except edited, lentTo, and Notes
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required]
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Categories? Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, 3000)]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required]
        public bool CopiedToPlex { get; set; }
        public string? Notes { get; set; }

    }
}
