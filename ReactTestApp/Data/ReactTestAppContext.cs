using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ReactTestApp.Models
{
    public class ReactTestAppContext : DbContext
    {
        public ReactTestAppContext (DbContextOptions<ReactTestAppContext> options)
            : base(options)
        {
        }

        public DbSet<ReactTestApp.Models.ToDo> ToDo { get; set; }
    }
}
