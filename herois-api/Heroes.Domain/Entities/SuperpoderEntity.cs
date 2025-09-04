using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Domain.Entities
{
    [Table("Superpoderes")]
    public class SuperpoderEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("Superpoder")]
        public string Superpoder { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        public ICollection<HeroisSuperpoderesEntity> HeroisSuperpoderes { get; set; }
    }
}
