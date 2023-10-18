using Microsoft.EntityFrameworkCore;
using Persist;

namespace CadastroCliente
{
	public class DatabaseInitializer
	{
		public static void InitializeDatabase(IApplicationBuilder app)
		{
			try
			{
				using (var serviceScope = app.ApplicationServices.CreateScope())
				{
					var context = serviceScope.ServiceProvider.GetRequiredService<MyContext>();
					context.Database.Migrate();
				}
			}
			catch (Exception)
			{


			}
		}
	}
}
