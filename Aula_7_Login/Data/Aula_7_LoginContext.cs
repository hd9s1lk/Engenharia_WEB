using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula_7_Login.Models;

namespace Aula_7_Login.Data
{
    public class Aula_7_LoginContext : DbContext
    {
        public Aula_7_LoginContext (DbContextOptions<Aula_7_LoginContext> options)
            : base(options)
        {
        }

        public DbSet<Aula_7_Login.Models.User> User { get; set; } = default!;
    }
}
