using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.ViewModels
{
    public class ProductRequest
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
    }
}
