using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace greenVolt.Dominio
{
    [Table("TAB_EMPRESAS")] 

    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public int id_empresa { get; set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório.")]
        public string nome_empresa { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        //Criar validação de CNPJ //
        public string cnpj { get; set; }

        public string descricao { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public string categoria { get; set; }

        public string contato { get; set; }

        [DataType(DataType.Date)]
        public DateTime criado_em { get; set; } = DateTime.UtcNow;

        [StringLength(100, ErrorMessage = "O tipo de origem de energia não pode exceder 100 caracteres.")]
        public string origem_energia { get; set; }

        public double valor { get; set; }



        public static void ValidarCnpj(string cnpj)
        {
            // Aqui você pode implementar a validação de CNPJ.
            if (string.IsNullOrWhiteSpace(cnpj))
                throw new ArgumentException("O CNPJ é obrigatório.");

            if (cnpj.Length != 14)
                throw new ArgumentException("O CNPJ deve conter 14 dígitos.");
        }

        public static Empresa Criar_Empresa(string nome, string cnpj, string contato, string descricao, string categoria, string origem_energia, double valor)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da empresa é obrigatório.");

            ValidarCnpj(cnpj);

            return new Empresa
            {
                nome_empresa = nome,
                cnpj = cnpj,
                contato = contato,
                descricao = descricao,
                categoria = categoria,
                origem_energia = origem_energia,
                valor = valor

            };
        }
    }

}

