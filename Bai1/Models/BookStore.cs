using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Bai1.Models
{
    public partial class BookStore : DbContext
    {
        public BookStore()
            : base("name=BookStore")
        {
        }

        public virtual DbSet<Tintuc> Tintuc { get; set; }
        public virtual DbSet<Theloaitin> Theloaitin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theloaitin>()
                .HasMany(e => e.Tintuc)
                .WithRequired(e => e.Theloaitin)
                .WillCascadeOnDelete(false);
        }
    }
}
