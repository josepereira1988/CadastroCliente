using Domain;

namespace CadastroCliente.Models
{
	public class CadastroClienteModal
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DataNacimento { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
		public List<EnderecoClienteModal> Endereco { get; set; }
	}
}
