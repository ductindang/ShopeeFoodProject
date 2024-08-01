using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Contrast
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailPass(string email, string password);
        Task<User> GetUserByEmail(string email);
    }
}
