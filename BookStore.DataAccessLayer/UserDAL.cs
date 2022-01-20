using BookStore.CustomException;
using BookStore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer
{
    public class UserDAL:IUserDAL
    {
        private readonly BookStoreDBContext _dbContext;

        public UserDAL(BookStoreDBContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> AddUser(User user)
        {
            if (await _dbContext.Users.FirstOrDefaultAsync(b => b.UserName == user.UserName) != null)
            {
                throw new DuplicateNameException("Name already Exists");
            }
            else
            {
                try
                {
                    int rowAffected = 0;
                    _dbContext.Add(user);
                    rowAffected = await _dbContext.SaveChangesAsync();
                    if (rowAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    throw new SqlException("Something went Wrong", e);
                }
            }
        }
        public async Task<List<User>> GetUser()
        {
            try
            {
                return await _dbContext.Users.Where(b => b.IsDeleted == false).ToListAsync();
            }
            catch (Exception e)
            {
                throw new SqlException("Something went Wrong", e);
            }
        }
        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                User oldUser = await _dbContext.Users.FirstOrDefaultAsync(s => s.UserId == user.UserId);
                oldUser.UserName = user.UserName;
                oldUser.EmailId = user.EmailId;
                oldUser.IsDeleted = user.IsDeleted;
               
                int rowAffected = 0;
                rowAffected = await _dbContext.SaveChangesAsync();
                if (rowAffected == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new SqlException("Something went wrong", e);
            }
        }
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                User user = await _dbContext.Users.FirstOrDefaultAsync(t => t.UserId == id);
                if (user != null)
                {
                    user.IsDeleted = true;
                    int rowAffected = 0;
                    
                    rowAffected = await _dbContext.SaveChangesAsync();
                    if (rowAffected != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new SqlException("Something went Wrong", e);

            }
        }
    }
}
