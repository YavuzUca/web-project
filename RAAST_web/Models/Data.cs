using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RAAST_web.Models
{
    public partial class Data : DbContext
    {
        public Data()
            : base("name=Data")
        {
        }

        public virtual DbSet<Blogpost> Blogposts { get; set; }
        public virtual DbSet<Boat_Information> Boat_Information { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Newsletter> Newsletters { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogpost>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Blogpost>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<Blogpost>()
                .Property(e => e.cu_date)
                .IsUnicode(false);

            modelBuilder.Entity<Blogpost>()
                .Property(e => e.slug)
                .IsUnicode(false);

            modelBuilder.Entity<Blogpost>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.Blogpost)
                .HasForeignKey(e => e.blogpost_id);

            modelBuilder.Entity<Boat_Information>()
                .Property(e => e.module_name)
                .IsUnicode(false);

            modelBuilder.Entity<Boat_Information>()
                .Property(e => e.module_value)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.commenter)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .Property(e => e.cu_date)
                .IsUnicode(false);

            modelBuilder.Entity<Newsletter>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.fullName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.passWord_hash)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Blogposts)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.user_id);
        }
    }
}
