using System.Security.Cryptography;
using System.Text;

namespace MDEdit.Models;

public class UserModel
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    
    // Navigation property to represent the many-to-many relationship
    public ICollection<UserMarkdownModel> UserMarkdowns { get; set; }

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
        using (var rng = new RNGCryptoServiceProvider())
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

    public void ToString()
    {
        Console.WriteLine("User ID: " + UserId);
        Console.WriteLine("Username: " + Username);
        Console.WriteLine("Email: " + Email);
        Console.WriteLine("Hashed Password: " + PasswordHash);
        Console.WriteLine("Generated Salt: " + Salt);
        Console.WriteLine();
    }
}