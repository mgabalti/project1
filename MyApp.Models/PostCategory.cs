using System.ComponentModel.DataAnnotations;

namespace MyApp.Models
{
    public class PostCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CatName { get; set; }
        public DateTime CatCreatedDate{ get; set; } = DateTime.Now;

        
    }
}
