using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyBackend.Model
{
    [Table("Points")]
    
    public class Points
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid PlayerId { get; set; }
        [Required]
        public Guid leagueId { get; set; }
        [Required]
        public int points { get; set; }
    }
}
