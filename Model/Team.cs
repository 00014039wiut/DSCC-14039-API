using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DSCC.CW1._14039.Model
{
    public class Team
    {
       
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Sport { get; set; } 
        public string? Division { get; set; }
        public Coach? TeamCoach { get; set; }
    }
}
