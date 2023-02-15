using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public OperationResult Add(Role model)
        {
            throw new NotImplementedException();
        }

        public OperationResult Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Role Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<RoleListItem> Search(Role sm, out int RecordCount)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(Role model)
        {
            throw new NotImplementedException();
        }
    }
}
