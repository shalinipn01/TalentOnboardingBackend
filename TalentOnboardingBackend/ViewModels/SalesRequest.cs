using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.ViewModels
{
    public class SalesRequest
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Sales is required")]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime DateSold { get; set; }
    }
}
