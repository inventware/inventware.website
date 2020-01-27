using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventware.Application.Core2.DTOs
{
    public class TextBlockDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório!")]
        [Display(Name = "Nome")]
        [MaxLength(120, ErrorMessage = "O comprimento máximo foi excedido, tamanho máximo é de 120 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório!")]
        [Display(Name = "Conteúdo")]
        [MaxLength(1024, ErrorMessage = "O comprimento máximo foi excedido, tamanho máximo é de 1024 caracteres.")]
        public string Content { get; set; }

        public bool IsVisible { get; set; }

        public Guid LoggedUser { get; set; }
    }
}
