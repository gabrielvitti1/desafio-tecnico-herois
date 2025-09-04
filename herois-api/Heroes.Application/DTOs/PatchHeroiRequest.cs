using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Application.DTOs
{
    public class PatchHeroiRequest
    {
        public string? Nome { get; set; }
        public string? NomeHeroi { get; set; }
        public DateTime? DataNascimento { get; set; }
        public float? Altura { get; set; }
        public float? Peso { get; set; }
        public List<int>? SuperpoderesIds { get; set; }
    }
}
