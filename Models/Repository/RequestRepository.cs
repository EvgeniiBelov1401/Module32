using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;


        public RequestRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task AddLog(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetLog()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
