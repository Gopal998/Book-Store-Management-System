using BookStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer
{
    public interface IUserBLL
    {
        Task<bool> AddUser(User user);
        Task<List<User>> GetUser();
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
