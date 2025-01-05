using System;
using Microsoft.EntityFrameworkCore;
using UsersApi.Entities;

namespace UsersApi.Dbcontexts;

public class UsersDbConext: DbContext
{

    public DbSet<User> Users {get; set;}
    public DbSet<UserDetail> UserDetails {get; set;}

    public UsersDbConext(DbContextOptions<UsersDbConext> dbContextOptions): base(dbContextOptions) {
    }
}
