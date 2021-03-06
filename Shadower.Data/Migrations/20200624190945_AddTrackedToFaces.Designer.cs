﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shadower.Data;

namespace Shadower.Data.Migrations
{
    [DbContext(typeof(ShadowerDbContext))]
    [Migration("20200624190945_AddTrackedToFaces")]
    partial class AddTrackedToFaces
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shadower.Data.Models.Embedding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FaceId");

                    b.HasKey("Id");

                    b.HasIndex("FaceId");

                    b.ToTable("Embeddings");
                });

            modelBuilder.Entity("Shadower.Data.Models.EmbeddingValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmbeddingId");

                    b.Property<int>("Index");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("EmbeddingId");

                    b.ToTable("EmbeddingValues");
                });

            modelBuilder.Entity("Shadower.Data.Models.Face", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Tracked");

                    b.HasKey("Id");

                    b.ToTable("Faces");
                });

            modelBuilder.Entity("Shadower.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Link")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Shadower.Data.Models.PostFace", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("FaceId");

                    b.HasKey("PostId", "FaceId");

                    b.HasIndex("FaceId");

                    b.ToTable("PostFaces");
                });

            modelBuilder.Entity("Shadower.Data.Models.Embedding", b =>
                {
                    b.HasOne("Shadower.Data.Models.Face", "Face")
                        .WithMany("Embeddings")
                        .HasForeignKey("FaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shadower.Data.Models.EmbeddingValue", b =>
                {
                    b.HasOne("Shadower.Data.Models.Embedding")
                        .WithMany("Values")
                        .HasForeignKey("EmbeddingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shadower.Data.Models.PostFace", b =>
                {
                    b.HasOne("Shadower.Data.Models.Face", "Face")
                        .WithMany("Posts")
                        .HasForeignKey("FaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shadower.Data.Models.Post", "Post")
                        .WithMany("Faces")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
