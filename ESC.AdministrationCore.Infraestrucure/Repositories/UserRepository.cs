using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using ESC.AdministrationCore.Entities.DbSet;
using ESC.AdministrationCore.Application.DTOs;
using ESC.AdministrationCore.Infraestructure.Sql;
using ESC.AdministrationCore.Application.Interfaces;

using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace ESC.AdministrationCore.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration _configuration;
        private readonly AdministrationCoreDbContext _context;
        private readonly IMapper _mapper;

        #endregion

        #region ===[ Constructor ]=================================================================

        public UserRepository(IConfiguration configuration, AdministrationCoreDbContext context, IMapper Mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = Mapper;
        }

        #endregion

        #region ===[ IUserRepository Methods ]=====================================================


        //public async Task<List<UserDTO>> GetAll()
        //{
        //    var users = await _context.Users.ToListAsync();

        //    return _mapper.Map<List<UserDTO>>(users);
        //}

        public async Task<List<User>> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                var users = await connection.QueryAsync<User>(Queries.AllUsers);

                return users.ToList();
            }
        }

        public async Task<User> GetById(Guid id)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                var user = (await connection.QueryAsync<User>(Queries.UserById, new { id = id })).SingleOrDefault();

                return user;
            }

        }

        string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;TrustServerCertificate=True;";

        public async Task<User> AuthenticateUser(string username, string password)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection")))
            {
                var user = (await connection.QueryAsync<User>(Queries.AuthenticateUser
                    , new { UserName = username, Password = password })).FirstOrDefault();

                return user;
            }
        }

        #endregion
    }
}