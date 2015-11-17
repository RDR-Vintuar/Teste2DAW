using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2DAW.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        public string Nome { get; set; }

        public string UserName { get; set; }

        public string password { get; set; }

        public virtual ICollection<Aluger> aluger { get; set; }
    }
}