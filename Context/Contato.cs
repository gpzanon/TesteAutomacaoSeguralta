using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Context
{
    public class Contato
    {
        public int Id { get; set; }
        public Pessoa Pessoa { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(3)]
        public string DDD { get; set; }
        [MaxLength(15)]
        public string Telefone { get; set; }
    }
}
