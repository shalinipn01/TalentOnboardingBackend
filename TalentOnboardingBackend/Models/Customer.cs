using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual ICollection<Sale> ProductSold { get; set; }
    }
}
