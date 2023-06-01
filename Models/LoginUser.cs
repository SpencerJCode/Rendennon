#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Rendennon.Models;
public class LoginUser
{
    [Key]
    public int LoginUserId { get; set; }
    [EmailAddress]
    [Required(ErrorMessage = "is required.")]
    public string LoginEmail {get;set;}
    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    public string LoginPassword {get;set;}
    
    // public DateTime CreatedAt { get; set; } = DateTime.Now;
    // public DateTime UpdatedAt { get; set; } = DateTime.Now;
}