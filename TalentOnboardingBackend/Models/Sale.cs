using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Store is required")]
        public int StoreId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateSold { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual Product Product { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual Customer Customer { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual Store Store { get; set; }
    }
}
