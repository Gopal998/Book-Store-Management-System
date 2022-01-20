using BookStore.DataAccessLayer;
using BookStore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer
{
    public class UserBLL:IUserBLL
    {
        private readonly IUserDAL _userDAL;
        public UserBLL(IUserDAL user)
        {
            _userDAL = user;
        }
        public async Task<bool> AddUser(User user)
        {
            return await _userDAL.AddUser(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userDAL.DeleteUser(id);
        }

        public async Task<List<User>> GetUser()
        {
            return await _userDAL.GetUser();
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await _userDAL.UpdateUser(user);
        }
    }
}
