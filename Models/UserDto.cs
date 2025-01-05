using System;
using System.ComponentModel.DataAnnotations;
using UsersApi.Entities;

namespace UsersApi.Models;

public class UserDto
{
    public int Id {get; set;}
    public string Email {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
    
    public UserDetail UserDetail {get; set;} = new UserDetail("",  "");
}
