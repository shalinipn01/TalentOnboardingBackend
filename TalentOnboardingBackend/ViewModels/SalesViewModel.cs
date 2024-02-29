using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.ViewModels
{
    public class SalesViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string StoreName { get; set; }
        public int StoreId { get; set; }

        public String DateSold { get; set; }
    }
}
