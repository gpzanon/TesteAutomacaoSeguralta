using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Context
{
    public class StatusMensagemEnviada
    {
        public int Id { get; set; }
        public Pessoa Pessoa { get; set; }
        public Contato Contato { get; set; }
        [MaxLength(1000)]
        public string Assunto { get; set; }
        public string MensagemEnviada { get; set; }
        public string RetornoSite { get; set; }
    }
}
