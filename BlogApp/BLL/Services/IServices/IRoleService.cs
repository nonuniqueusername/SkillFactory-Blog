using BlogApp.BLL.ViewModels.Roles;
using BlogApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BlogApp.BLL.Services.IServices
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateViewModel model);

        Task EditRole(RoleEditViewModel model);

        Task RemoveRole(Guid id);

        Task<List<Role>> GetRoles();

        Task<Role?> GetRole(Guid id);
    }
}
