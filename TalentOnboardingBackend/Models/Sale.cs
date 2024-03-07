using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TalentOnboardingBackend.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime DateSold { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual Product Product { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual Customer Customer { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public virtual Store Store { get; set; }
    }
}
