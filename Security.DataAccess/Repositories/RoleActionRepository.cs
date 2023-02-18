using Security.DataAccessServiceContract.Repositories;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;
using Shopping.DomainModel.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class RoleActionRepository : IRoleActionRepository
    {
        private RoleActionListItem ToListItem(RoleAction RA)
        {
            var lstitm = new RoleActionListItem
            {
                RoleActionID = RA.RoleActionID,
            };
            return lstitm;
        }
        private readonly SecurityContext db;
        public RoleActionRepository(SecurityContext db)
        {
            this.db = db;
        }
        public OperationResult Add(RoleActionAddModel model)
        {
            OperationResult op = new OperationResult("Add", "RoleActions");
            try
            {
                var ra = new RoleAction
                {
                    ProjectActionID = model.ProjectActionID,
                    HasPermission = model.HasPermission
                };
                db.RoleActions.Add(ra);
                db.SaveChanges();
                op.ToSuccess(ra.RoleActionID, "Add Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Add Failed " + ex.Message);
            }
            return op;
        }

        public RoleAction Get(int id)
        {
            return db.RoleActions.FirstOrDefault(x => x.RoleActionID == id);
        }

        public List<RoleAction> GetAll()
        {
            return db.RoleActions.ToList();
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete", "RoleActions");
            try
            {
                var ra = db.RoleActions.FirstOrDefault(x => x.RoleActionID == id);
                db.RoleActions.Remove(ra);
                db.SaveChanges();
                op.ToSuccess(ra.RoleActionID, "Add Successfully");
            }
            catch (Exception ex)
            {
                op.ToSuccess("Add Failed" + ex.Message);
            }
            return op;
        }

        public List<RoleActionListItem> Search(RoleActionSearchModel sm, out int RecordCount)
        {
            var q = from item in db.RoleActions select item;

            if (ProjectActionID == sm.ProjectActionID)
            {
                if (sm.HasPermission == true)
                {
                    q = q.Where(x => x.HasPermission == true);
                }
                if (sm.HasPermission == false)
                {
                    q = q.Where(x => x.HasPermission == false);
                }
            }

            if (sm.HasPermission == true)
            {
                q = q.Where(x => x.HasPermission == true);
            }
            if (sm.HasPermission == false)
            {
                q = q.Where(x => x.HasPermission == false);
            }
            RecordCount = q.Count();
            return q.Select(x => new RoleAction
            {
                ProjectActionID = x.ProjectActionID,
                HasPermission = x.HasPermission,

            }
            ).OrderByDescending(x => x.ProjectAreaID).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(RoleActionUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "RoleActions", model.RoleActionID); ;
            try
            {
                var ra = db.RoleActions.FirstOrDefault(x => x.RoleActionID == model.RoleActionID);

                ra.RoleActionID = model.RoleActionID;
                ra.HasPermission = model.HasPermission;
                ra.RoleID = model.RoleID;
                ra.ProjectActionID = model.ProjectActionID;
                db.SaveChanges();
                op.ToSuccess(ra.RoleActionID, "Update Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Update Failed " + ex.Message);
            }
            return op;
        }
    }
}
