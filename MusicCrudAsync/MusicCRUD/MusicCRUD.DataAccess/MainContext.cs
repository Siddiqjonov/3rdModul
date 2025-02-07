using Microsoft.EntityFrameworkCore;
using MusicCRUD.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.DataAccess;

public class MainContext : DbContext
{
    //public MainContext(DbContextOptions<MainContext> options) // we can pass connection string through main context
    //    : base(options)
    //{

    //}

    public DbSet<Music> Music { get; set; } // Connercts music entity with tables 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Which database to use is shown is this method
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=MusicCRUD;TrustServerCertificate=True;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) // How the entities have to behave is shown in this method
    {
        base.OnModelCreating(modelBuilder);
    }
}
