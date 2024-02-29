using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.ViewModels
{
    public class CustomerRequest
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer Name is required")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Customer Address is required")]
        public String Address { get; set; }
    }
}
