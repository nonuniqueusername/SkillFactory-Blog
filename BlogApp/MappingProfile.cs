using AutoMapper;
using BlogApp.BLL.ViewModels.Comments;
using BlogApp.BLL.ViewModels.Posts;
using BlogApp.BLL.ViewModels.Tags;
using BlogApp.BLL.ViewModels.Users;
using BlogApp.DAL.Models;

namespace BlogApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterViewModel, User>()
                .ForMember(x => x.Email, opt => opt.MapFrom(c => c.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(c => c.UserName));

            CreateMap<CommentCreateViewModel, Comment>();
            CreateMap<CommentEditViewModel, Comment>();
            CreateMap<PostCreateViewModel, Post>();
            CreateMap<PostEditViewModel, Post>();
            CreateMap<TagCreateViewModel, Tag>();
            CreateMap<TagEditViewModel, Tag>();
            CreateMap<UserEditViewModel, User>();
        }
    }
}
