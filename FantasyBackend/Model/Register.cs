using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FantasyBackend.Model
{
    [Table("Users")]
    public class Register
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public String FullName { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
