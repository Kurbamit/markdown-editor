using System.Security.Cryptography.X509Certificates;
using MDEdit.Models;
using Microsoft.EntityFrameworkCore;

namespace MDEdit.Services;

public class EditorIOService : IEditorIOService
{
    private readonly EditorContext _context;
    
    public EditorIOService(EditorContext context)
    {
        _context = context;
    }
    
    public async Task SaveMarkdownAsync(string markdownText, string? markdownTitle, Guid userId, Guid markdownId)
    {
        
        var existingMarkdown = await _context.Markdowns.FindAsync(markdownId);
        Console.WriteLine("Existing markdown: " + existingMarkdown);
        Console.WriteLine("Existing markdown ID: " + markdownId);
        
        if (markdownTitle == null)
        {
            markdownTitle = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        }
        
        if (existingMarkdown != null)
        {
            // Update the existing markdown
            existingMarkdown.Content = markdownText;
            existingMarkdown.Title = markdownTitle;
            existingMarkdown.LastModifiedUserId = userId;
            existingMarkdown.LastModifiedDateTime = DateTime.UtcNow;
            
            _context.Markdowns.Update(existingMarkdown);
            await _context.SaveChangesAsync();
            
            return;
        }

        // Create a new MarkdownModel instance
        var markdownEntity = new MarkdownModel
        {
            MarkdownId = Guid.NewGuid(),
            Title = markdownTitle,
            Content = markdownText,
            AuthorId = userId,
            CreationDateTime = DateTime.UtcNow,
            LastModifiedUserId = userId,
            LastModifiedDateTime = DateTime.UtcNow,
            IsPublic = true, // Adjust this based on your needs
        };

        // Save the MarkdownModel to the database
        _context.Markdowns.Add(markdownEntity);
        await _context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<MarkdownModel>> GetUserMarkdownsAsync(Guid userId)
    {
        // Assuming you have a DbSet<MarkdownModel> named "Markdowns" in your DbContext
        var userMarkdowns = await _context.Markdowns
            .Where(m => m.AuthorId == userId)
            .ToListAsync();

        return userMarkdowns;
    }
    
    public async Task<(bool success, MarkdownModel markdown)> GetMarkdownByIdAsync(Guid markdownId)
    {
        var markdown = await _context.Markdowns.FindAsync(markdownId);

        if (markdown == null)
        {
            return (false, null); // Markdown not found
        }

        return (true, markdown);
    }
}