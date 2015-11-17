using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teste2DAW.Models
{[Table("Filmes")]
    public class Filme
    {
    public int FilmeID { get; set; }
    public string Titulo { get; set; }

    public string Sinopse { get; set; }

    public int CategoriaID { get; set; }

    public virtual Categoria Categoria { get; set; }

    public string ActorPrincipal { get; set; }

    public string ActorSecundario { get; set; }

    public virtual ICollection<Copia> copias { get; set; }
    }
}