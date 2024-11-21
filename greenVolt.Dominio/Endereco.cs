using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;
using Swashbuckle.AspNetCore.Annotations;

namespace greenVolt.Dominio
{

    [Table("TAB_ENDERECO")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public int id { get; set; }

        [Required]
        public int id_usuario { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        public string logradouro { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        public string estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(20, ErrorMessage = "O CEP não pode exceder 20 caracteres.")]
        public string cep { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime criado_em { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTime atualizado_em { get; set; } = DateTime.UtcNow;



        public void AtualizarEndereco(string logradouro, string cidade, string estado, string cep)
        {

            if (string.IsNullOrWhiteSpace(cidade))
                throw new ArgumentException("Cidade não pode ser vazia.");
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("Estado não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(cep))
                throw new ArgumentException("CEP não pode ser vazio.");

            logradouro = logradouro;
            cidade = cidade;
            estado = estado;
            cep = cep;
            atualizado_em = DateTime.UtcNow;
        }
    }
}

