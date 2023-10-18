using Domain;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
	public class EnderecoCliente
	{
		public int Id { get; set; }

		public int ClienteId { get; set; }

		[Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
		[StringLength(100, ErrorMessage = "O campo Logradouro deve ter no máximo 100 caracteres.")]
		public string logadouro { get; set; }
		[StringLength(100, ErrorMessage = "O campo Complemento deve ter no máximo 100 caracteres.")]
		public string Complemento { get; set; }

		[Required(ErrorMessage = "O campo Número é obrigatório.")]
		[RegularExpression(@"^\d{1,5}$", ErrorMessage = "Número de rua inválido.")]
		public string numero { get; set; }

		[Required(ErrorMessage = "O campo CEP é obrigatório.")]
		[RegularExpression(@"^\d{8}$", ErrorMessage = "Formato de CEP inválido.")]
		public string CEP { get; set; }

		public CadastroCliente Cliente { get; set; }
	}
}
