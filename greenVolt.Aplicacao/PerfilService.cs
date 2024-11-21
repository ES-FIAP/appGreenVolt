using greenVolt.Data.Interfaces;
using greenVolt.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static greenVolt.Data.Interfaces.IUsuarioRepositorio;

namespace greenVolt.Aplicacao
{
    public class PerfilService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IEnderecoRepositorio_Usuario _enderecoRepositorio;
        private readonly IAgendamentoRepositorio_Usuario _agendamentoRepositorio;

        public PerfilService(
            IUsuarioRepositorio usuarioRepositorio,
            IEnderecoRepositorio_Usuario enderecoRepositorio,
            IAgendamentoRepositorio_Usuario agendamentoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
            _agendamentoRepositorio = agendamentoRepositorio;
        }

        public Usuario ObterPerfil(int idUsuario)
        {
            return _usuarioRepositorio.ObterPorId(idUsuario);
        }

        public Endereco ObterEndereco(int idUsuario)
        {
            return _enderecoRepositorio.ObterPorUsuario(idUsuario);
        }

        // agendamento ***** observação: talvez não usar // 
        public Agendamento ObterUltimoAgendamento(int idUsuario)
        {
            return _agendamentoRepositorio.ObterMaisRecentePorUsuario(idUsuario);
        }

        public void AtualizarPerfil(int idUsuario, string nome, string email)
        {
            var usuario = _usuarioRepositorio.ObterPorId(idUsuario);
            if (usuario == null)
                throw new InvalidOperationException("Usuário não encontrado.");

            usuario.AtualizarDados(nome, email);
            _usuarioRepositorio.Atualizar(usuario);
        }

        public void AtualizarEndereco(int idUsuario, string logradouro, string cidade, string estado, string cep)
        {
            var endereco = _enderecoRepositorio.ObterPorUsuario(idUsuario);
            if (endereco == null)
                throw new InvalidOperationException("Endereço não encontrado.");

            endereco.AtualizarEndereco(logradouro, cidade, estado, cep);
            _enderecoRepositorio.Atualizar(endereco);
        }
    }
}
