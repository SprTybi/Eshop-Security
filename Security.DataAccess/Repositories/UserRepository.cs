using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public OperationResult Add(User model)
        {
            throw new NotImplementedException();
        }

        public OperationResult Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public User Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<UserListItem> Search(UserSearchModel sm, out int RecordCount)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
