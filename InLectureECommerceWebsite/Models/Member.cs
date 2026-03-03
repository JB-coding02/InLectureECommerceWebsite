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
    public required string Username { get; set; }

    /// <summary>
    /// Email for the member
    /// </summary>
    public required string email { get; set; }

    /// <summary>
    /// The member's password
    /// </summary>
    public required string password { get; set; }

    /// <summary>
    /// The date of birth of the member
    /// </summary>
    public DateOnly DateOfBirth { get; set; }
}
