using System;

namespace MDEdit.Models;

public class UserMarkdownModel
{
    public Guid UserId { get; set; }
    public Guid MarkdownId { get; set; }
    
    // Navigation properties to represent the many-to-many relationship
    public UserModel User { get; set; }
    public MarkdownModel Markdown { get; set; }

    public UserMarkdownModel()
    {
        
    }
}