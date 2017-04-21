using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TreinoCrudMVC.Domain;

namespace TreinoCrudMVC.Web.ViewModel
{
    public class EditoraViewModel
    {
        [Key]
        public int EditoraId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatorio")]
        [MaxLength(150, ErrorMessage = "Tamanho maximo é 150 caracteres")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataDeCadastro { get; set; }

        [ScaffoldColumn(false)]
        public virtual IEnumerable<Livro> Livros { get; set; }
    }
}