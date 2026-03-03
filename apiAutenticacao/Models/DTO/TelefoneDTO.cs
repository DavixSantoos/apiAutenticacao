using Microsoft.OpenApi.Models;

namespace apiAutenticacao.Models.DTO
{
    public class TelefoneDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}
