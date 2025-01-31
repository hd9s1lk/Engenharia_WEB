using Estudo_Aula3.Models;

namespace Estudo_Aula3.Data
{
    public class DBInitializer
    {
        private Estudo_Aula3Context _context;

        public DBInitializer(Estudo_Aula3Context context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureCreated();

            if (_context.Category.Any())
            {
                return;
            }

            var categorias = new Category[]
            {
                new Category{Name = "Boas", Description= "CS"}
            };

            _context.Category.AddRange(categorias);
            _context.SaveChanges();

        }


    }
}
