using Security.DataAccessServiceContract.Base;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Repositories
{
    public interface IProjectControllerRepository : IBaseRepositorySearchable<ProjectController, int, ProjectControllerSearchModel, ProjectControllerListItem>
    {

    }
}
