using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.ViewModels
{
    public class EditStoreRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Store Name is required")]
        public String Name { get; set; }
        public String Address { get; set; }
    }
}
