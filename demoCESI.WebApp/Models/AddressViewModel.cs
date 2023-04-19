using demoCESI.Models;
using System.ComponentModel.DataAnnotations;

namespace demoCESI.WebApp.Models
{
    public class AddressViewModel
    {
        public int? Id { get; set; }

        [StringLength(10)]
        [Required]
        public string StreetNumber { get; set; } = string.Empty;

        [StringLength(100)]
        [Required]
        public string StreetName { get; set; } = string.Empty;

        [StringLength(10)]
        [Required]
        public string PostalCode { get; set; } = string.Empty;

        [StringLength(50)]
        [Required]
        public string Vicinity { get; set; } = string.Empty;
    }
}
