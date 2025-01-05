using System;
using Microsoft.EntityFrameworkCore;
using UsersApi.Dbcontexts;
using UsersApi.Entities;
using UsersApi.Models;

namespace UsersApi.Services;

public class UsersRepository : IUsersRepository
{
    private UsersDbConext context;

    public UsersRepository(UsersDbConext _context) {
        context = _context ?? throw new ArgumentNullException(nameof(_context));
    }

    public async Task<bool> saveChanges()
    {
        return await context.SaveChangesAsync() >= 0;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await context.Users.OrderBy(u => u.Email).ToListAsync();
    }

    public async Task<User?> GetUser(int userId)
    {
        
        return await context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
    }

    public async Task AddUser(User user)
    {
        await context.Users.AddAsync(user);
    }


    public void UpdateUser(User user)
    {
        context.Users.Update(user);
    }
}
