using System.ComponentModel.DataAnnotations;

namespace MDEdit.Models;

public class UserMarkdownModel
{
    [Key]
    public Guid UserId { get; set; }
    [Key]
    public Guid MarkdownId { get; set; }
    
    // Navigation properties to represent the many-to-many relationship
    public UserModel User { get; set; }
    public MarkdownModel Markdown { get; set; }

    public UserMarkdownModel()
    {
        UserId = Guid.NewGuid();
        MarkdownId = Guid.NewGuid();
    }
}