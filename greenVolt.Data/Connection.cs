using greenVolt.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static greenVolt.Dominio.Favoritos;
using Npgsql;

namespace greenVolt.Data
{
    
    public class Connection : DbContext
    {

        public Connection(DbContextOptions<Connection> options)
           : base(options) { }


        // Cada DbSet Mapeia uma entidade para uma tabela no banco de dados.
        public DbSet<Usuario> Usuarios { get; set; } // DbSet<Usuario> para a tabela TAB_USUARIO.
        public DbSet<Empresa> Empresas { get; set; } // DbSet<Empresa> para a tabela TAB_EMPRESAS.
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }



        string connectionString = "Host=localhost;Port=5432;Username=your_user;Password=your_password;Database=your_database;";
        



    }
}
