using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using greenVolt.Dominio;

namespace greenVolt.Data.Interfaces
{

    // Interface para o repositório de usuários
    public interface IUsuarioRepositorio
    {
        Usuario ObterPorEmail(string email);  // Busca um usuário pelo e-mail
        void Adicionar(Usuario usuario); // Adiciona um novo usuário
        bool ExisteEmail(string email); // Verifica se o e-mail já está cadastrado

        Usuario ObterPorId(int id); // Buscar usuário por ID
        void Remover(int id);  // Remover um usuário pelo ID

        void Atualizar(Usuario usuario); // Atualizar informações do usuário




        // Interface para o repositório de endereços
        public interface IEnderecoRepositorio_Usuario
        {
            Endereco ObterPorUsuario(int idUsuario);
            void Atualizar(Endereco endereco);
        }


        // Interface para o repositório de agendamentos
        public interface IAgendamentoRepositorio_Usuario
        {
            Agendamento ObterMaisRecentePorUsuario(int idUsuario);

            void Adicionar(Agendamento agendamento);
            void Atualizar(Agendamento agendamento);
            Agendamento ObterPorId(int idAgendamento);
            IEnumerable<Agendamento> ObterPorUsuario(int idUsuario);
        }
            
        



    }
}
