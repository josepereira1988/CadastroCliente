using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persist
{
	public class CadastroClientePersist : ICadastroClientePersist
	{
		private MyContext _context;

		public CadastroClientePersist(MyContext context)
		{
			_context = context;
		}

		public async Task<bool> Delete(int Id)
		{
			try
			{
				if (existe(Id))
				{
					_context.Remove(await _context.Clientes.Where(c => c.Id == Id).FirstOrDefaultAsync());
					await _context.SaveChangesAsync();
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		public async Task<bool> DeleteEndereco(int Id)
		{
			try
			{
				if (existeendereco(Id))
				{
					_context.Remove(await _context.Endereco.Where(c => c.Id == Id).FirstOrDefaultAsync());
					await _context.SaveChangesAsync();
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		public async Task<CadastroCliente> Get(int Id)
		{
			CadastroCliente cliente = await _context.Clientes.Include(e =>e.Endereco).Where(c => c.Id == Id).FirstOrDefaultAsync();
			if (cliente == null)
			{
				throw new Exception("Cliente não encontrado");
			}
			return cliente;
		}

		public async Task<List<CadastroCliente>> GetAll()
		{
			return _context.Clientes.ToList();
		}

		public async Task<CadastroCliente> Salve(CadastroCliente cliente)
		{
			try
			{
				if (cliente.Id > 0)
				{
					if (existe(cliente.Id))
					{
						var entity = await _context.Clientes.Include(e => e.Endereco).Where(c => c.Id == cliente.Id).FirstOrDefaultAsync();
						_context.Update(cliente);
						foreach(var item in entity.Endereco)
						{
							if(item.Id == cliente.Endereco.Where(e => e.Id == item.Id).FirstOrDefault().Id)
							{
								_context.Update(item);
							}
							else
							{
								_context.Remove(item);
							}
						}
					}
					else
					{
						throw new Exception("Cliente não encontrado");
					}
				}
				else
				{
					_context.Add(cliente);
					//foreach(var gravar in cliente.Endereco)
					//{
					//	_context.Add(gravar);
					//}
				}
				await _context.SaveChangesAsync();
				return cliente;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		private bool existe(int id)
		{
			return _context.Clientes.Any(e => e.Id == id);
		}
		private bool existeendereco(int id)
		{
			return _context.Endereco.Any(e => e.Id == id);
		}
	}
}
