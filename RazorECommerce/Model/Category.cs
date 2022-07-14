using System.ComponentModel.DataAnnotations;

namespace RazorECommerce.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name="Category Name")]
        public string Name { get; set; }
        [Display(Name="Display Order"), Range(1, 100, ErrorMessage = "'Display Order' must be in range of 1-100!")]
        public int DisplayOrder { get; set; }
    }
}
