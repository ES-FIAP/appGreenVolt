using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Swashbuckle.AspNetCore.Annotations;

namespace greenVolt.Dominio
{
    [Table("tab_usuario")] 
    public class Usuario
    {
        [SwaggerSchema(ReadOnly = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve estar em um formato válido.")]
        public string email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string senha_hash { get; set; }

        public string id_google { get; set; }

        [DataType(DataType.Date)]
        public DateTime criado_em { get; set; } = DateTime.UtcNow;


        //public string ImagemPerfil { get; private set; }


        // * * * * * * * * * *  CONSTRUTOR  * * * * * * * * * * //
        private Usuario() { }   

        // * * * * * * * * * *  M E T O D O S * * * * * * * * * * //
        public static Usuario CriarUsuario(string nome, string email, string senha)
        {
            ValidarNome(nome);
            ValidarEmail(email);
            ValidarSenha(senha);
    
            return new Usuario
            {
                nome = nome,
                email = email,
                senha_hash = GerarHashSenha(senha),
            };
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome obrigatório.");
        }

        private static void ValidarEmail(string email)
        {

            // Validação de formato de e-mail - GPT
            var emailRegex = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
            if (!emailRegex.IsMatch(email))
                throw new ArgumentException("O e-mail não é válido.");
        }

        private static void ValidarSenha(string senha)
        {
            if (senha.Length < 8)
                throw new ArgumentException("A senha deve ter no mínimo 8 caracteres.");

            // Exemplo de validação de complexidade 
            if (!Regex.IsMatch(senha, @"[A-Z]"))
                throw new ArgumentException("A senha deve conter pelo menos uma letra maiúscula.");

            if (!Regex.IsMatch(senha, @"[a-z]"))
                throw new ArgumentException("A senha deve conter pelo menos uma letra minúscula.");

            if (!Regex.IsMatch(senha, @"\d"))
                throw new ArgumentException("A senha deve conter pelo menos um número.");

            if (!Regex.IsMatch(senha, @"[\W_]"))
                throw new ArgumentException("A senha deve conter pelo menos um caractere especial.");
        }
        private static string GerarHashSenha(string senha) 
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(senha));
        }

        public void AtualizarDados(string nome, string email, string imagemPerfil = null)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O email não pode ser vazio.");

            nome = nome;
            email = email;

            //if (!string.IsNullOrWhiteSpace(imagemPerfil))
            //    ImagemPerfil = imagemPerfil;
        }

        public void AtualizarSenha(string novaSenha)
        {
            if (string.IsNullOrWhiteSpace(novaSenha))
                throw new ArgumentException("A senha não pode ser vazia.");

            senha_hash = GerarHashSenha(novaSenha);
        }


    }


}



