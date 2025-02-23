using System.ComponentModel.DataAnnotations;

namespace first_api.Data.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
       public required string Name { get; set; }
        public string? Notes { get; set; }
    }
}
