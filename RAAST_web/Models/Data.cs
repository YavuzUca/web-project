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

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Blogpost> Blogpost { get; set; }
        public virtual DbSet<Boat_Info> Boat_Info { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Newsletter> Newsletter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Blogpost)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.asp_user_id);

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
                .HasMany(e => e.Comment)
                .WithOptional(e => e.Blogpost)
                .HasForeignKey(e => e.blogpost_id);

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
        }
    }
}
