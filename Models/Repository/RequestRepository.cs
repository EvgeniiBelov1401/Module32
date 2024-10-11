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
        Request request;

        public RequestRepository(BlogContext context, Request request)
        {
            _context = context;
            this.request = request;
        }
        public async Task AddLog(HttpContext log)
        {
            request.Id = Guid.NewGuid();
            request.Date = DateTime.Now;
            request.Url=log.Request.Host.Value+log.Request.Path;

            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetLog()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
