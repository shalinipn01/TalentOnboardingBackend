using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public virtual ICollection<Sale> ProductSold { get; set; }
    }
}
