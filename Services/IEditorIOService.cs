using MDEdit.Models;

namespace MDEdit.Services;

public interface IEditorIOService
{
    public Task<MarkdownModel> SaveMarkdownAsync(string markdownText, string? markdownTitle, Guid userId);
}