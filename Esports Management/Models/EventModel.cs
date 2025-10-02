using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Esports_Management.Models
{
    public class EventModel
    {
        [Key]

        [Display(Name = "Employee Id")]
        public int EId { get; set; }

        [Display(Name = "Event Name")]

        public string E_Name { get; set; }

        public string Venue { get; set; }

        [NotMapped]
        public IFormFile CoverPhoto { get; set; }

        public string image_path { get; set; }

        public DateTime DateTime { get; set; }

        [Display(Name = "Organiser")]
        public string CreatedBy { get; set; }
        [Display(Name = "Sport")]
        public int SId { get; set; }
        [ForeignKey("SId")]
        public SportModel Sport { get; set; }

    }
}
