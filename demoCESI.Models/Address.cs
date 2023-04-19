using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoCESI.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(10)]
        public string StreetNumber { get; set; } = string.Empty;

        [StringLength(100)]
        public string StreetName { get; set; } = string.Empty;

        [StringLength(10)]
        public string PostalCode { get; set; } = string.Empty;

        [StringLength(50)]
        public string Vicinity { get; set; } = string.Empty;

        public virtual IEnumerable<Person> Persons { get; set; } = new List<Person>();
    }
}
