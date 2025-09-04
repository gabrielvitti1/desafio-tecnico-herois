using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Application.DTOs
{
    public class CreateHeroiRequest
    {
        [MaxLength(120)]
        public String Nome { get; set; }
        [MaxLength(120)]
        public String NomeHeroi { get; set; }
        public DateTime? DataNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public List<int> SuperpoderesIds { get; set; }
    }
}
