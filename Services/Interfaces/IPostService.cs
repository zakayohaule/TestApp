using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Domains;

namespace TestApp.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> FindByIdAsync(int id);
        Task<bool> UpdateAsync(Post post);
        Task<bool> DeleteAsync(int id);
        Task<Post> CreateAsync(Post postToAdd);
    }
}