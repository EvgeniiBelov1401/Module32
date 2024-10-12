using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using MvcStartApp.Models.Db;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models;
using MvcStartApp.Models.Repository;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private IRequestRepository requestRepository;


        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next,IRequestRepository requestRepository)
        {
            _next = next;
            this.requestRepository = requestRepository;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            var request = new Request
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url=context.Request.Host.Value+context.Request.Path
            };
            await requestRepository.AddLog(request);


            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
