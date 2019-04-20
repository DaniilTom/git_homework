using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain;
using WebStore.Domain.Implementations;

namespace WebStore.DAL.Context
{
    public class WebStoreContext : IdentityDbContext<User>
    {
        public DbSet<Microcontroller> Microcontrollers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MCDescription> MCDescriptions { get; set; }

        public WebStoreContext(DbContextOptions<WebStoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<MCDescription>(new MCDescription.MCDescriptionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
