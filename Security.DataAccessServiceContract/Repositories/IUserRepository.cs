using Security.DataAccessServiceContract.Base;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Repositories
{
    public interface IUserRepository:IBaseRepositorySearchable<User,int,UserSearchModel,UserListItem>
    {

    }
}

