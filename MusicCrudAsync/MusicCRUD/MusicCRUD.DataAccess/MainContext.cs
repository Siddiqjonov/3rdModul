using Microsoft.EntityFrameworkCore;
using MusicCRUD.DataAccess.Entity;
using MusicCRUD.DataAccess.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Music> Music { get; set; } // Connects music entity with tables 
    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserDetail> UsersDetails { get; set; }

    public MainContext(DbContextOptions<MainContext> options) // we can pass connection string through main context
        : base(options)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Which database to use is shown is this method
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;User ID=sa;Password=1;Initial Catalog=MusicCRUD;TrustServerCertificate=True;");
    //    }
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder) // How the entities have to behave is shown in this method
    {
        modelBuilder.ApplyConfiguration(new UserGonfiguration());
        modelBuilder.ApplyConfiguration(new CommentGonfiguration());
        modelBuilder.ApplyConfiguration(new MusicGonfiguration());
        modelBuilder.ApplyConfiguration(new UserDetailGonfiguration());
    }
}
