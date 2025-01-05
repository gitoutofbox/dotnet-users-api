using System;

namespace UsersApi.Models;

public class UserDetailDto
{
     public int Id { get; set; }
    public int UserId { get; set; }

    public string Name { get; set; } = string.Empty;

    
    public string Phone { get; set; } = string.Empty;

    public string? Address { get; set; }
}
