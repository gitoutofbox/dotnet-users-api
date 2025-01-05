using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersApi.Entities;

public class UserDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }
    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(15)]
    public string Phone { get; set; }

    public string? Address { get; set; }


    public UserDetail(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }
}
