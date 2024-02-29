using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.ViewModels
{
    public class EditCustomerRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer Name is required")]
        public String Name { get; set; }
        
        public String Address { get; set; }
    }
}
