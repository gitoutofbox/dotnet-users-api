using System;
using UsersApi.Entities;

namespace UsersApi.Services;

public interface IUsersRepository
{
    public Task<IEnumerable<User>> GetUsers();
    public Task AddUser(User user);
    public Task<User?> GetUser(int userId);
    public void UpdateUser(User user);
    public Task<bool> saveChanges();
}
