using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

/// <summary>
/// Represents an individual website user.
/// </summary>
public class Member
{
    /// <summary>
    /// Unique identifier for the member
    /// </summary>
    [Key]
    public int MemberId { get; set; }

    /// <summary>
    /// Public facing Username of the member
    /// Alphanumeric characters only
    /// </summary>
    [RegularExpression("^[a-zA-Z0-9]+$",
        ErrorMessage = "Username must be alphanumeric only.")]
    [StringLength(25)]
    public required string Username { get; set; }

    /// <summary>
    /// Email for the member
    /// </summary>
    
    public required string Email { get; set; }

    /// <summary>
    /// The member's password
    /// </summary>
    [StringLength(50, MinimumLength = 6,
        ErrorMessage = "Your password must be between 6 and 50 characters")]
    public required string password { get; set; }

    /// <summary>
    /// The date of birth of the member
    /// </summary>
    
    public DateOnly DateOfBirth { get; set; }
}
