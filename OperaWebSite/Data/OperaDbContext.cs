using OperaWebSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OperaWebSite.Data
{
    public class OperaDbContext : DbContext
    {
        public DbSet<Opera> Operas { get; set; }

        public OperaDbContext() : base("KeyDB") { }
    }
}