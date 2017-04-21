using System;
using System.Collections.Generic;

namespace TreinoCrudMVC.Domain
{
    public class Editora
    {
        public int EditoraId { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public virtual IEnumerable<Livro> Livros { get; set; }
    }
}