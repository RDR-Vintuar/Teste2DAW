using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2DAW.Models
{[Table("Copias")]
    public class Copia
    {
    public int CopiaID { get; set; }

    public int FilmeID { get; set; }
    public virtual Filme Filme { get; set; }

    public int EstadoID { get; set; }
    public virtual Estado Estado { get; set; }

    public Boolean disponivel { get;set;}

    public virtual ICollection<AlugerCopias> copias { get; set; }
}}