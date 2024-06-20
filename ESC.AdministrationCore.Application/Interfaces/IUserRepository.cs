using ESC.AdministrationCore.Application.DTOs;
using ESC.AdministrationCore.Entities.DbSet;

namespace ESC.AdministrationCore.Application.Interfaces
{
    public interface IUserRepository
    {
        //Task<List<UserDTO>> GetAll();

        Task<List<User>> GetAll();

        Task<User> GetById(Guid id);

        Task<User> AuthenticateUser(string username, string password);
    }
}