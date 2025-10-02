using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esports_Management.Models
{
    public class NewsModel
    {
        [Key]
        public int Notice_Id { get; set; }
        public int Notice_Code { get; set; }
        public string Description { get; set; }
        public string image_path { get; set; }
        public DateTime Notice_Date { get; set; } = DateTime.Now;
        [NotMapped]
        public IFormFile NoticePdf { get; set; }

        public string CreatedBy { get; set; }
        public int EId { get; set; }
        [ForeignKey("EId")]
        public EventModel Event { get; set; }

    }
}
