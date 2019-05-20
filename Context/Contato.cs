namespace Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contato")]
    public partial class Contato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contato()
        {
            StatusMensagemEnviada = new HashSet<StatusMensagemEnviada>();
        }

        public int Id { get; set; }

        public int? Pessoa { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(3)]
        public string DDD { get; set; }

        [StringLength(15)]
        public string Telefone { get; set; }

        public virtual Pessoa Pessoa1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatusMensagemEnviada> StatusMensagemEnviada { get; set; }
    }
}
