using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2DAW.Models
{
    [Table("Utente")]
    public class Utente
    {
        public int UtenteID { get; set; }

        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Bairro { get; set; }

        public string distrito { get; set; }

        public string identificacao { get; set; }

        public virtual ICollection<Aluger> aluger { get; set; }
    }
}