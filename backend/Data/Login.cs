using System.ComponentModel.DataAnnotations;

public class Login{

 [Required]
 [MaxLength(20)]
 [Key]
 public string Email {get;set;} = string.Empty;

 [Required]
 [MaxLength(20)]
 public string Password {get;set;} = string.Empty;

}