using Aula_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula_3.Data
{
	public class DBInitializer
	{
		private Aula_3Context _context;

		public DBInitializer(Aula_3Context context)
		{
			_context = context;
		}

		public void Run()
		{
			

			_context.Database.EnsureCreated();

			if (_context.Category.Any())
			{
				_context.Category.ExecuteDelete();
			}

			var categorias = new Category[]
			{
				new Category { Name = "Programming", Description = "Algorithms and programming courses", Date=DateTime.Now },
				new Category { Name = "Administration", Description = "Public administration and business management courses",Date=DateTime.Now },
				new Category { Name = "Communication", Description = "Business and institutional communication courses", Date=DateTime.Now }
			};

			
			_context.Category.AddRange(categorias);
			_context.SaveChanges();
		}
	}
}
