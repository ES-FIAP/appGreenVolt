using greenVolt.Data.Interfaces;
using greenVolt.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static greenVolt.Data.Interfaces.IUsuarioRepositorio;

namespace greenVolt.Data
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly GreenVoltDbContext _context;

        public UsuarioRepositorio(GreenVoltDbContext context)
        {
            _context = context;
        }
        
        public Usuario ObterPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario); 
            _context.SaveChanges();         
        }

        public bool ExisteEmail(string email)
        {
            return _context.Usuarios.Any(u => u.Email == email);
        }

        public Usuario ObterPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var usuario = ObterPorId(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }
    }

    // ENDEREÇO //
    public class EnderecoRepositorio : IEnderecoRepositorio_Usuario
    {
        private readonly GreenVoltDbContext _context;

        public EnderecoRepositorio(GreenVoltDbContext context)
        {
            _context = context;
        }

        public Endereco ObterPorUsuario(int idUsuario)
        {
            return _context.Enderecos.FirstOrDefault(e => e.IdUsuario == idUsuario);
        }

        public void Atualizar(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            _context.SaveChanges();
        }
    }


    // AGENDAMENTO //
    public class AgendamentoRepositorio : IAgendamentoRepositorio_Usuario
    {
        private readonly GreenVoltDbContext _context;

        public AgendamentoRepositorio(GreenVoltDbContext context)
        {
            _context = context;
        }

        public Agendamento ObterMaisRecentePorUsuario(int idUsuario)
        {
            return _context.Agendamentos
                .Where(a => a.IdUsuario == idUsuario)
                .OrderByDescending(a => a.DataAgendamento)
                .FirstOrDefault();
        }

        public void Adicionar(Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();
        }

        public void Atualizar(Agendamento agendamento)
        {
            _context.Agendamentos.Update(agendamento);
            _context.SaveChanges();
        }

        public Agendamento ObterPorId(int idAgendamento)
        {
            return _context.Agendamentos.FirstOrDefault(a => a.IdAgendamento == idAgendamento);
        }

        public IEnumerable<Agendamento> ObterPorUsuario(int idUsuario)
        {
            return _context.Agendamentos.Where(a => a.IdUsuario == idUsuario).ToList();
        }

    }

}
