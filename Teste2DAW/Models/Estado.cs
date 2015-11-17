using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2DAW.Models
{
    [Table("Estados")]
    public class Estado
    {
        public int EstadoID { get; set; }
        public string Designacao { get; set; }

        public virtual ICollection<Copia> copias { get; set; }
    }
}