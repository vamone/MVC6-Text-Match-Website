using System.ComponentModel.DataAnnotations;

namespace TextMatch.Website.Models
{
    public class TextMatchViewModel
    {
        [Required]
        [Display(Name = "Main text")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "Searching text")]
        public string SubText { get; set; }

        [Display(Name = "Result")]
        public string MatchingResult { get; set; }
    }
}