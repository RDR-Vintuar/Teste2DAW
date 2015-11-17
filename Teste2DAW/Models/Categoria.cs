using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2DAW.Models
{
[Table("Categorias")]
    public class Categoria
    {
    public int CategoriaID { get; set; }
    public string Designacao { get; set; }

    public virtual ICollection<Filme> filmes { get; set; }

    }
}