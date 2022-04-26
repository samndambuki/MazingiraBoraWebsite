using System.ComponentModel.DataAnnotations;
namespace MazingiraBora.Models{
public class Login{

 [Required]
 [MaxLength(50)]
 [Key]
 public string UserName { get; set; } = string.Empty;

 public string Email {get;set;} = string.Empty;

 [Required]
 [MaxLength(20)]
 public string Password {get;set;} = string.Empty;
}
}