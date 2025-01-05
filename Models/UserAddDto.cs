using System;
using System.ComponentModel.DataAnnotations;

namespace UsersApi.Models;

public class UserAddDto
{
    [Required]
    [MaxLength(100)]
    public string Email {get; set;} = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Password {get; set;} = string.Empty;
}
