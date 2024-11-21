using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greenVolt.Dominio
{
    [Table("TAB_AGENDAMENTO")]
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int id_usuario { get; set; }

        [Required]
        public int id_empresa { get; set; }

        [Required(ErrorMessage = "A data de agendamento obrigatória.")]
        [DataType(DataType.DateTime)]
        public DateTime data_agendamento { get; set; }

        [Required(ErrorMessage = "O status obrigatório.")]
        public string status { get; set; }

        public string detalhes { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime criado_em { get; set; } = DateTime.UtcNow;

        // Para usar Entity Framework

        // public Usuario Usuario { get; set; }
        // public Empresa Empresa { get; set; }

        // * * * * * * * * * *  CONSTRUTOR  * * * * * * * * * * //
        private Agendamento() { } // Impedir criação sem validação

        // * * * * * * * * * *  M E T O D O S * * * * * * * * * * //
        public static Agendamento Criar_Agendamento(int idUsuario, int idEmpresa, DateTime dataAgendamento, string status, string detalhes)
        {

            if (idUsuario <= 0)
                throw new ArgumentException("Usuário inválido.");
            if (idEmpresa <= 0)
                throw new ArgumentException("Empresa inválida.");
            ValidarDataAgendamento(dataAgendamento);
            ValidarStatus(status);

            //ValidarDetalhes(detalhes);

            return new Agendamento
            {
                id_usuario = idUsuario,
                id_empresa = idEmpresa,
                data_agendamento = dataAgendamento,
                status = "Pendente",
                detalhes = "detalhes"
            };
        }

        private static void ValidarDataAgendamento(DateTime dataAgendamento)
        {
            if (dataAgendamento < DateTime.UtcNow)
                throw new ArgumentException("A data de agendamento não pode ser no passado.");
        }

        private static void ValidarStatus(string status)
        {
            var statusPermitidos = new[] { "Pendente", "Confirmado", "Cancelado" };
            if (!Array.Exists(statusPermitidos, s => s.Equals(status, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("O status do agendamento é inválido.");
        }

        public void AtualizarStatus(string novoStatus)
        {
            if (string.IsNullOrWhiteSpace(novoStatus))
                throw new ArgumentException("O status não pode ser vazio.");
            status = novoStatus;

        }
    }
}


