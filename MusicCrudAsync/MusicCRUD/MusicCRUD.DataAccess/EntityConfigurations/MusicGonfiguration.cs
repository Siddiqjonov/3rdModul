using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicCRUD.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCRUD.DataAccess.EntityConfigurations;

public class MusicGonfiguration : IEntityTypeConfiguration<Music>
{
    public void Configure(EntityTypeBuilder<Music> builder)
    {
        builder.ToTable("Music");

        builder.HasKey(m => m.MusicId);

        builder.Property(m => m.Name).
            IsRequired(true).
            HasMaxLength(50);

        builder.Property(m => m.AuthorName).
            IsRequired(true).
            HasMaxLength(30);

        builder.Property(m => m.Description).
            IsRequired(false).
            HasMaxLength(100);

        builder.HasMany(m => m.Commetns).
            WithOne(c => c.Music).
            HasForeignKey(c => c.MusicId).
            OnDelete(DeleteBehavior.Cascade);
    }
}
