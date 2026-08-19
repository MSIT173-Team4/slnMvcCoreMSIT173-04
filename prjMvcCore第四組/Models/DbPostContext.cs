using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prjMvcCore第四組.Models;

public partial class DbPostContext : DbContext
{
    public DbPostContext(){

    }
    public DbPostContext(DbContextOptions<DbPostContext> options)
            : base(options)
    {
    }
    public DbSet<TUser> TUsers { get; set; } = null!;
    public DbSet<TPostTable> TPostTables { get; set; } = null!;
    public DbSet<TMessageTable> TMessageTables { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=midprjDb2;Integrated Security=True;Encrypt=False");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TUser>(entity =>
        {
            entity.ToTable("tUser");
            entity.HasKey(e => e.FId);
            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FUsername).HasColumnName("fUsername");
            entity.Property(e => e.FNickname).HasColumnName("fNickname");
        });
        modelBuilder.Entity<TPostTable>(entity =>
        {
            entity.ToTable("tPostTable");
            entity.HasKey(e => e.FPostId);
            entity.Property(e => e.FPostId).HasColumnName("fPostID");
            entity.Property(e => e.FUserId).HasColumnName("fUser_Id");
            entity.Property(e => e.FTitle).HasColumnName("fTitle");
            entity.Property(e => e.FPostContent).HasColumnName("fPostContent");
            entity.Property(e => e.FLikes).HasColumnName("fLikes");
            entity.Property(e => e.FViews).HasColumnName("fViews");
            entity.Property(e => e.FPostDate).HasColumnName("fPostDate");
            entity.Property(e => e.FPostState).HasColumnName("fPostState");

            entity.HasOne(d => d.FUser)
                .WithMany()
                .HasForeignKey(d => d.FUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<TMessageTable>(entity =>
        {
            entity.ToTable("tMessageTable");
            entity.HasKey(e => e.FMessageId);
            entity.Property(e => e.FMessageId).HasColumnName("fMessageID");
            entity.Property(e => e.FPostId).HasColumnName("fPostID");
            entity.Property(e => e.FUserId).HasColumnName("fUser_Id");
            entity.Property(e => e.FReplyMessageId).HasColumnName("fReplyMessageID");
            entity.Property(e => e.FMessageContent).HasColumnName("fMessageContent");
            entity.Property(e => e.FLikes).HasColumnName("fLikes");
            entity.Property(e => e.FMessageDate).HasColumnName("fMessageDate");
            entity.Property(e => e.FMessageState).HasColumnName("fMessageState");

            entity.HasOne(d => d.FPost)
                .WithMany(p => p.TMessageTables)
                .HasForeignKey(d => d.FPostId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.FUser)
                .WithMany()
                .HasForeignKey(d => d.FUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }
}