namespace Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatusMensagemEnviada")]
    public partial class StatusMensagemEnviada
    {
        public int Id { get; set; }

        public int? Pessoa { get; set; }

        public int? Contato { get; set; }

        [StringLength(1000)]
        public string Assunto { get; set; }

        public string MensagemEnviada { get; set; }

        public string RetornoSite { get; set; }

        public virtual Contato Contato1 { get; set; }

        public virtual Pessoa Pessoa1 { get; set; }
    }
}
