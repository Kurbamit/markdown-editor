using MDEdit.Models;

namespace MDEdit.Services;

#pragma warning disable IDE1006 // Naming Styles
public interface IEditorIOService
{
    Task SaveMarkdownAsync(string markdownText, string? markdownTitle, Guid userId, Guid markdownId);
    Task<IEnumerable<MarkdownModel>> GetUserMarkdownsAsync(Guid userId);
    Task<(bool success, MarkdownModel markdown)> GetMarkdownByIdAsync(Guid markdownId);
    Task RemoveMarkdownAsync(Guid markdownId, Guid userId);
}
#pragma warning restore IDE1006 // Naming Styles