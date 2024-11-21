using greenVolt.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static greenVolt.Dominio.Favoritos;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace greenVolt.Data
{
    
    public class Connection(DbContextOptions<Connection> options) : DbContext(options)
    {

        private string connectionString = "Host=fiap.audracs.com.br;Port=5234;Username=postgres;Password=Jyxi0Pv0PzSqRLc54pMg9NANKkh;Database=global_solution_green_energy_2024;";

        // Cada DbSet Mapeia uma entidade para uma tabela no banco de dados.
        public DbSet<Usuario> Usuarios { get; set; } // DbSet<Usuario> para a tabela TAB_USUARIO.
        public DbSet<Empresa> Empresas { get; set; } // DbSet<Empresa> para a tabela TAB_EMPRESAS.
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

    }
}
