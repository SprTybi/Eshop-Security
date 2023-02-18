﻿using Security.DataAccessServiceContract.Base;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.Models;
using Shopping.DataAcceServiceContract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Repositories
{
    public interface IProjectControllerRepository : IBaseRespositorySearchable<ProjectController, int, ProjectControllerSearchModel, ProjectControllerListItem,ProjectControllerUpdateModel,ProjectControllerAddModel>
    {
        bool ExitsProjectControllerName(string ProjectControllerName);
        public List<ProjectAreaDrop> ProjectAreaDrps();
    }
}
