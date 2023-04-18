using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoCESI.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(30)]
        public string Phone { get; set; } = string.Empty;
    }
}
