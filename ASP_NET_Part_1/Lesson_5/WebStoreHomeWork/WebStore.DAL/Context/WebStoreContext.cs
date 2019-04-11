using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Implementations;

namespace WebStore.DAL.Context
{
    class WebStoreContext : DbContext
    {
        public DbSet<Microcontroller> Microcontrollers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MCDescription> MCDescriptions { get; set; }

        public WebStoreContext(DbContextOptions<WebStoreContext> options) : base(options) { }
    }
}
