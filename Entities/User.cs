using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UsersApi.Models;

namespace UsersApi.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}


    [Required]
    [MaxLength(100)]
    public string Email {get; set;}

    [MaxLength(200)]
    public string Password {get; set;}
    
    public UserDetail? UserDetail {get; set;}

    public User(string email, string password) {
        Email = email;
        Password = password;
    }
}
