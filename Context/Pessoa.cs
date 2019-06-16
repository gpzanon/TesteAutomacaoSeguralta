namespace Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa")]
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            Contato = new HashSet<Contato>();
            StatusMensagemEnviada = new HashSet<StatusMensagemEnviada>();
        }

        public int Id { get; set; }

        [StringLength(300)]
        public string Nome { get; set; }

        [StringLength(300)]
        public string Cidade { get; set; }

        [StringLength(150)]
        public string Estado { get; set; }

        [StringLength(8)]
        public string Cep { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contato> Contato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatusMensagemEnviada> StatusMensagemEnviada { get; set; }
    }
}
