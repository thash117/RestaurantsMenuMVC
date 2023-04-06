using Menu_System.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Menu_System
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options)
        {

        }

        public DbSet<MenuItem> MenuItems { get; set; }

       
    }
}
