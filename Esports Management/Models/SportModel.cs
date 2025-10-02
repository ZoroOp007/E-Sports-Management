using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Esports_Management.Models
{
    public class SportModel
    {
        [Key]
        public int SId { get; set; }

        [Display(Name = "Sport Name")]
        public string Sp_Name { get; set; }
        [Display(Name = "Sport Type")]
        public string Sp_Type { get; set; }
        [Display(Name = "Description")]
        public string Sp_Description { get; set; }
    }
}
