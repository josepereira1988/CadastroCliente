using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public interface ICadastroClientePersist
	{
		Task<CadastroCliente> Salve(CadastroCliente cliente);
		Task<CadastroCliente> Get(int Id);
		Task<List<CadastroCliente>> GetAll();
		Task<bool> Delete(int Id);
		Task<bool> DeleteEndereco(int Id);
		
	}
}
