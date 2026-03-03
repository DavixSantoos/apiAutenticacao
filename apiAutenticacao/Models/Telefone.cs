using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiAutenticacao.Models
{
    [Table("Telefone")]
    public class Telefone
    {
        [Key]
        public int Id { get; set; } // PK do telefone

        [Required(ErrorMessage = "O Telefone é obrigatorio")]
        [StringLength(12, ErrorMessage = "O numero tem que ter no maximo 12 numeros")]
        public string Numero { get; set; } = string.Empty;

        [Required]
        public int UsuarioId { get; set; } // Chave estrangeira para o usuário

        [ForeignKey(nameof(UsuarioId))]
        public Usuario Usuario { get; set; } // Propriedade de navegação para o usuário
    }
}
