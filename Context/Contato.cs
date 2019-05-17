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
        public int Id { get; set; }

        public int? Pessoa { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public virtual Pessoa Pessoa1 { get; set; }
    }
}
