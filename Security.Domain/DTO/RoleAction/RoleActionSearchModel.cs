using Security.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Domain.DTO.RoleAction
{
    public class RoleActionSearchModel: PageModel
    {
        public int ProjectActionID { get; set; }
        public bool HasPermission { get; set; }
    }
}
