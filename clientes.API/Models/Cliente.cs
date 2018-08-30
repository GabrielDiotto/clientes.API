using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clientes.API.Models
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Salario { get; set; }
    }
}
