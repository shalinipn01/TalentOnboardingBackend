using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.ViewModels
{
    public class EditProductRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        public String Name { get; set; }
        public double Price { get; set; }
    }
}
