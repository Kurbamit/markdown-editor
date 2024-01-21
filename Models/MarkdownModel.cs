using System;

namespace MDEdit.Models;

public class MarkdownModel
{
    public Guid MarkdownId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    
    // Navigation property to represent the many-to-many relationship
    public ICollection<UserMarkdownModel> UserMarkdowns { get; set; }
}