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
        private UserListItem ToListItem(User u)
        {
            var lstItem = new UserListItem
            {
                UserId = u.UserID,
                UserName = u.UserName,
                Email = u.Email,
                Mobile = u.Mobile,
                FirstName = u.FirstName,
                LastName = u.LastName,
            };
            return lstItem;
        }
        private readonly SecurityContext db;
        public UserRepository(SecurityContext db)
        {
            this.db = db;
        }
        public OperationResult Add(UserAddModel model)
        {
            OperationResult op = new OperationResult("Add", "Users");
            try
            {
                var u = new User
                {
                    FirstName= model.FirstName,
                    LastName= model.LastName,
                    Email= model.Email,
                    Mobile = model.Mobile,
                    IsEmailActivated = model.IsEmailActivated,
                    UserName= model.UserName,
                    Password = model.Password,
                    RoleID = model.RoleID,
                };
                db.Users.Add(u);
                db.SaveChanges();
                op.ToSuccess(u.UserID, "Add Successfully");
            }
            catch(Exception ex)
            {
                op.ToFail("Add Failed " + ex.Message);  
            }
            return op;
        }

        public OperationResult Delete(int Id)
        {
            OperationResult op = new OperationResult("Remove", "Users", Id);
           {
               try
            {
                    var u = Get(Id);
                    db.Users.Remove(u);
                    db.SaveChanges();
                    op.ToSuccess(Id, "Delete Successfully!");

                }
                catch (Exception ex)
                {

                    op.ToFail(Id, "Delete Failed" + ex.Message);

                }
                return op;
            }
        }

        public User Get(int Id)
        {
            return db.Users.FirstOrDefault(x => x.UserID == Id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList()
;        }

        public List<UserListItem> Search(UserSearchModel sm, out int RecordCount)
        {
            var q = from item in db.Users select item;
            if (!string.IsNullOrEmpty(sm.FirstName))
            {
                q = q.Where(x => x.FirstName.StartsWith(sm.FirstName));
            }
            RecordCount = q.Count();
            return q.Select(x => new UserListItem
            {
                UserId = x.UserID,
                    FirstName = x.FirstName,
                LastName = x.LastName,

            }
            ).OrderByDescending(x => x.UserId).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
             
        }

        public OperationResult Update(UserUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "Users", model.UserID);
                try
            {
                var u = Get(model.UserID);
                u.UserName = model.UserName;
                u.FirstName = model.FirstName;
                u.Email = model.Email;
                u.LastName = model.LastName;
                u.Mobile = model.Mobile;
                    
                db.SaveChanges();
                op.ToSuccess("Update Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Update Failed!" + ex.Message);
            }
            return op;
        }
    }
}
