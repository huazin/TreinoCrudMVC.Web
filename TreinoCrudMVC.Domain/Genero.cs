using System;
using System.Collections.Generic;

namespace TreinoCrudMVC.Domain
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public virtual IEnumerable<Livro> Livros { get; set; }
    }
}