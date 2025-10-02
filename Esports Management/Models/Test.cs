using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace Esports_Management.Models
{
    public class Test
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int Marks { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
    }
}
