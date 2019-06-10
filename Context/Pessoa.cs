using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Context
{
    public class Pessoa
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string Nome { get; set; }
        [MaxLength(300)]
        public string Cidade { get; set; }
        [MaxLength(150)]
        public string Estado { get; set; }
        [MaxLength(8)]
        public string CEP { get; set; }
    }
}
