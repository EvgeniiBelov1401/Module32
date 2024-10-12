using Microsoft.AspNetCore.Http;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Repository
{
    public interface IRequestRepository
    {
        Task AddLog(Request request);
        Task<Request[]> GetLog();
    }
}
