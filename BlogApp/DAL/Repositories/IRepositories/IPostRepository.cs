using BlogApp.DAL.Models;

namespace BlogApp.DAL.Repositories.IRepositories
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();

        Post GetPost(Guid id);

        Task AddPost(Post post);

        Task UpdatePost(Post post);

        Task RemovePost(Guid id);

        Task<bool> SaveChangesAsync();

        Task<List<Post>> GetPostsByAuthor(string authorId);
    }
}
