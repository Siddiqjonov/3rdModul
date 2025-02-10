using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCRUD.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.DataAccess.EntityConfigurations;

public class UserGonfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(u => u.UserId);

        builder.Property(u => u.UserName).
            IsRequired(true).
            HasMaxLength(30);

        builder.Property(u => u.FirstName).
            IsRequired(true).
            HasMaxLength(30);

        builder.Property(u => u.LastName).
            IsRequired(false).
            HasMaxLength(30);

        builder.Property(u => u.Email).
            IsRequired(true).
            HasMaxLength(254);

        builder.Property(u => u.Password).
            IsRequired(true).
            HasMaxLength(30);

        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.UserName).IsUnique();

        builder.HasOne(u => u.UserDetail).
            WithOne(uD => uD.User).
            HasForeignKey<UserDetail>(uD => uD.UserId);
    }
}
