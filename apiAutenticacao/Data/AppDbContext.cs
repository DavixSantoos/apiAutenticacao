using apiAutenticacao.Controllers;
using apiAutenticacao.Models;
using Microsoft.EntityFrameworkCore;

namespace apiAutenticacao.Data
{
    public class AppDbContext : DbContext // Classe que representa o contexto do banco de dados
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)// Construtor da classe que recebe as opções de configuração do DbContext
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }// Vai ser cirada a tabela Usuarios no banco de dados

        public DbSet<Endereco> Enderecos { get; set; } // Vai ser criada a tabela Enderecos no banco de dados

        public DbSet<Telefone> Telefones { get; set; } // Vai ser criada a tabela Telefones no banco de dados

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração: 1 Usuário tem N (Muitos) Telefones
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Telefones)
                .WithOne(t => t.Usuario) // Supondo que na classe Telefone tem uma prop "Usuario"
                .HasForeignKey(t => t.UsuarioId); // A chave estrangeira

            // Configuração: 1 Usuário tem N (Muitas) Tarefas (Turnos/Escalas)
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Tarefas)
                .WithOne(t => t.UsuarioId) // Supondo que na classe Tarefa tem uma prop "Usuario"
                .HasForeignKey(t => t.UsuarioId);
        }
    }
}
    
    
    
    }

}


