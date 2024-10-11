using Microsoft.AspNetCore.Http;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Repository
{
    public interface IRequestRepository
    {
        Task AddLog(HttpContext log);
        Task<Request[]> GetLog();
    }
}
