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

        private readonly SecurityContext db;
        public RoleRepository(SecurityContext db)
        {
            this.db = db;
        }

        private RoleListItem ToListItem(Role rol)
        {

            RoleListItem listItem = new RoleListItem
            {
                RoleID = rol.RoleID,
                RoleName = rol.RoleName
            };
            return listItem;
        }
        public OperationResult Add(RoleAddModel model)
        {
            OperationResult op = new OperationResult("Add", "Roles");
            try
            {
                var role = new Role
                {
                    RoleName= model.RoleName
                };
                db.Roles.Add(role);
                db.SaveChanges();
                op.ToSuccess(role.RoleID, "Add Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Add Failed " + ex.Message);
            }
            return op;
        }

        public OperationResult Delete(int Id)
        {
            OperationResult op = new OperationResult("Remove", "Roles");
            try
            {
                var rol = db.Roles.FirstOrDefault(x => x.RoleID == Id);
                db.Roles.Remove(rol);
                db.SaveChanges();
                op.ToSuccess(Id, "Delete Successfully");
            }
            catch(Exception ex)
            {
                op.ToSuccess("Delete Failed ." + ex.Message);
            }
            return op;
        }

        public Role Get(int Id)
        {
            return db.Roles.FirstOrDefault(x => x.RoleID == Id);
        }

        public List<Role> GetAll()
        {
            return db.Roles.ToList();
        }

        public List<RoleListItem> Search(RoleSearchModel sm, out int RecordCount)
        {
            var q = from item in db.Roles select item;
            if (!string.IsNullOrEmpty(sm.RoleName))
            {
                q = q.Where(x => x.RoleName == sm.RoleName);
            }
            RecordCount= q.Count();
            return q.Select(x => new RoleListItem
            {
                RoleID = x.RoleID,
                RoleName = x.RoleName
            }).OrderByDescending(x => x.RoleID).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();

        }


        public OperationResult Update(RoleUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "Roles", model.RoleID);
            try
            {
                var r = db.Roles.FirstOrDefault(x=>x.RoleID == model.RoleID);
                r.RoleID = model.RoleID;
                r.RoleName = model.RoleName;
                db.SaveChanges();
                op.ToSuccess("Update Successfully");
            }
            catch(Exception ex)
            {
                op.ToFail("Update Failed " + ex.Message);
            }
            return op;
        }
    }
}
