using Microsoft.EntityFrameworkCore;

namespace MDEdit.Models;

public class EditorContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<MarkdownModel> Markdowns { get; set; }
    public DbSet<UserMarkdownModel> UserMarkdowns { get; set; }
    
    public EditorContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure many-to-many relationship between User and Markdown
        modelBuilder.Entity<UserMarkdownModel>()
            .HasKey(um => new { um.UserId, um.MarkdownId });

        modelBuilder.Entity<UserMarkdownModel>()
            .HasOne(um => um.User)
            .WithMany(u => u.UserMarkdowns)
            .HasForeignKey(um => um.UserId);

        modelBuilder.Entity<UserMarkdownModel>()
            .HasOne(um => um.Markdown)
            .WithMany(m => m.UserMarkdowns)
            .HasForeignKey(um => um.MarkdownId);
    }
}