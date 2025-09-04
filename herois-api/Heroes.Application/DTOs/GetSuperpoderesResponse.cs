using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Application.DTOs
{
    public class GetSuperpoderesResponse
    {
        public int Id { get; set; }
        public string Superpoder { get; set; }
        public string? Descricao { get; set; }
    }
}
