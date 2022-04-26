using System.ComponentModel.DataAnnotations;

namespace MazingiraBora.Models{
public class Voter{

 [Required]
 [MaxLength(50)]
 [Key]
 public string VoterUserName { get; set; } = string.Empty;
 
 [Required]
 [MaxLength(50)]
 public string FullName { get; set; } = string.Empty;

 [Required]
 [MaxLength(20)]
 public string Email { get; set; } = string.Empty;

 [Required]
 [MaxLength(20)]

 public string PhoneNumber { get; set; }

 [Required]
 [MaxLength(50)]
 public string NomineeUserName { get; set; } = string.Empty;

}
}