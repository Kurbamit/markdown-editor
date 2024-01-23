using MDEdit.Models;

namespace MDEdit.Services;

public interface IEditorIOService
{
    Task SaveMarkdownAsync(string markdownText, string? markdownTitle, Guid userId, Guid markdownId);
    Task<IEnumerable<MarkdownModel>> GetUserMarkdownsAsync(Guid userId);
    Task<(bool success, MarkdownModel markdown)> GetMarkdownByIdAsync(Guid markdownId);
}