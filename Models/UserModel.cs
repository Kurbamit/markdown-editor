using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace MDEdit.Models;

public class UserModel
{
    [Key]
    public Guid UserId { get; set; }
    
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(30, ErrorMessage = "Email must be less than 30 characters.")]
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }

    // Navigation property to represent the many-to-many relationship
    public ICollection<UserMarkdownModel>? UserMarkdowns { get; set; }

    public UserModel()
    {
        
    }
    
    public UserModel(string username, string email, string password)
    {
        UserId = Guid.NewGuid();
        Username = username;
        Email = email;
        Salt = GenerateSalt();
        PasswordHash = SetPassword(password);
    }

    private string GenerateSalt()
    {
        var saltBytes = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        Salt = Convert.ToBase64String(saltBytes);

        return Salt;
    }

    private string SetPassword(string password)
    {
        // Combine the password and salt, then hash
        using var sha256 = SHA256.Create();
        var combinedBytes = Encoding.UTF8.GetBytes(password + Salt);
        var hashBytes = sha256.ComputeHash(combinedBytes);
        var passwordHash = Convert.ToBase64String(hashBytes);

        return passwordHash;
    }

    public override string ToString()
    {
        return $"User ID: {UserId}\nUsername: {Username}\nEmail: {Email}\nHashed Password: {PasswordHash}\nGenerated Salt: {Salt}\n";
    }
}