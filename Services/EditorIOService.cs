using MDEdit.Models;

namespace MDEdit.Services;

public class EditorIOService : IEditorIOService
{
    private readonly EditorContext _context;
    
    public EditorIOService(EditorContext context)
    {
        _context = context;
    }
    
    public async Task<MarkdownModel> SaveMarkdownAsync(string markdownText, string? markdownTitle, Guid userId)
    {
        if (markdownTitle == null)
        {
            markdownTitle = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
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

        return markdownEntity;
    }
}