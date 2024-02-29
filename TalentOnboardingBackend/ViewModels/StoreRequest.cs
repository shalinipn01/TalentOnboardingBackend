using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.ViewModels
{
    public class StoreRequest
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Store Name is required")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Store Address is required")]
        public String Address { get; set; }
    }
}
