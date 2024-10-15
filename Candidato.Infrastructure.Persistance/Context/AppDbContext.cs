using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidato.Core.Domain.Entities;

using System.Threading.Tasks;

namespace Candidato.Infrastructure.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Candidatos> Candidatos { get; set; }
        public DbSet<ApiRequestLog> ApiRequestLog { get; set; }
    }
}
