using Security.DataAccessServiceContract.Base;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.Models;
using Shopping.DataAcceServiceContract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Repositories
{
    public interface IProjectActionRepository : IBaseRespositorySearchable<ProjectAction, int, ProjectActionSearchModel, ProjectActionListItem,ProjectActionUpdateModel,ProjectActionAddModel>
    {
        bool ExistProjectActionName(string ProjectActionName);
        public List<ProjectControllerDrop> PcDrops();
     

    }
}
