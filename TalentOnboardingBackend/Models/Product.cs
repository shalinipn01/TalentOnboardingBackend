using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual ICollection<Sale> ProductSold { get; set; }
    }
}
