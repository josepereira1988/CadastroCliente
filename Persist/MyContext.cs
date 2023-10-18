using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persist
{
	public class MyContext : DbContext
	{
		public MyContext(DbContextOptions<MyContext> options,IConfiguration configuration) : base(options)
		{
            _configuration = configuration;
        }
		private IConfiguration _configuration;
		public DbSet<CadastroCliente> Clientes { get; set; }
		public DbSet<EnderecoCliente> Endereco { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionString = _configuration.GetConnectionString("DefaultConnection");
			optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

		}
	}
}
