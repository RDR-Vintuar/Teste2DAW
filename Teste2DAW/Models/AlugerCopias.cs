using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2DAW.Models
{
    [Table("AlugerCopias")]
    public class AlugerCopias
    {
    public int id { get; set; }

    public int CopiaID { get; set; }
    public virtual Copia Copia {get;set;}
    public int AlugerID { get;set;}
    public virtual Aluger Aluger { get; set; }
    }
}