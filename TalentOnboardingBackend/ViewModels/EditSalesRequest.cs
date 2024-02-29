using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.ViewModels
{
    public class EditSalesRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Store is required")]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public string DateSold { get; set; }
    }
}
