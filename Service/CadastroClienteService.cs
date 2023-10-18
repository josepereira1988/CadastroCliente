using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class CadastroClienteService : ICadastroClienteService
	{
		private ICadastroClientePersist _persist;

		public CadastroClienteService(ICadastroClientePersist persist)
		{
			_persist = persist;
		}

		public Task<bool> Delete(int Id)
		{
			return _persist.Delete(Id);		
		}

		public Task<CadastroCliente> Get(int Id)
		{
			return _persist.Get(Id);
		}

		public Task<List<CadastroCliente>> GetAll()
		{
			return _persist.GetAll();
		}

		public Task<CadastroCliente> Salve(CadastroCliente cliente)
		{
			return _persist.Salve(cliente);
		}
	}
}
