using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public interface ICadastroClienteService
	{
		Task<CadastroCliente> Salve(CadastroCliente cliente);
		Task<CadastroCliente> Get(int Id);
		Task<List<CadastroCliente>> GetAll();
		Task<bool> Delete(int Id);
	}
}
