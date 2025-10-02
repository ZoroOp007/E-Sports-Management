using System.ComponentModel.DataAnnotations;

namespace Esports_Management.Models
{
    public class OrganizerModel
    {
        [Key]
        public int CId { get; set; }

        public string Name { get; set; }

        public int Code { get; set; }
        public string Address { get; set; }
    }
}
