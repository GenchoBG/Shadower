using Microsoft.EntityFrameworkCore;
using Shadower.Data.Models;

namespace Shadower.Data
{
    public class ShadowerDbContext : DbContext
    {
        public DbSet<Face> Faces { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostFace> PostFaces { get; set; }

        public DbSet<Embedding> Embeddings { get; set; }

        public DbSet<EmbeddingValue> EmbeddingValues { get; set; }

        public ShadowerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<PostFace>()
                .HasKey(pf => new {pf.PostId, pf.FaceId});

            modelBuilder.Entity<Face>()
                .HasMany(f => f.Posts)
                .WithOne(pf => pf.Face)
                .HasForeignKey(pf => pf.FaceId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Faces)
                .WithOne(pf => pf.Post)
                .HasForeignKey(pf => pf.PostId);

            modelBuilder.Entity<Embedding>()
                .HasOne(e => e.Face)
                .WithMany(f => f.Embeddings)
                .HasForeignKey(e => e.FaceId);

            modelBuilder.Entity<Embedding>()
                .HasMany(e => e.Values)
                .WithOne()
                .HasForeignKey(ev => ev.EmbeddingId);
        }
    }
}
