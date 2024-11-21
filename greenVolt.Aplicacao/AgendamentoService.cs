using greenVolt.Data.Interfaces;
using greenVolt.Data;
using greenVolt.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static greenVolt.Data.Interfaces.IUsuarioRepositorio;

namespace greenVolt.Aplicacao
{
    public class AgendamentoService
    {
        private readonly IAgendamentoRepositorio_Usuario _agendamentoRepositorio;
        private readonly IEmpresaRepositorio _empresaRepositorio;

        public AgendamentoService(IAgendamentoRepositorio_Usuario agendamentoRepositorio, IEmpresaRepositorio empresaRepositorio)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
            _empresaRepositorio = empresaRepositorio;
        }

        public void CriarAgendamento(int idUsuario, int idEmpresa, DateTime dataAgendamento, string status, string detalhes)
        {
            // Valida se a empresa existe
            if (_empresaRepositorio.ObterPorId(idEmpresa) == null)
                throw new ArgumentException("Empresa não encontrada.");

            var agendamento = Agendamento.Criar_Agendamento(idUsuario, idEmpresa, dataAgendamento, status, detalhes);
            _agendamentoRepositorio.Adicionar(agendamento);
        }

        public IEnumerable<Agendamento> ObterAgendamentosPorUsuario(int idUsuario)
        {
            return _agendamentoRepositorio.ObterPorUsuario(idUsuario);
        }

        public Agendamento ObterAgendamentoPorId(int idAgendamento)
        {
            var agendamento = _agendamentoRepositorio.ObterPorId(idAgendamento);
            if (agendamento == null)
                throw new ArgumentException("Agendamento não encontrado.");

            return agendamento;
        }

        public void AtualizarStatus(int idAgendamento, string novoStatus)
        {
            var agendamento = _agendamentoRepositorio.ObterPorId(idAgendamento);
            if (agendamento == null)
                throw new ArgumentException("Agendamento não encontrado.");

            agendamento.AtualizarStatus(novoStatus);
            _agendamentoRepositorio.Atualizar(agendamento);
        }
    }
}
