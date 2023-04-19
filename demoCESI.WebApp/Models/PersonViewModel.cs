using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demoCESI.WebApp.Models
{
    public class PersonViewModel
    {
        public int? Id { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [StringLength(100)]
        [Required]
        public string Email { get; set; } = string.Empty;

        [StringLength(30)]
        [Required]
        public string Phone { get; set; } = string.Empty;

        public int? AddressId { get; set; }
    }
}
