using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Domain.Entities
{
    [Table("Herois")]
    public class HeroiEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required]
        [Column("NomeHeroi")]
        public string NomeHeroi { get; set; }

        [Column("DataNascimento")]
        public DateTime? DataNascimento { get; set; }

        [Required]
        [Column("Altura")]
        public float Altura { get; set; }

        [Required]
        [Column("Peso")]
        public float Peso { get; set; }

        public List<HeroisSuperpoderesEntity> HeroisSuperpoderes { get; set; }
    }
}
