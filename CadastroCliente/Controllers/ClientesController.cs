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
			var entity = _service.Get(cadastro.Id).Result;
			entity.Name = cadastro.Name;
			entity.DataNacimento = cadastro.DataNacimento;
			entity.Email = cadastro.Email;
			entity.Telefone = cadastro.Telefone;
			var deucerto = await _service.Salve(entity);
			if (deucerto != null)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return NoContent();
			}
		}
		[HttpPost]
		public IActionResult cadastro([FromBody] CadastroClienteModal cadastroModal)
		{
			try
			{
				Domain.CadastroCliente cadastro = new Domain.CadastroCliente();
				cadastro.Name = cadastroModal.Name;
				cadastro.Email = cadastroModal.Email;
				cadastro.DataNacimento = cadastroModal.DataNacimento;
				cadastro.Telefone = cadastroModal.Telefone;
				cadastro.Endereco = new List<EnderecoCliente>();
				foreach (var c in cadastroModal.Endereco)
				{
					var endereco = new Domain.EnderecoCliente();
					endereco.logadouro = c.logadouro;
					endereco.CEP = c.CEP;
					endereco.numero = c.numero;
					endereco.Complemento = c.Complemento;
					cadastro.Endereco.Add(endereco);

				}
				var newCadastro = _service.Salve(cadastro).Result;
				if (newCadastro != null)
				{
					return new JsonResult(newCadastro);
				}
				else
				{
					return StatusCode(500, "Erro interno do servidor");
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Erro interno do servidor: " + ex.Message);
			}
		}
		[HttpPost]
		public IActionResult cadastroEndereco([FromBody] EnderecoClienteAddModal cadastroModal)
		{
			try
			{
				var cadastro = _service.Get(cadastroModal.ClienteId).Result;

				var endereco = new Domain.EnderecoCliente();
				endereco.ClienteId = cadastroModal.ClienteId;
				endereco.logadouro = cadastroModal.logadouro;
				endereco.CEP = cadastroModal.CEP;
				endereco.numero = cadastroModal.numero;
				endereco.Complemento = cadastroModal.Complemento;
				cadastro.Endereco.Add(endereco);


				var newCadastro = _service.Salve(cadastro).Result;
				if (newCadastro != null)
				{
					return new JsonResult(newCadastro);
				}
				else
				{
					return StatusCode(500, "Erro interno do servidor");
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Erro interno do servidor: " + ex.Message);
			}
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
		[HttpGet]
		public IActionResult DeletarEndereco(int Id, int IdCadastro)
		{
			var deucerto = _service.DeleteEndereco(Id).Result;
			if (deucerto)
			{

				return RedirectToAction("Editar", new { Id = IdCadastro });
			}
			else
			{
				return NotFound();
			}
		}
	}
}
