using Microsoft.EntityFrameworkCore;
using SistemaLembretes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLembretes
{
    public class LembreteDbContext : DbContext
    {
        public LembreteDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Lembrete> Lembretes { get; set; }
    }
}
