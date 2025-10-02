using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Esports_Management.Models
{
    public class UserModel
    {
        [Display(Name = "Student Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public int CId { get; set; }
        [ForeignKey("CId")]
        public OrganizerModel Organizer { get; set; }

    }
}
