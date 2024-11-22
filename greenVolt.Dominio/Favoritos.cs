using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace greenVolt.Dominio
{
    public  class Favoritos
    {
        [Table("tab_favorito")] 
        public class Favorito
        {
            [SwaggerSchema(ReadOnly = true)]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
            public int id { get; set; }

            [Required]
            public int IdUsuario { get; set; } 

            [Required]
            public int IdEmpresa { get; set; } 

            [DataType(DataType.DateTime)]
            public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

            //  Entity
            // public Usuario Usuario { get; set; }
            // public Empresa Empresa { get; set; }

            // * * * * * * * * * *  CONSTRUTOR  * * * * * * * * * * //
            private Favorito() { }

            // * * * * * * * * * *  M E T O D O S * * * * * * * * * * //
            public static Favorito Criar(int idUsuario, int idEmpresa)
            {
                if (idUsuario <= 0)
                    throw new ArgumentException("O ID do usuário é inválido.");

                if (idEmpresa <= 0)
                    throw new ArgumentException("O ID da empresa é inválido.");

                return new Favorito
                {
                    IdUsuario = idUsuario,
                    IdEmpresa = idEmpresa
                };
            }
        }
    }
    
}
