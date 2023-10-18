using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{


	public class CadastroCliente
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo Name é obrigatório.")]
		[StringLength(100, ErrorMessage = "O campo Name deve ter no máximo 100 caracteres.")]
		public string Name { get; set; }

		[Display(Name = "Data de Nascimento")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DataNacimento { get; set; }

		[RegularExpression(@"^\d{10,11}$", ErrorMessage = "Número de telefone inválido.")]
		public string Telefone { get; set; }

		[Required(ErrorMessage = "O campo Email é obrigatório.")]
		[EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
		public string Email { get; set; }

		public List<EnderecoCliente> Endereco { get; set; }
	}

}

