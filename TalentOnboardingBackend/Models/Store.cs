using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.Models
{
    public class Store
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Store Name is required")]
        public String Name { get; set; }
        public String Address { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual ICollection<Sale> ProductSold { get; set; }
    }
}
