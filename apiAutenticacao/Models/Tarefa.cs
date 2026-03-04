namespace apiAutenticacao.Models
{
    public class Tarefa
    {
        public int Id { get; set; } // PK da tarefa
        public string Descricao { get; set; } = string.Empty; // Descrição da tarefa
        public DateTime DataHora { get; set; } // Data e hora da tarefa
        public int UsuarioId { get; set; } // Chave estrangeira para o usuário
    }
}
