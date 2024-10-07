using Aula_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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


			var courses = new Course[]
			{
				new Course
				{
					Name="Web Enginner",
					Description="Creating new sites with ASP.NET",
					Cost=50, Credits=6,
					CategoryId=categorias.Single(c=>c.Name=="Programming").Id
				},
				new Course
				{
                    Name="Strategic Leadership and Management",
                    Description="Leadership and Business Skill for immediate Impact",
                    Cost=100, Credits=6,
                    CategoryId=categorias.Single(c=>c.Name=="Administration").Id
                },
				new Course {
                    Name="Master in Corporate Communication",
                    Description="This master is bery god",
                    Cost=80, Credits=10,
                    CategoryId=categorias.Single(c=>c.Name=="Communication").Id
                }

			};

			_context.Course.AddRange(courses);
			_context.SaveChanges();


		}
	}
}
