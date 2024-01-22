using System;
using System.ComponentModel.DataAnnotations;

namespace MDEdit.Models;

public class MarkdownModel
{
    [Key]
    public Guid MarkdownId { get; set; }
    public string? Title { get; set; }
    public string Content { get; set; }
    public Guid AuthorId { get; set; }
    public DateTime CreationDateTime { get; set; }
    public Guid LastModifiedUserId { get; set; }
    public DateTime LastModifiedDateTime { get; set; }
    public bool IsPublic { get; set; }
    
    
    // Navigation property to represent the many-to-many relationship
    public ICollection<UserMarkdownModel> UserMarkdowns { get; set; }
}