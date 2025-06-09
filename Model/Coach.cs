using System.ComponentModel.DataAnnotations;

namespace DSCC.CW1._14039.Model
{
    public class Coach
    { 
        public int CoachId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Specialization { get; set; } 
        public int ExperienceYears { get; set; }

    }
}
