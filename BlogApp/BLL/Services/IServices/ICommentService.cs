using BlogApp.BLL.ViewModels.Comments;
using BlogApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BLL.Services.IServices
{
    public interface ICommentService
    {
        Task<Guid> CreateComment(CommentCreateViewModel model, Guid userId);

        Task RemoveComment(Guid id);

        Task<List<Comment>> GetComments();
        Task<Comment> GetComment(Guid id);

        Task<CommentEditViewModel> EditComment(Guid id);

        Task EditComment(CommentEditViewModel model, Guid id);
    }
}
