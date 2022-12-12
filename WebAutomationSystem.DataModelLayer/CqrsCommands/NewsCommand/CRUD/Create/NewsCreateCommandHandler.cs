using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.CRUD.Create
{
    public class NewsCreateCommandHandler : IRequestHandler<NewsCreateCommandModel, int>
    {
        private readonly ApplicationDbContext _context;
        public NewsCreateCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(NewsCreateCommandModel request, CancellationToken cancellationToken)
        {
            var N = new News
            {
                NewsContent = request.NewsContent,
                NewsDate = DateTime.Now,
                NewsTitle = request.NewsTitle,
                NewsAttachment = request.NewsAttachment,
                UserID = request.UserID,
                flag = true
            };
            var result = _context.News.Add(N);
            await _context.SaveChangesAsync();
            return result.Entity.NewsID;
        }
    }
}