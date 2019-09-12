using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treino.Models;

namespace Treino.Persistences
{
    public class BancoContext : DbContext
    {
        public DbSet<Condominio> Condominios { get; set; }

        public BancoContext(DbContextOptions o) : base(o)
        {

        }
    }
}
