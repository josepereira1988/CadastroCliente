namespace CadastroCliente.Models
{
	public class EnderecoClienteModal
	{
		public string logadouro { get; set; }
		public string numero { get; set; }
		public string Complemento { get; set; }
		public string CEP { get; set; }
	}
	public class EnderecoClienteAddModal
	{
		public int ClienteId { get; set; }
		public string logadouro { get; set; }
		public string numero { get; set; }
		public string Complemento { get; set; }
		public string CEP { get; set; }
	}
}
