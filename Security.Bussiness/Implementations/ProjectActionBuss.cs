using Security.BussinessServiceContract.Services;
using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Bussiness.Implementations
{
    public class ProjectActionBuss : IProjectActionBuss
    {
        private readonly IProjectActionRepository repo;
        public ProjectActionBuss(IProjectActionRepository repo)
        {
            this.repo = repo;
        }
        public OperationResult Delete(int ProjectActionID)
        {
            return repo.Delete(ProjectActionID);
        }

        public ProjectAction GetProjectAction(int ProjectActionID)
        {
            return repo.Get(ProjectActionID);
        }

        public int GetProjectController(string Controller)
        {
            return repo.GetProjectControllerId(Controller);
        }

        public List<ProjectControllerDrop> ProjectControllerDrops()
        {
            return repo.PcDrops();
        }

        public OperationResult Register(ProjectActionAddModel PA)
        {
            if(repo.ExistProjectActionName(PA.ProjectActionName))
            {
                return new OperationResult("Register failed", "ProjectAction").ToFail("ActionName already exist!!");
            }
            return repo.Add(PA);
        }

        public List<ProjectActionListItem> Search(ProjectActionSearchModel sm, out int RecordCount)
        {
            if(sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(ProjectActionUpdateModel PA)
        {
            if (repo.ExistProjectActionName(PA.ProjectActionName,PA.ProjectActionID))
            {
                return new OperationResult("Update failed", "ProjectAction").ToFail("ActionName already exist!!");
            }
            return repo.Update(PA);
        }
    }
}
