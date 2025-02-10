﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicCRUD.DataAccess;

#nullable disable

namespace MusicCRUD.DataAccess.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20250207071628_TablesAdded")]
    partial class TablesAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicCRUD.DataAccess.Entity.Comment", b =>
                {
                    b.Property<long>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CommentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CtreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("MusicId")
                        .HasColumnType("bigint");

                    b.HasKey("CommentId");

                    b.HasIndex("MusicId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("MusicCRUD.DataAccess.Entity.Music", b =>
                {
                    b.Property<long>("MusicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MusicId"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MB")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuentityLikes")
                        .HasColumnType("int");

                    b.HasKey("MusicId");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("MusicCRUD.DataAccess.Entity.Comment", b =>
                {
                    b.HasOne("MusicCRUD.DataAccess.Entity.Music", "Music")
                        .WithMany("Commetns")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Music");
                });

            modelBuilder.Entity("MusicCRUD.DataAccess.Entity.Music", b =>
                {
                    b.Navigation("Commetns");
                });
#pragma warning restore 612, 618
        }
    }
}
