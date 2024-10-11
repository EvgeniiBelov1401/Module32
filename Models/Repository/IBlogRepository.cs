using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers.Repository
{
    public interface IBlogRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();
    }
}
