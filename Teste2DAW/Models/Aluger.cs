using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2DAW.Models
{[Table("Aluger")]
    public class Aluger
    {
    public int AlugerID { get; set; }

    public int FuncionarioID { get; set; }
    public virtual Funcionario Funcionario { get; set; }

    public int UtenteID { get; set; }

    public virtual Utente Utente { get; set; }
        
    public DateTime dataEmpretimo { get; set; }

    public DateTime dataEmtrega { get; set; }

    public Boolean devolvida { get; set; }

    public Boolean Multa { get; set; }
    public virtual ICollection<AlugerCopias> copias { get; set; }


    }
}