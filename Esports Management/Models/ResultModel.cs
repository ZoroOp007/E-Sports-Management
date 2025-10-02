using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Esports_Management.Models
{
    public class ResultModel
    {
        [Key]
        public int RId { get; set; }

        [Required(ErrorMessage = "Choose any Option")]
        [Display(Name = "Event")]

        public int EId { get; set; }
        [ForeignKey(nameof(EId))]
        public EventModel Events { get; set; }

        [Required]
        [Display(Name = "Player1")]
        public int Player1_Id { get; set; }
        [Required]
        [Display(Name = "Score")]
        public int Score1 { get; set; }
        [Required]
        [Display(Name = "Player2")]
        public int Player2_Id { get; set; }
        [Required]
        [Display(Name = "Score")]
        public int Score2 { get; set; }
        [Required]
        [Display(Name = "Result")]
        public string Winner { get; set; }
    }
}
