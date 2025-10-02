using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Esports_Management.Models
{
    public class RegisterModel
    {
        [Key]
        public int Ath_Id { get; set; }

        [Display(Name = "Athlete Details")]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public UserModel User { get; set; }

        [Display(Name = "Sport Details")]
        public int EId { get; set; }
        [ForeignKey("EId")]
        public EventModel Event { get; set; }
    }
}
