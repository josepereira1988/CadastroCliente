using Microsoft.AspNetCore.Mvc;
using Domain;
using CadastroCliente.Models;

namespace CadastroCliente.Controllers
{
	public class ClientesController : Controller
	{
		private ICadastroClienteService _service;

		public ClientesController(ICadastroClienteService service)
		{
			_service = service;
		}
		public async Task<IActionResult> Index()
		{
			
			return View(await _service.GetAll());
		}
		public async Task<IActionResult> Editar(int Id)
		{
			return View(await _service.Get(Id));
		}
		[HttpPost]
		public async Task<IActionResult> Editar(Domain.CadastroCliente cadastro)
		{
			return View();
		}
		[HttpPost]
		public IActionResult cadastro([FromBody] CadastroClienteModal cadastroModal)
		{
			Domain.CadastroCliente cadastro = new Domain.CadastroCliente();
			cadastro.Name = cadastroModal.Name;
			cadastro.Email = cadastroModal.Email;
			cadastro.DataNacimento = cadastroModal.DataNacimento;
			cadastro.Telefone = cadastroModal.Telefone;
			foreach(var c in cadastroModal.Endereco)
			{
				var endereco = new Domain.EnderecoCliente();
				endereco.logadouro = c.logadouro;
				endereco.CEP = c.CEP;
				endereco.numero = c.numero;
				
			}
			var newCadastro = _service.Salve(cadastro).Result;
			return CreatedAtAction(nameof(Index), new { id = newCadastro.Id }, newCadastro);
		}
		[HttpGet]
		public IActionResult Deletar(int Id)
		{
			var deucerto = _service.Delete(Id).Result;
			if (deucerto)
			{

			return RedirectToAction("Index");
			}
			else
			{
				return NotFound();
			}
		}
	}
}
