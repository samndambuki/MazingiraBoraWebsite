using System.ComponentModel.DataAnnotations;

namespace MazingiraBora.Models{
public class Nominees{

 [Required]
 [MaxLength(50)]
 [Key]
 public string NomineeUserName { get; set; } = string.Empty;

 
 [Required]
 [MaxLength(50)]
 public string FullName { get; set; } = string.Empty;

 [Required]
 [MaxLength(20)]
 public string Email { get; set; } = string.Empty;

}
}