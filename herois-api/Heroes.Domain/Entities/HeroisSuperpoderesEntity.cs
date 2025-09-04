using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Domain.Entities
{
    [Table("Herois_Superpoderes")]
    public class HeroisSuperpoderesEntity
    {
        [Column("Heroi_id")]
        [Required]
        public int HeroiId { get; set; }
        public HeroiEntity Heroi { get; set; }

        [Column("Superpoder_id")]
        [Required]
        public int SuperpoderId { get; set; }
        public SuperpoderEntity Superpoder { get; set; }
    }
}
