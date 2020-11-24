using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Model
{
    [Table("Players")]
    public class Players
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String type { get; set; }
        [Required]
        public String Team { get; set; }
    }
}
